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
    public class PassagensController : Controller
    {
        private readonly AgenciaFullContext _context;

        public PassagensController(AgenciaFullContext context)
        {
            _context = context;
        }

        // GET: Passagens
        public async Task<IActionResult> Index()
        {
              return _context.Passagem != null ? 
                          View(await _context.Passagem.ToListAsync()) :
                          Problem("Entity set 'AgenciaFullContext.Passagem'  is null.");
        }

        // GET: Passagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passagem == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // GET: Passagens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Origem,Destino,Ida,Volta,Viajantes")] Passagem passagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passagem);
        }

        // GET: Passagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passagem == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }
            return View(passagem);
        }

        // POST: Passagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Origem,Destino,Ida,Volta,Viajantes")] Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassagemExists(passagem.Id))
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
            return View(passagem);
        }

        // GET: Passagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passagem == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // POST: Passagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passagem == null)
            {
                return Problem("Entity set 'AgenciaFullContext.Passagem'  is null.");
            }
            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem != null)
            {
                _context.Passagem.Remove(passagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassagemExists(int id)
        {
          return (_context.Passagem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
