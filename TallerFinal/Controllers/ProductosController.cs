using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerFinal.ClasesDTO;
using TallerFinal.Datos;
using TallerFinal.Models;

namespace TallerFinal.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> ListaDeProductos()
        {
            await using (_context)
            {
                IEnumerable<ProductosDTO> ListaDeProductos =
                    (from Productos in _context.Productos
                     join Categorias in _context.Categorias
                        on Productos.Categoria equals
                        Categorias.IdCategoria
                     select new ProductosDTO
                     {
                         IdProducto = Productos.IdProducto,
                         Codigo = Productos.Codigo,
                         NombreProducto = Productos.NombreProducto,
                         ValorUnitario = Productos.ValorUnitario,
                         Iva = Productos.Iva,
                         Cantidad = Productos.Cantidad,
                         Fecha = Productos.Fecha,
                         Categoria = Categorias.NombreCategoria,
                         Estado = Productos.Estado,

                     }).ToList();

                return View(ListaDeProductos);
            }
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdProducto,Codigo,NombreProducto,ValorUnitario,Iva,Cantidad,Fecha,Categoria,Estado")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListaDeProductos));
            }
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdProducto,Codigo,NombreProducto,ValorUnitario,Iva,Cantidad,Fecha,Categoria,Estado")] Productos productos)
        {
            if (id != productos.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.IdProducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListaDeProductos));
            }
            return View(productos);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListaDeProductos));
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
