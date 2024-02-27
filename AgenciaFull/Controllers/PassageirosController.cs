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
    public class PassageirosController : Controller
    {
        private readonly AgenciaFullContext _context;

        public PassageirosController(AgenciaFullContext context)
        {
            _context = context;
        }

        // GET: Passageiros
        public async Task<IActionResult> Index()
        {
            var agenciaFullContext = _context.Passageiro.Include(p => p.Pacote);
            return View(await agenciaFullContext.ToListAsync());
        }

        // GET: Passageiros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passageiro == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiro
                .Include(p => p.Pacote)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passageiro == null)
            {
                return NotFound();
            }

            return View(passageiro);
        }

        // GET: Passageiros/Create
        public IActionResult Create()
        {
            ViewData["PacoteId"] = new SelectList(_context.Pacote, "Id", "Id");
            return View();
        }

        // POST: Passageiros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Endereco,Email,Telefone,PacoteId")] Passageiro passageiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passageiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacoteId"] = new SelectList(_context.Pacote, "Id", "Id", passageiro.PacoteId);
            return View(passageiro);
        }

        // GET: Passageiros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passageiro == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiro.FindAsync(id);
            if (passageiro == null)
            {
                return NotFound();
            }
            ViewData["PacoteId"] = new SelectList(_context.Pacote, "Id", "Id", passageiro.PacoteId);
            return View(passageiro);
        }

        // POST: Passageiros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Endereco,Email,Telefone,PacoteId")] Passageiro passageiro)
        {
            if (id != passageiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passageiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassageiroExists(passageiro.Id))
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
            ViewData["PacoteId"] = new SelectList(_context.Pacote, "Id", "Id", passageiro.PacoteId);
            return View(passageiro);
        }

        // GET: Passageiros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passageiro == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiro
                .Include(p => p.Pacote)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passageiro == null)
            {
                return NotFound();
            }

            return View(passageiro);
        }

        // POST: Passageiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passageiro == null)
            {
                return Problem("Entity set 'AgenciaFullContext.Passageiro'  is null.");
            }
            var passageiro = await _context.Passageiro.FindAsync(id);
            if (passageiro != null)
            {
                _context.Passageiro.Remove(passageiro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassageiroExists(int id)
        {
          return (_context.Passageiro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
