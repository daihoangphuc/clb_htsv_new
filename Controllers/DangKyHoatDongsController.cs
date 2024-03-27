using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using website_CLB_HTSV.Data;
using website_CLB_HTSV.Models;

namespace website_CLB_HTSV.Controllers
{
    public class DangKyHoatDongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DangKyHoatDongsController(ApplicationDbContext context)
        {
            _context = context;
        }

  

       


        // GET: DangKyHoatDongs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DangKyHoatDong.Where(dk=>dk.TrangThaiDangKy).Include(d => d.HoatDong).Include(d => d.SinhVien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DangKyHoatDongs/Details/5
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
