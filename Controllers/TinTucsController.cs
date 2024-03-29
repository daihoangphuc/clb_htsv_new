using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using website_CLB_HTSV.Data;
using website_CLB_HTSV.Models;

namespace website_CLB_HTSV.Controllers
{
    public class TinTucsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TinTucsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Search(string keyword)
        {
            var searchResults = SearchNews(keyword);
            return PartialView("_NewsListPartial", searchResults);
        }

        private IEnumerable<TinTuc> SearchNews(string keyword)
        {
            // Thực hiện logic tìm kiếm và trả về kết quả
            // (đây chỉ là một ví dụ, bạn cần thay thế bằng logic thực tế của bạn)
            return _context.TinTuc.Where(t => t.TieuDe.Contains(keyword)).ToList();
        }
        // GET: TinTucs
        public IActionResult Index(string searchString)
        {
            var tinTuc = from m in _context.TinTuc
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                tinTuc = tinTuc.Where(s => s.TieuDe.Contains(searchString));
            }

            return View(tinTuc.ToList());
        }


        // GET: TinTucs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TinTuc == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTuc
                .Include(t => t.SinhVien)
                .FirstOrDefaultAsync(m => m.MaTinTuc == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }

        // GET: TinTucs/Create
        [Authorize(Roles = "Administrators")]
        public IActionResult Create()
        {
            ViewData["NguoiDang"] = new SelectList(_context.SinhVien, "MaSV", "MaSV");
            return View();
        }

        // POST: TinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Create([Bind("MaTinTuc,TieuDe,NoiDung,NgayDang,NguoiDang")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinTuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NguoiDang"] = new SelectList(_context.SinhVien, "MaSV", "MaSV", tinTuc.NguoiDang);
            return View(tinTuc);
        }

        // GET: TinTucs/Edit/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TinTuc == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTuc.FindAsync(id);
            if (tinTuc == null)
            {
                return NotFound();
            }
            ViewData["NguoiDang"] = new SelectList(_context.SinhVien, "MaSV", "MaSV", tinTuc.NguoiDang);
            return View(tinTuc);
        }

        // POST: TinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(string id, [Bind("MaTinTuc,TieuDe,NoiDung,NgayDang,NguoiDang")] TinTuc tinTuc)
        {
            if (id != tinTuc.MaTinTuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinTuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinTucExists(tinTuc.MaTinTuc))
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
            ViewData["NguoiDang"] = new SelectList(_context.SinhVien, "MaSV", "MaSV", tinTuc.NguoiDang);
            return View(tinTuc);
        }

        // GET: TinTucs/Delete/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TinTuc == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTuc
                .Include(t => t.SinhVien)
                .FirstOrDefaultAsync(m => m.MaTinTuc == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }

        // POST: TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TinTuc == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TinTuc'  is null.");
            }
            var tinTuc = await _context.TinTuc.FindAsync(id);
            if (tinTuc != null)
            {
                _context.TinTuc.Remove(tinTuc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinTucExists(string id)
        {
            return (_context.TinTuc?.Any(e => e.MaTinTuc == id)).GetValueOrDefault();
        }
    }
}