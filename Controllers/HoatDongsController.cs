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
    public class HoatDongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoatDongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoatDongs
        public async Task<IActionResult> Index()
        {
              return _context.HoatDong != null ? 
                          View(await _context.HoatDong.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HoatDong'  is null.");
        }

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
        public async Task<IActionResult> Create([Bind("MaHoatDong,TenHoatDong,MoTa,ThoiGian,DiaDiem,HocKy,NamHoc,TrangThai")] HoatDong hoatDong)
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
        public async Task<IActionResult> Edit(string id, [Bind("MaHoatDong,TenHoatDong,MoTa,ThoiGian,DiaDiem,HocKy,NamHoc,TrangThai")] HoatDong hoatDong)
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
