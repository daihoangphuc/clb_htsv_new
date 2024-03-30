using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using website_CLB_HTSV.Data;
using website_CLB_HTSV.Models;
using OfficeOpenXml;
namespace website_CLB_HTSV.Controllers
{
    public class DangKyHoatDongsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public DangKyHoatDongsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Administrators")]
        public IActionResult ImportExcel()
        {
            var activityList = _context.HoatDong
                                       .Select(a => new SelectListItem
                                       {
                                           Value = a.MaHoatDong.ToString(),
                                           Text = a.TenHoatDong
                                       })
                                       .ToList();

            ViewBag.ActivityList = activityList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> ImportExcel(string selectedActivity, IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                TempData["ErrorMessage"] = "File is not selected or empty.";
                return RedirectToAction(nameof(Index));
            }

            var fileExtension = Path.GetExtension(file.FileName).ToUpper();
            if (fileExtension != ".XLSX" && fileExtension != ".XLS")
            {
                TempData["ErrorMessage"] = "Please upload an Excel file.";
                return RedirectToAction(nameof(Index));
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null)
                    {
                        TempData["ErrorMessage"] = "No worksheet found in the Excel file.";
                        return RedirectToAction(nameof(Index));
                    }

                    int totalRows = worksheet.Dimension.Rows;
                    var studentCodes = new List<string>();

                    for (int i = 1; i <= totalRows; i++)
                    {
                        var studentCode = worksheet.Cells[i, 1]?.Value?.ToString().Trim();
                        if (!string.IsNullOrEmpty(studentCode))
                        {
                            studentCodes.Add(studentCode);
                        }
                    }

                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            foreach (var studentCode in studentCodes)
                            {
                                var registrationRecord = await _context.DangKyHoatDong
                                    .FirstOrDefaultAsync(r => r.MaSV == studentCode && r.MaHoatDong == selectedActivity);

                                if (registrationRecord != null && !registrationRecord.TrangThaiDangKy)
                                {
                                    var participationRecord = new ThamGiaHoatDong
                                    {
                                        MaThamGiaHoatDong = "TGHD" + DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                                        MaDangKy = registrationRecord.MaDangKy,
                                        DaThamGia = true
                                        // Các thuộc tính khác...
                                    };

                                    _context.Add(participationRecord);
                                }
                            }

                            await _context.SaveChangesAsync();
                            transaction.Commit();
                            TempData["SuccessMessage"] = "Data imported successfully.";
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            TempData["ErrorMessage"] = "Error occurred while importing data: " + ex.Message;
                        }
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }




        [HttpPost]
        [Authorize]
        public async Task<IActionResult> HuyDangKy(string hoatDongId)
        {
            var mssv = User.Identity.Name.Split('@')[0];

            // Tìm mục DangKyHoatDong tương ứng với hoatDongId và mssv và trạng thái đăng ký là true
            var dangKyHoatDong = await _context.DangKyHoatDong
                .FirstOrDefaultAsync(dk => dk.MaHoatDong == hoatDongId
                                        && dk.MaSV == mssv
                                        && dk.TrangThaiDangKy == true);

            if (dangKyHoatDong != null)
            {
                
                try
                {
                    // Xóa mục DangKyHoatDong từ cơ sở dữ liệu
                    _context.DangKyHoatDong.Remove(dangKyHoatDong);
                    await _context.SaveChangesAsync();

                    // Điều hướng người dùng về trang cần thiết hoặc thông báo thành công
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có
                    // Ở đây, bạn có thể trả về một thông báo lỗi hoặc điều hướng người dùng đến một trang lỗi
                    return RedirectToAction(nameof(Error));
                }
            }
            else
            {
                // Trả về NotFound nếu không tìm thấy mục tương ứng
                return NotFound();
            }
        }

        private object Error()
        {
            throw new NotImplementedException();
        }







        // GET: DangKyHoatDongs
        [Authorize]
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
                var hoatdong = _context.DangKyHoatDong.Include(s => s.HoatDong).Include(s => s.SinhVien).Where(dk => dk.MaSV == Mssv && dk.TrangThaiDangKy == true);
                if (!string.IsNullOrEmpty(searchString))
                {
                    hoatdong = hoatdong.Where(s => s.MaHoatDong.Contains(searchString) || s.MaSV.Contains(searchString));
                }
                return View(await hoatdong.ToListAsync());

            } 
            return Redirect("/Identity/Account/Login");
        }

        // GET: DangKyHoatDongs/Details/5
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DangKyHoatDong == null)
            {
                return NotFound();
            }

            var dangKyHoatDong = await _context.DangKyHoatDong
                .Include(d => d.HoatDong)
                .Include(d => d.SinhVien)
                .FirstOrDefaultAsync(m => m.MaDangKy == id);
            if (dangKyHoatDong == null)
            {
                return NotFound();
            }

            return View(dangKyHoatDong);
        }

        // GET: DangKyHoatDongs/Create
        [Authorize(Roles = "Administrators")]
        public IActionResult Create()
        {
            ViewData["MaHoatDong"] = new SelectList(_context.HoatDong, "MaHoatDong", "MaHoatDong");
            ViewData["MaSV"] = new SelectList(_context.SinhVien, "MaSV", "MaSV");
            return View();
        }

        // POST: DangKyHoatDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Create([Bind("MaDangKy,MaSV,MaHoatDong,NgayDangKy,TrangThaiDangKy")] DangKyHoatDong dangKyHoatDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangKyHoatDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHoatDong"] = new SelectList(_context.HoatDong, "MaHoatDong", "MaHoatDong", dangKyHoatDong.MaHoatDong);
            ViewData["MaSV"] = new SelectList(_context.SinhVien, "MaSV", "MaSV", dangKyHoatDong.MaSV);
            return View(dangKyHoatDong);
        }

        // GET: DangKyHoatDongs/Edit/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DangKyHoatDong == null)
            {
                return NotFound();
            }

            var dangKyHoatDong = await _context.DangKyHoatDong.FindAsync(id);
            if (dangKyHoatDong == null)
            {
                return NotFound();
            }
            ViewData["MaHoatDong"] = new SelectList(_context.HoatDong, "MaHoatDong", "MaHoatDong", dangKyHoatDong.MaHoatDong);
            ViewData["MaSV"] = new SelectList(_context.SinhVien, "MaSV", "MaSV", dangKyHoatDong.MaSV);
            return View(dangKyHoatDong);
        }

        // POST: DangKyHoatDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(string id, [Bind("MaDangKy,MaSV,MaHoatDong,NgayDangKy,TrangThaiDangKy")] DangKyHoatDong dangKyHoatDong)
        {
            if (id != dangKyHoatDong.MaDangKy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangKyHoatDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangKyHoatDongExists(dangKyHoatDong.MaDangKy))
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
            ViewData["MaHoatDong"] = new SelectList(_context.HoatDong, "MaHoatDong", "MaHoatDong", dangKyHoatDong.MaHoatDong);
            ViewData["MaSV"] = new SelectList(_context.SinhVien, "MaSV", "MaSV", dangKyHoatDong.MaSV);
            return View(dangKyHoatDong);
        }

        // GET: DangKyHoatDongs/Delete/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DangKyHoatDong == null)
            {
                return NotFound();
            }

            var dangKyHoatDong = await _context.DangKyHoatDong
                .Include(d => d.HoatDong)
                .Include(d => d.SinhVien)
                .FirstOrDefaultAsync(m => m.MaDangKy == id);
            if (dangKyHoatDong == null)
            {
                return NotFound();
            }

            return View(dangKyHoatDong);
        }

        // POST: DangKyHoatDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DangKyHoatDong == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DangKyHoatDong'  is null.");
            }
            var dangKyHoatDong = await _context.DangKyHoatDong.FindAsync(id);
            if (dangKyHoatDong != null)
            {
                _context.DangKyHoatDong.Remove(dangKyHoatDong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangKyHoatDongExists(string id)
        {
          return (_context.DangKyHoatDong?.Any(e => e.MaDangKy == id)).GetValueOrDefault();
        }
    }
}
