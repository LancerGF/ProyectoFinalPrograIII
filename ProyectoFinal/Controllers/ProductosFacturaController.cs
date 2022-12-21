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
    public class ProductosFacturaController : Controller
    {
        private readonly BDContext _context;

        public ProductosFacturaController(BDContext context)
        {
            _context = context;
        }

        // GET: ProductosFactura
        public async Task<IActionResult> Index()
        {
            var bDContext = _context.ProductosFacturas.Include(p => p.IdFacturaNavigation).Include(p => p.IdProductoNavigation);
            return View(await bDContext.ToListAsync());
        }

        // GET: ProductosFactura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductosFacturas == null)
            {
                return NotFound();
            }

            var productosFactura = await _context.ProductosFacturas
                .Include(p => p.IdFacturaNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productosFactura == null)
            {
                return NotFound();
            }

            return View(productosFactura);
        }

        // GET: ProductosFactura/Create
        public IActionResult Create()
        {
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreProducto");
            return View();
        }

        // POST: ProductosFactura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProducto,IdFactura,Cantidad")] ProductosFactura productosFactura)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(productosFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id", productosFactura.IdFactura);
            //ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreProducto", productosFactura.IdProducto);
            //return View(productosFactura);
        }

        // GET: ProductosFactura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductosFacturas == null)
            {
                return NotFound();
            }

            var productosFactura = await _context.ProductosFacturas.FindAsync(id);
            if (productosFactura == null)
            {
                return NotFound();
            }
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id", productosFactura.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreProducto", productosFactura.IdProducto);
            return View(productosFactura);
        }

        // POST: ProductosFactura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProducto,IdFactura,Cantidad")] ProductosFactura productosFactura)
        {
            if (id != productosFactura.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(productosFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosFacturaExists(productosFactura.Id))
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
            //ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id", productosFactura.IdFactura);
            //ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreProducto", productosFactura.IdProducto);
            //return View(productosFactura);
        }

        // GET: ProductosFactura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductosFacturas == null)
            {
                return NotFound();
            }

            var productosFactura = await _context.ProductosFacturas
                .Include(p => p.IdFacturaNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productosFactura == null)
            {
                return NotFound();
            }

            return View(productosFactura);
        }

        // POST: ProductosFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductosFacturas == null)
            {
                return Problem("Entity set 'BDContext.ProductosFacturas'  is null.");
            }
            var productosFactura = await _context.ProductosFacturas.FindAsync(id);
            if (productosFactura != null)
            {
                _context.ProductosFacturas.Remove(productosFactura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosFacturaExists(int id)
        {
          return _context.ProductosFacturas.Any(e => e.Id == id);
        }
    }
}
