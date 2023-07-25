using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InteliWeb2.Controllers
{
    public class ContactosController : Controller
    {
        private readonly InteliWebContext _context;

        public ContactosController(InteliWebContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int Id, int i, int r)
        {
            var contact = _context.Contactos.Include(c => c.IdUsuarioNavigation);
            ViewData["Usuarios"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["i"] = i;
            ViewData["r"] = r;
            
            try
            {
                if(Id == 0 || Id.Equals(null))
                {
                    return View(await contact.ToListAsync());
                }
            }
            catch (Exception e) { }

            return View(await contact.Where(c => c.IdUsuario == Id).ToListAsync());
        }

        public IActionResult Create(int Id, int i, int r, ContactosViewModel model)
        {
            model.idUser = Id;
            ViewData["Usuarios"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["r"] = r;
            ViewData["i"] = i;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, ContactosViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var contact = new Contacto()
                {
                    IdContacto = model.idContact,
                    TelefonoContacto = model.TelContact,
                    CorreoContacto = model.EmailContact,
                    UbicacionContacto = model.UbiContact,
                    IdUsuario = model.idUser
                };
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary( new { Controller = "Contactos", Action = "Index", Id = model.idUser, i = $"{i}", r = $"{r}"} ) );
            }

            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario", model.idUser);
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, ContactosViewModel model)
        {
            var updContact = _context.Contactos.Find(Id);
            if(updContact != null)
            {
                model.idContact = updContact.IdContacto;
                model.TelContact = updContact.TelefonoContacto;
                model.EmailContact = updContact.CorreoContacto;
                model.UbiContact = updContact.UbicacionContacto;
                model.idUser = updContact.IdUsuario;
            }

            ViewData["Contacto"] = new SelectList(_context.Contactos, "IdContacto", "CorreoContacto").SelectedValue;
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, ContactosViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var updContact = _context.Contactos.Find(model.idContact);
                if(updContact != null)
                {
                    updContact.TelefonoContacto = model.TelContact;
                    updContact.CorreoContacto = model.EmailContact;
                    updContact.UbicacionContacto = model.UbiContact;
                    updContact.IdUsuario = model.idUser;
                }
                _context.Update(updContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Contactos", Action = "Index", Id = model.idUser, i = $"{i}", r = $"{r}"}));
            }
            ViewData["Contacto"] = new SelectList(_context.Contactos, "IdContacto", "CorreoContacto").SelectedValue;
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            return View(model);

        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                var delContact = _context.Contactos.Find(Id);
                if(delContact != null)
                {
                    _context.Remove(delContact);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Contactos", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Contactos", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }
    }
}
