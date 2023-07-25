using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace InteliWeb2.Controllers
{
    public class SesionController : Controller
    {
        private readonly InteliWebContext _context;

        public SesionController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string correo, string contraseña, int i, int r)
        {
            if ((!correo.IsNullOrEmpty()) && (!contraseña.IsNullOrEmpty()))
            {
                var user = _context.Usuarios.Include(u => u.IdRolUsuarioNavigation).Where(u => u.CorreUsuario == correo).Where(u => u.ContraUsuario == contraseña);
                ViewData["RolUsuario"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1");

                if (user == null)
                {
                    return RedirectToAction(nameof(Login), "Sesion");
                }

                return View(await user.ToListAsync());

            }
            else if((!i.Equals(null)) && (!r.Equals(null)))
            {
                var user = _context.Usuarios.Include(u => u.IdRolUsuarioNavigation).Where(u => u.IdUsuario == i).Where(u => u.IdRolUsuario == r);
                ViewData["RolUsuario"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1");

                return View(await user.ToListAsync());
            }
            return RedirectToAction(nameof(Index), "Home");
        }


        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if((!string.IsNullOrEmpty(model.LoginCorreo)) && (!string.IsNullOrEmpty(model.LoginContraseña)))
                {
                    var validation = _context.Usuarios.Include(u=>u.IdRolUsuarioNavigation).Where(u => u.CorreUsuario == model.LoginCorreo).Where(u => u.ContraUsuario == model.LoginContraseña).ToListAsync();

                    if(validation != null)
                    {

                        return RedirectToAction(nameof(Index), new RouteValueDictionary(new {Controller = "Sesion", Action ="Index", correo = $"{model.LoginCorreo}", contraseña = $"{model.LoginContraseña}"}));
                    }
                }
            }
            return View(model);
        }

        public RedirectToActionResult Close()
        {
            return RedirectToAction(nameof(Login), "Sesion");
        }
    }
}
