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
    public class LocacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Locacoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Locacao.Include(l => l.Cliente).Include(l => l.Veiculo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Locacoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacao
                .Include(l => l.Cliente)
                .Include(l => l.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // GET: Locacoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "Id", "Id");
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Id");
            return View();
        }

        // POST: Locacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datalocacao,DataDevoluçao,VeiculoId,ClienteId")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                locacao.Id = Guid.NewGuid();
                _context.Add(locacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "Id", "Id", locacao.ClienteId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Id", locacao.VeiculoId);
            return View(locacao);
        }

        // GET: Locacoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacao.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "Id", "Id", locacao.ClienteId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Id", locacao.VeiculoId);
            return View(locacao);
        }

        // POST: Locacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Datalocacao,DataDevoluçao,VeiculoId,ClienteId")] Locacao locacao)
        {
            if (id != locacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocacaoExists(locacao.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "Id", "Id", locacao.ClienteId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Id", locacao.VeiculoId);
            return View(locacao);
        }

        // GET: Locacoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacao
                .Include(l => l.Cliente)
                .Include(l => l.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // POST: Locacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var locacao = await _context.Locacao.FindAsync(id);
            if (locacao != null)
            {
                _context.Locacao.Remove(locacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocacaoExists(Guid id)
        {
            return _context.Locacao.Any(e => e.Id == id);
        }
    }
}
