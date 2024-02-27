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
    public class HospedagemsController : Controller
    {
        private readonly AgenciaFullContext _context;

        public HospedagemsController(AgenciaFullContext context)
        {
            _context = context;
        }

        // GET: Hospedagems
        public async Task<IActionResult> Index()
        {
              return _context.Hospedagem != null ? 
                          View(await _context.Hospedagem.ToListAsync()) :
                          Problem("Entity set 'AgenciaFullContext.Hospedagem'  is null.");
        }

        // GET: Hospedagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hospedagem == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospedagem == null)
            {
                return NotFound();
            }

            return View(hospedagem);
        }

        // GET: Hospedagems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hospedagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Destino,Hoteis,Entrada,Saida,Quarto,Viajantes")] Hospedagem hospedagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospedagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospedagem);
        }

        // GET: Hospedagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hospedagem == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagem.FindAsync(id);
            if (hospedagem == null)
            {
                return NotFound();
            }
            return View(hospedagem);
        }

        // POST: Hospedagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Destino,Hoteis,Entrada,Saida,Quarto,Viajantes")] Hospedagem hospedagem)
        {
            if (id != hospedagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospedagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospedagemExists(hospedagem.Id))
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
            return View(hospedagem);
        }

        // GET: Hospedagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hospedagem == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospedagem == null)
            {
                return NotFound();
            }

            return View(hospedagem);
        }

        // POST: Hospedagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hospedagem == null)
            {
                return Problem("Entity set 'AgenciaFullContext.Hospedagem'  is null.");
            }
            var hospedagem = await _context.Hospedagem.FindAsync(id);
            if (hospedagem != null)
            {
                _context.Hospedagem.Remove(hospedagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospedagemExists(int id)
        {
          return (_context.Hospedagem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
