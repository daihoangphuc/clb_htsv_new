using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using website_CLB_HTSV.Data;
using website_CLB_HTSV.Models;

namespace website_CLB_HTSV.Controllers
{
    public class SinhViensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SinhViensController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*        public IActionResult DSHoatDong()
                {
                    var sinhViens = _context.ThamGiaHoatDong.ToList();
                    return View();
                }*/




        [Authorize(Roles = "Administrators")]
        // Phương thức xuất Excel
        public IActionResult ExportToExcel()
        {
            // Lấy searchString từ Session
            var searchString = HttpContext.Session.GetString("searchString");

            var sinhViens = from s in _context.SinhVien.Include(s => s.ChucVu).Include(s => s.LopHoc)
                            select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                sinhViens = sinhViens.Where(s => s.MaSV.Contains(searchString)
                                                || s.HoTen.Contains(searchString)
                                                || s.ChucVu.TenChucVu.Contains(searchString)
                                                || s.LopHoc.MaLop.Contains(searchString));
            }
            // Tạo một package Excel mới
            using (var package = new ExcelPackage())
            {
                // Tạo một sheet mới
                var worksheet = package.Workbook.Worksheets.Add("Danh sách sinh viên");

                // Đặt tiêu đề cho các cột
                worksheet.Cells[1, 1].Value = "Mã Sinh Viên";
                worksheet.Cells[1, 2].Value = "Họ Tên";
                worksheet.Cells[1, 3].Value = "Ngày Sinh";
                worksheet.Cells[1, 4].Value = "Điện Thoại";
                worksheet.Cells[1, 5].Value = "Email";
                worksheet.Cells[1, 6].Value = "Mã Lớp";
                worksheet.Cells[1, 7].Value = "Mã Chức Vụ";
                worksheet.Cells[1, 8].Value = "Hình Ảnh";

                // Đặt dữ liệu cho các ô
                int row = 2;
                foreach (var sinhVien in sinhViens)
                {
                    worksheet.Cells[row, 1].Value = sinhVien.MaSV;
                    worksheet.Cells[row, 2].Value = sinhVien.HoTen;
                    worksheet.Cells[row, 3].Value = sinhVien.NgaySinh;
                    worksheet.Cells[row, 4].Value = sinhVien.DienThoai;
                    worksheet.Cells[row, 5].Value = sinhVien.Email;
                    worksheet.Cells[row, 6].Value = sinhVien.MaLop;
                    worksheet.Cells[row, 7].Value = sinhVien.MaChucVu;
                    worksheet.Cells[row, 8].Value = sinhVien.HinhAnh;
                    row++;
                }

                // Tạo một stream để lưu trữ tệp Excel
                MemoryStream stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;
                // Định dạng tên file với ngày tháng năm và thuộc tính được tìm kiếm
                string fileName = $"DanhSachSinhVien_{searchString}_{DateTime.Today:ddMMyyyy}.xlsx";

                // Trả về tệp Excel như một file
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }




        // GET: SinhViens
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Index(string searchString)
        {
            var sinhViens = from s in _context.SinhVien.Include(s => s.ChucVu).Include(s => s.LopHoc)
                            select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                sinhViens = sinhViens.Where(s => s.MaSV.Contains(searchString)
                                                || s.HoTen.Contains(searchString)
                                                || s.ChucVu.TenChucVu.Contains(searchString)
                                                || s.LopHoc.MaLop.Contains(searchString));

                // Lưu searchString vào Session
                HttpContext.Session.SetString("searchString", searchString);
            }

            return View(await sinhViens.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> BanChuNhiem()
        {
            var applicationDbContext = _context.SinhVien.Include(s => s.ChucVu).Include(s => s.LopHoc).Where(s => s.ChucVu.MaChucVu != "CV04" && s.ChucVu.MaChucVu != null);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: SinhViens/Details/5

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.ChucVu)
                .Include(s => s.LopHoc)
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhViens/Create
        [Authorize(Roles = "Administrators")]
        public IActionResult Create()
        {
            ViewData["MaChucVu"] = new SelectList(_context.ChucVu, "MaChucVu", "MaChucVu");
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop");
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Create([Bind("MaSV,HoTen,NgaySinh,DienThoai,Email,MaLop,MaChucVu,HinhAnh")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChucVu"] = new SelectList(_context.ChucVu, "MaChucVu", "MaChucVu", sinhVien.MaChucVu);
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["MaChucVu"] = new SelectList(_context.ChucVu, "MaChucVu", "MaChucVu", sinhVien.MaChucVu);
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(string id, [Bind("MaSV,HoTen,NgaySinh,DienThoai,Email,MaLop,MaChucVu,HinhAnh")] SinhVien sinhVien)
        {
            if (id != sinhVien.MaSV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.MaSV))
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
            ViewData["MaChucVu"] = new SelectList(_context.ChucVu, "MaChucVu", "MaChucVu", sinhVien.MaChucVu);
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.ChucVu)
                .Include(s => s.LopHoc)
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SinhVien == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SinhVien'  is null.");
            }
            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhVien.Remove(sinhVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
          return (_context.SinhVien?.Any(e => e.MaSV == id)).GetValueOrDefault();
        }
    }
}
