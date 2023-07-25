using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace InteliWeb2.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly InteliWebContext _context;

        public UsuarioController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int rol, string empresa, int i, int r)
        {
            var usuarios = _context.Usuarios.Include(u => u.IdRolUsuarioNavigation);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "EmpresaUsuario", "EmpresaUsuario");
            ViewData["RolUsuario"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if((rol == null || rol == 0) && (empresa.IsNullOrEmpty()))
                {
                    return View(await usuarios.ToListAsync());

                }else if ((rol == null || rol == 0) && (!empresa.IsNullOrEmpty()))
                {
                    return View(await usuarios.Where(u => u.EmpresaUsuario == empresa).ToListAsync());

                }else if((rol != null || rol != 0) && (empresa.IsNullOrEmpty()))
                {
                    return View(await usuarios.Where(u => u.IdRolUsuario == rol).ToListAsync());
                }
            }catch(Exception e) { }

            return View(await usuarios.Where(u => u.IdRolUsuario == rol).Where(u => u.EmpresaUsuario == empresa).ToListAsync());
        }

        public IActionResult Create(int i, int r)
        {
            ViewData["RolUsuario"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, UsuariosViewModel model)
        {
            ViewData["RolUsuario"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1", model.IdRol);
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var CompCorreo = _context.Usuarios.Where(u => u.CorreUsuario == model.Email).FirstOrDefault();
                if ((CompCorreo?.CorreUsuario != model.Email) || (CompCorreo?.CorreUsuario == null))
                {
                    if (model.IdRol == null)
                    {
                        var usuarios = new Usuario()
                        {
                            NombreUsuario = model.Name,
                            ApPatUsuario = model.ApName,
                            ApMatUsuario = model.AmName,
                            CorreUsuario = model.Email,
                            TelefonoUsuario = model.Phone,
                            IdRolUsuario = 3,
                            ContraUsuario = model.Password,
                            EmpresaUsuario = model.Empresa
                        };
                        _context.Add(usuarios);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Login", "Sesion");

                    }
                    else
                    {
                        var usuarios = new Usuario()
                        {
                            NombreUsuario = model.Name,
                            ApPatUsuario = model.ApName,
                            ApMatUsuario = model.AmName,
                            CorreUsuario = model.Email,
                            TelefonoUsuario = model.Phone,
                            IdRolUsuario = model.IdRol,
                            ContraUsuario = model.Password,
                            EmpresaUsuario = model.Empresa
                        };
                        _context.Add(usuarios);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Usuario", Action = "Index", r = $"{r}", i = $"{i}"}));
                    }
                }
                else if(CompCorreo.CorreUsuario == model.Email)
                {
                    ViewData["CompCorreo"] = "El correo ya esta registrado";
                }
            }
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, UsuariosViewModel model)
        {
            var updUser = _context.Usuarios.Find(Id);
            if(updUser != null)
            {
                model.IdUsuario = updUser.IdUsuario;
                model.Name = updUser.NombreUsuario;
                model.ApName = updUser.ApPatUsuario;
                model.AmName = updUser.ApMatUsuario;
                model.Email = updUser.CorreUsuario;
                model.Phone = updUser.TelefonoUsuario;
                model.IdRol = updUser.IdRolUsuario;
                model.Password = updUser.ContraUsuario;
                model.Empresa = updUser.EmpresaUsuario;
            }
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario").SelectedValue;
            ViewData["RolUsuario"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, UsuariosViewModel model)
        {
            if (ModelState.IsValid)
            {
                var updUser = _context.Usuarios.Find(model.IdUsuario);
                if(updUser != null)
                {
                    updUser.NombreUsuario = model.Name;
                    updUser.ApPatUsuario = model.ApName;
                    updUser.ApMatUsuario = model.AmName;
                    updUser.CorreUsuario = model.Email;
                    updUser.TelefonoUsuario = model.Phone;
                    updUser.IdRolUsuario = model.IdRol;
                    updUser.ContraUsuario = model.Password;
                    updUser.EmpresaUsuario = model.Empresa;
                }
                _context.Update(updUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Usuario", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario").SelectedValue;
            ViewData["RolUsuario"] = new SelectList(_context.RolUsuarios, "IdRolUsuario", "RolUsuario1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {

            try
            {
                var delUser = _context.Usuarios.Find(Id);
                if(delUser != null)
                {
                    var countCont = _context.Contactos.Where(c => c.IdUsuario == Id).Count();
                    var delCont = _context.Contactos.Where(c => c.IdUsuario == Id).FirstOrDefault();
                    
                    if (delCont != null)
                    {
                        for(int x = 0; x < countCont; x++)
                        {
                            _context.Remove(delCont);
                            await _context.SaveChangesAsync();
                        }
                    }
                    _context.Remove(delUser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Usuario", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                ViewData["errorDelete"] = "Valor no encontrado";
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Usuario", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }
    }
}
