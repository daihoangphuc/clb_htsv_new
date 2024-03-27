using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using website_CLB_HTSV.Data;
using website_CLB_HTSV.Models;

namespace website_CLB_HTSV.Controllers
{
    public class ThamGiaHoatDongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThamGiaHoatDongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ThamGiaHoatDongs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ThamGiaHoatDong.Include(t => t.DangKyHoatDong);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ThamGiaHoatDongs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ThamGiaHoatDong == null)
            {
                return NotFound();
            }

            var thamGiaHoatDong = await _context.ThamGiaHoatDong
                .Include(t => t.DangKyHoatDong)
                .FirstOrDefaultAsync(m => m.MaThamGiaHoatDong == id);
            if (thamGiaHoatDong == null)
            {
                return NotFound();
            }

            return View(thamGiaHoatDong);
        }

        // GET: ThamGiaHoatDongs/Create
        public IActionResult Create()
        {
            ViewData["MaDangKy"] = new SelectList(_context.DangKyHoatDong, "MaDangKy", "MaDangKy");
            return View();
        }

        // POST: ThamGiaHoatDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaThamGiaHoatDong,MaDangKy,DaThamGia")] ThamGiaHoatDong thamGiaHoatDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thamGiaHoatDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDangKy"] = new SelectList(_context.DangKyHoatDong, "MaDangKy", "MaDangKy", thamGiaHoatDong.MaDangKy);
            return View(thamGiaHoatDong);
        }

        // GET: ThamGiaHoatDongs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ThamGiaHoatDong == null)
            {
                return NotFound();
            }

            var thamGiaHoatDong = await _context.ThamGiaHoatDong.FindAsync(id);
            if (thamGiaHoatDong == null)
            {
                return NotFound();
            }
            ViewData["MaDangKy"] = new SelectList(_context.DangKyHoatDong, "MaDangKy", "MaDangKy", thamGiaHoatDong.MaDangKy);
            return View(thamGiaHoatDong);
        }

        // POST: ThamGiaHoatDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaThamGiaHoatDong,MaDangKy,DaThamGia")] ThamGiaHoatDong thamGiaHoatDong)
        {
            if (id != thamGiaHoatDong.MaThamGiaHoatDong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thamGiaHoatDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThamGiaHoatDongExists(thamGiaHoatDong.MaThamGiaHoatDong))
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
            ViewData["MaDangKy"] = new SelectList(_context.DangKyHoatDong, "MaDangKy", "MaDangKy", thamGiaHoatDong.MaDangKy);
            return View(thamGiaHoatDong);
        }

        // GET: ThamGiaHoatDongs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ThamGiaHoatDong == null)
            {
                return NotFound();
            }

            var thamGiaHoatDong = await _context.ThamGiaHoatDong
                .Include(t => t.DangKyHoatDong)
                .FirstOrDefaultAsync(m => m.MaThamGiaHoatDong == id);
            if (thamGiaHoatDong == null)
            {
                return NotFound();
            }

            return View(thamGiaHoatDong);
        }

        // POST: ThamGiaHoatDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ThamGiaHoatDong == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ThamGiaHoatDong'  is null.");
            }
            var thamGiaHoatDong = await _context.ThamGiaHoatDong.FindAsync(id);
            if (thamGiaHoatDong != null)
            {
                _context.ThamGiaHoatDong.Remove(thamGiaHoatDong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThamGiaHoatDongExists(string id)
        {
          return (_context.ThamGiaHoatDong?.Any(e => e.MaThamGiaHoatDong == id)).GetValueOrDefault();
        }
    }
}
