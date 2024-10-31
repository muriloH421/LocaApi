using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocaApi.Data;
using LocaApi.Models;

namespace LocaApi.Controllers
{
    public class PatiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patio.ToListAsync());
        }

        // GET: Patios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patio = await _context.Patio
                .FirstOrDefaultAsync(m => m.id == id);
            if (patio == null)
            {
                return NotFound();
            }

            return View(patio);
        }

        // GET: Patios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome")] Patio patio)
        {
            if (ModelState.IsValid)
            {
                patio.id = Guid.NewGuid();
                _context.Add(patio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patio);
        }

        // GET: Patios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patio = await _context.Patio.FindAsync(id);
            if (patio == null)
            {
                return NotFound();
            }
            return View(patio);
        }

        // POST: Patios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,nome")] Patio patio)
        {
            if (id != patio.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatioExists(patio.id))
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
            return View(patio);
        }

        // GET: Patios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patio = await _context.Patio
                .FirstOrDefaultAsync(m => m.id == id);
            if (patio == null)
            {
                return NotFound();
            }

            return View(patio);
        }

        // POST: Patios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var patio = await _context.Patio.FindAsync(id);
            if (patio != null)
            {
                _context.Patio.Remove(patio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatioExists(Guid id)
        {
            return _context.Patio.Any(e => e.id == id);
        }
    }
}
