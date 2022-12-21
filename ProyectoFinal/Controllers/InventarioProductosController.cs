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
    public class InventarioProductosController : Controller
    {
        private readonly BDContext _context;

        public InventarioProductosController(BDContext context)
        {
            _context = context;
        }

        // GET: InventarioProductos
        public async Task<IActionResult> Index()
        {
            var bDContext = _context.InventarioProductos.Include(i => i.IdProductoNavigation);
            return View(await bDContext.ToListAsync());
        }

        // GET: InventarioProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InventarioProductos == null)
            {
                return NotFound();
            }

            var inventarioProducto = await _context.InventarioProductos
                .Include(i => i.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventarioProducto == null)
            {
                return NotFound();
            }

            return View(inventarioProducto);
        }

        // GET: InventarioProductos/Create
        public IActionResult Create()
        {
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreProducto");
            return View();
        }

        // POST: InventarioProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProducto,CantidadDisponible")] InventarioProducto inventarioProducto)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(inventarioProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreProducto", inventarioProducto.IdProducto);
            //return View(inventarioProducto);
        }

        // GET: InventarioProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InventarioProductos == null)
            {
                return NotFound();
            }

            var inventarioProducto = await _context.InventarioProductos.FindAsync(id);
            if (inventarioProducto == null)
            {
                return NotFound();
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreProducto", inventarioProducto.IdProducto);
            return View(inventarioProducto);
        }

        // POST: InventarioProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProducto,CantidadDisponible")] InventarioProducto inventarioProducto)
        {
            if (id != inventarioProducto.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(inventarioProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioProductoExists(inventarioProducto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreProducto", inventarioProducto.IdProducto);
            //return View(inventarioProducto);
        }

        // GET: InventarioProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InventarioProductos == null)
            {
                return NotFound();
            }

            var inventarioProducto = await _context.InventarioProductos
                .Include(i => i.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventarioProducto == null)
            {
                return NotFound();
            }

            return View(inventarioProducto);
        }

        // POST: InventarioProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InventarioProductos == null)
            {
                return Problem("Entity set 'BDContext.InventarioProductos'  is null.");
            }
            var inventarioProducto = await _context.InventarioProductos.FindAsync(id);
            if (inventarioProducto != null)
            {
                _context.InventarioProductos.Remove(inventarioProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioProductoExists(int id)
        {
          return _context.InventarioProductos.Any(e => e.Id == id);
        }
    }
}
