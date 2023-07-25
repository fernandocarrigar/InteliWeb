using InteliWeb2.Models.ViewModels;
using InteliWeb2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InteliWeb2.Controllers
{
    public class RolUsuariosController : Controller
    {
        private readonly InteliWebContext _context;

        public RolUsuariosController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int search, int i, int r)
        {
            ViewData["RolUsuarios"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if(search == null || search == 0)
                {
                    return View(await _context.RolUsuarios.ToListAsync());
                }
            }catch(Exception e) { }

            return View(await _context.RolUsuarios.Where(ru => ru.IdRolUsuario == search).ToListAsync());
        }
        public IActionResult Create(int i, int r)
        {
            ViewData["RolUsuarios"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, RolUsuariosViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var rolusuario = new RolUsuario()
                {
                    IdRolUsuario = model.IdRol,
                    RolUsuario1 = model.Rol
                };
                _context.Add(rolusuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "RolUsuarios", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            ViewData["RolUsuarios"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1");
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, RolUsuariosViewModel model)
        {
            var updUser = _context.RolUsuarios.Find(Id);
            if(updUser != null)
            {
                model.IdRol = updUser.IdRolUsuario;
                model.Rol = updUser.RolUsuario1;
            }
            ViewData["RolUser"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1", model.Rol).SelectedValue;
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, RolUsuariosViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var updUser = _context.RolUsuarios.Find(model.IdRol);
                if(updUser != null)
                {
                    updUser.RolUsuario1 = model.Rol;
                }
                _context.Update(updUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "RolUsuarios", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            ViewData["RolUSer"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1", model.IdRol).SelectedValue;
            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                var delRolUser = _context.RolUsuarios.Find(Id);
                if(delRolUser != null)
                {
                    _context.Remove(delRolUser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "RolUsuarios", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "RolUsuarios", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }
    }
}
