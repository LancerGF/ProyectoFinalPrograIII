using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [Authorize]
    public class TiposProductoController : Controller
    {
        private readonly BDContext _context;

        public TiposProductoController(BDContext context)
        {
            _context = context;
        }

        // GET: TiposProducto
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoProductos.ToListAsync());
        }

        // GET: TiposProducto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoProductos == null)
            {
                return NotFound();
            }

            var tipoProducto = await _context.TipoProductos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            return View(tipoProducto);
        }

        // GET: TiposProducto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposProducto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo")] TipoProducto tipoProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProducto);
        }

        // GET: TiposProducto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoProductos == null)
            {
                return NotFound();
            }

            var tipoProducto = await _context.TipoProductos.FindAsync(id);
            if (tipoProducto == null)
            {
                return NotFound();
            }
            return View(tipoProducto);
        }

        // POST: TiposProducto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo")] TipoProducto tipoProducto)
        {
            if (id != tipoProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProductoExists(tipoProducto.Id))
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
            return View(tipoProducto);
        }

        // GET: TiposProducto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoProductos == null)
            {
                return NotFound();
            }

            var tipoProducto = await _context.TipoProductos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            return View(tipoProducto);
        }

        // POST: TiposProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoProductos == null)
            {
                return Problem("Entity set 'BDContext.TipoProductos'  is null.");
            }
            var tipoProducto = await _context.TipoProductos.FindAsync(id);
            if (tipoProducto != null)
            {
                _context.TipoProductos.Remove(tipoProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProductoExists(int id)
        {
          return _context.TipoProductos.Any(e => e.Id == id);
        }
    }
}
