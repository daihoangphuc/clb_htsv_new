using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using website_CLB_HTSV.Data;
using website_CLB_HTSV.Models;

namespace website_CLB_HTSV.Controllers
{
    public class HoatDongsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public HoatDongsController(ApplicationDbContext context, IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
        }
        public string GetIDFromEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return email;

            var parts = email.Split('@');
            return parts.Length > 0 ? parts[0] : email;
        }
        private int LaySoDongTrongBang(string tenbang)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM " + tenbang;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int rowCount = Convert.ToInt32(command.ExecuteScalar());
                    return rowCount;
                }
            }
        }
        public static string Taoidtaikhoan(int sequentialNumber)
        {
            return $"DK{sequentialNumber:D3}";
        }

        [HttpPost]
        public async Task<IActionResult> DangKy(string hoatDongId)
        {
            int y = LaySoDongTrongBang("DangKyHoatDong");
            if (ModelState.IsValid)
            {
                var dangKyHoatDong = new DangKyHoatDong
                {
                    MaHoatDong = hoatDongId,
                    MaSV = User.Identity.Name.Split('@')[0],
                    MaDangKy = Taoidtaikhoan(y+1),
                    NgayDangKy = DateTime.Now,
                    TrangThaiDangKy = true

                };

                _context.Add(dangKyHoatDong);
                await _context.SaveChangesAsync(); // Lưu vào CSDL

                // Điều hướng người dùng về trang cần thiết hoặc thông báo thành công
                // Ví dụ: quay trở lại danh sách hoạt động
                return RedirectToAction(nameof(Index));
            }

            // Nếu không hợp lệ, quay về trang hiện tại
            return View(hoatDongId);
        }


       


        // GET: HoatDongs
        public async Task<IActionResult> Index(string searchString)
        {
            // Kiểm tra người dùng đã đăng nhập hay chưa
            if (!User.Identity.IsAuthenticated)
            {
                // Nếu chưa đăng nhập, đặt thông báo vào TempData
                TempData["ErrorMessage"] = "Bạn cần đăng nhập để truy cập vào trang này.";
            }
            else
            {
                // Lấy thông tin người dùng hiện tại
                var currentUser = await _userManager.GetUserAsync(User);
                var Mssv = User.Identity.Name.Split('@')[0];

                // Lọc các hoạt động dựa trên trạng thái đăng ký của người dùng hiện tại
                var hoatdong = _context.HoatDong.Where(hd => !_context.DangKyHoatDong
                                                                .Any(dk => dk.MaHoatDong == hd.MaHoatDong
                                                                        && dk.MaSV == Mssv
                                                                        && dk.TrangThaiDangKy == true));

                // Lọc theo chuỗi tìm kiếm nếu có
                if (!string.IsNullOrEmpty(searchString))
                {
                    hoatdong = hoatdong.Where(s => s.TenHoatDong.Contains(searchString)
                                                || s.MoTa.Contains(searchString));
                }

                return View(await hoatdong.ToListAsync());
            }
            return Redirect("/Identity/Account/Login");




        }





        /* // Trong controller HoatDongs
         public async Task<IActionResult> DaDangKi(string id)
         {

             if (id == null)
             {
                 return NotFound();
             }

             var hoatDong = await _context.HoatDong.FindAsync(id);
             if (hoatDong == null)
             {
                 return NotFound();
             }

             // Cập nhật trạng thái của hoạt động trong cơ sở dữ liệu
             hoatDong.DaDangKi = true;

             try
             {
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             catch (DbUpdateException)
             {
                 // Xử lý lỗi nếu có
                 ModelState.AddModelError("", "Lỗi khi cập nhật trạng thái hoạt động.");
                 return RedirectToAction(nameof(Index));
             }
         }


         // Trong controller HoatDongs
         public async Task<IActionResult> DaThamGia(string id)
         {

             if (id == null)
             {
                 return NotFound();
             }

             var hoatDong = await _context.HoatDong.FindAsync(id);
             if (hoatDong == null)
             {
                 return NotFound();
             }

             // Cập nhật trạng thái của hoạt động trong cơ sở dữ liệu
             hoatDong.DaThamGia = true;

             try
             {
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             catch (DbUpdateException)
             {
                 // Xử lý lỗi nếu có
                 ModelState.AddModelError("", "Lỗi khi cập nhật trạng thái hoạt động.");
                 return RedirectToAction(nameof(Index));
             }
         }
 */


        // GET: HoatDongs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HoatDong == null)
            {
                return NotFound();
            }

            var hoatDong = await _context.HoatDong
                .FirstOrDefaultAsync(m => m.MaHoatDong == id);
            if (hoatDong == null)
            {
                return NotFound();
            }

            return View(hoatDong);
        }

        // GET: HoatDongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HoatDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHoatDong,TenHoatDong,MoTa,ThoiGian,DiaDiem,HocKy,NamHoc,HinhAnh,TrangThai,DaDangKi,DaThamGia,MinhChung")] HoatDong hoatDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoatDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoatDong);
        }

        // GET: HoatDongs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HoatDong == null)
            {
                return NotFound();
            }

            var hoatDong = await _context.HoatDong.FindAsync(id);
            if (hoatDong == null)
            {
                return NotFound();
            }
            return View(hoatDong);
        }

        // POST: HoatDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHoatDong,TenHoatDong,MoTa,ThoiGian,DiaDiem,HocKy,NamHoc,HinhAnh,TrangThai,DaDangKi,DaThamGia,MinhChung")] HoatDong hoatDong)
        {
            if (id != hoatDong.MaHoatDong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoatDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoatDongExists(hoatDong.MaHoatDong))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hoatDong);
        }

        // GET: HoatDongs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HoatDong == null)
            {
                return NotFound();
            }

            var hoatDong = await _context.HoatDong
                .FirstOrDefaultAsync(m => m.MaHoatDong == id);
            if (hoatDong == null)
            {
                return NotFound();
            }

            return View(hoatDong);
        }

        // POST: HoatDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HoatDong == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HoatDong'  is null.");
            }
            var hoatDong = await _context.HoatDong.FindAsync(id);
            if (hoatDong != null)
            {
                _context.HoatDong.Remove(hoatDong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoatDongExists(string id)
        {
          return (_context.HoatDong?.Any(e => e.MaHoatDong == id)).GetValueOrDefault();
        }
    }
}
