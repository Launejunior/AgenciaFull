using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaFull.Data;
using AgenciaFull.Models;

namespace AgenciaFull.Controllers
{
    public class PacotesController : Controller
    {
        private readonly AgenciaFullContext _context;

        public PacotesController(AgenciaFullContext context)
        {
            _context = context;
        }

        // GET: Pacotes
        public async Task<IActionResult> Index()
        {
              return _context.Pacote != null ? 
                          View(await _context.Pacote.ToListAsync()) :
                          Problem("Entity set 'AgenciaFullContext.Pacote'  is null.");
        }

        // GET: Pacotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacote == null)
            {
                return NotFound();
            }

            var pacote = await _context.Pacote
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacote == null)
            {
                return NotFound();
            }

            return View(pacote);
        }

        // GET: Pacotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Origem,Destino,Ida,Volta,Quarto,Viajantes")] Pacote pacote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacote);
        }

        // GET: Pacotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pacote == null)
            {
                return NotFound();
            }

            var pacote = await _context.Pacote.FindAsync(id);
            if (pacote == null)
            {
                return NotFound();
            }
            return View(pacote);
        }

        // POST: Pacotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Origem,Destino,Ida,Volta,Quarto,Viajantes")] Pacote pacote)
        {
            if (id != pacote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacoteExists(pacote.Id))
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
            return View(pacote);
        }

        // GET: Pacotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacote == null)
            {
                return NotFound();
            }

            var pacote = await _context.Pacote
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacote == null)
            {
                return NotFound();
            }

            return View(pacote);
        }

        // POST: Pacotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacote == null)
            {
                return Problem("Entity set 'AgenciaFullContext.Pacote'  is null.");
            }
            var pacote = await _context.Pacote.FindAsync(id);
            if (pacote != null)
            {
                _context.Pacote.Remove(pacote);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacoteExists(int id)
        {
          return (_context.Pacote?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
