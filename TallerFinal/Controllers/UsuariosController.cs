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
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> ListaDeUsuario()
        {
            await using (_context)
            {
                IEnumerable<UsuariosDto> listaDeUsuarios =
                    (from Usuarios in _context.Usuarios
                     join Roles in _context.Roles
                        on Usuarios.Rol equals
                        Roles.IdRol
                        select new UsuariosDto
                        {
                            IdUsuario = Usuarios.IdUsuario,
                            Documento = Usuarios.Documento,
                            Nombre = Usuarios.Nombre,
                            Apellidos = Usuarios.Apellidos,
                            Celular = Usuarios.Celular,
                            Email = Usuarios.Email,
                            NombreRol = Roles.NombreRol,                           
                        }).ToList();
                return View(listaDeUsuarios);
            }
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdUsuario,Documento,Nombre,Apellidos,Celular,Email,Rol")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListaDeUsuario));
            }
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdUsuario,Documento,Nombre,Apellidos,Celular,Email,Rol")] Usuarios usuarios)
        {
            if (id != usuarios.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.IdUsuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListaDeUsuario));
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListaDeUsuario));
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
