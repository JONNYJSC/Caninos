using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebEnacal2.Models;

namespace WebEnacal2.Controllers
{
    public class CaninosController : Controller
    {
        private readonly dbContextCanino _context;

        public CaninosController(dbContextCanino context)
        {
            _context = context;
        }

        // GET: Caninos
        public async Task<ActionResult<IEnumerable<Canino>>> Index()
        {
            return View(await _context.Caninos.FromSqlRaw("GetCaninos").ToListAsync());
        }

        // GET: Caninos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canino = await _context.Caninos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (canino == null)
            {
                return NotFound();
            }

            return View(canino);
        }

        // GET: Caninos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caninos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCanino,Raza,EdadCanina")] Canino canino)
        {
            if (ModelState.IsValid)
            {
                CaninosDAL cd = new CaninosDAL();
                await cd.CreateMetodo(canino);
                return RedirectToAction(nameof(Index));
            }
            return View(canino);
        }

        // GET: Caninos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canino = await _context.Caninos.FindAsync(id);
            if (canino == null)
            {
                return NotFound();
            }
            return View(canino);
        }

        // POST: Caninos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCanino,Raza,EdadCanina")] Canino canino)
        {
            if (id != canino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CaninosDAL cd = new CaninosDAL();
                    await cd.EditMetodo(id, canino);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaninoExists(canino.Id))
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
            return View(canino);
        }

        // GET: Caninos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canino = await _context.Caninos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (canino == null)
            {
                return NotFound();
            }

            return View(canino);
        }

        // POST: Caninos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CaninosDAL cd = new CaninosDAL();
            await cd.DeleteMetodo(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CaninoExists(int id)
        {
            return _context.Caninos.Any(e => e.Id == id);
        }
    }
}
