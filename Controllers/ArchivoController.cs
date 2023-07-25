using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Mime;

namespace InteliWeb2.Controllers
{
    public class ArchivoController : Controller
    {
        private readonly InteliWebContext _context;

        public ArchivoController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int tparch, int user, int i, int r)
        {
            var archivos = _context.Archivos.Include(a => a.IdTipoArchivoNavigation).Include(a => a.IdUsuarioNavigation);
            ViewData["TpArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if ((tparch == 0) && (user == 0))
                { return View(await archivos.ToListAsync()); }
                else if ((tparch != 0) && (user != 0))
                {return View(await archivos.Where(a => a.IdTipoArchivo == tparch).Where(a => a.IdUsuario == user).ToListAsync());}
                else if ((tparch != 0) && (user == 0))
                {return View(await archivos.Where(a => a.IdTipoArchivo == tparch).ToListAsync());}
                else if((tparch == 0) && (user != 0))
                {return View(await archivos.Where(a => a.IdUsuario == user).ToListAsync());}

            }catch(Exception e) { }

            return View(await archivos.Where(a => a.IdTipoArchivo == tparch).Where(a => a.IdUsuario == user).ToListAsync());
        }

        public IActionResult Create(int i, int r)
        {
            ViewData["TpArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, ArchivoViewModel model, IFormFile ContArchivo)
        {
            var fileOpen = ContArchivo.OpenReadStream();
            ViewData["i"] = i;
            ViewData["r"] = r;

            model.mimeArc = Convert.ToString(ContArchivo.ContentType);
            model.NameArchivo = Convert.ToString(ContArchivo.FileName);

            using (MemoryStream fileTemp = new MemoryStream())
            {
                fileOpen.CopyTo(fileTemp);
                model.ContArchivo = fileTemp.ToArray();
            }

            if (ModelState.IsValid)
            {

                var archivos = new Archivo()
                {
                    ContenidoArchivo = model.ContArchivo,
                    MimeArchivo = model.mimeArc,
                    NombreArchivo = model.NameArchivo,
                    FechaSubido = DateTime.Now,
                    IdTipoArchivo = model.TpArchivo,
                    IdUsuario = model.User
                };
                _context.Add(archivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Archivo", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            ViewData["TpArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1", model.TpArchivo);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario", model.User);
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, ArchivoViewModel model)
        {
            var updArc = _context.Archivos.Find(Id);
            if(updArc != null)
            {
                model.IdArchivo = updArc.IdArchivo;
                model.ContArchivo = updArc.ContenidoArchivo;
                model.mimeArc = updArc.MimeArchivo;
                model.NameArchivo = updArc.NombreArchivo;
                model.FecArchivo = updArc.FechaSubido;
                model.TpArchivo = updArc.IdTipoArchivo;
                model.User = updArc.IdUsuario;
            }

            ViewData["Archivos"] = new SelectList(_context.Archivos, "IdArchivo", "NombreArchivo").SelectedValue;
            ViewData["TpArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, ArchivoViewModel model, IFormFile ContArchivo)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            var fileOpen = ContArchivo.OpenReadStream();
            model.mimeArc = ContArchivo.ContentType;
            model.NameArchivo = ContArchivo.FileName;

            using (MemoryStream fileTemp = new MemoryStream())
            {
                fileOpen.CopyTo(fileTemp);
                model.ContArchivo = fileTemp.ToArray();
            }

            if(ModelState.IsValid)
            {
                var updArc = _context.Archivos.Find(model.IdArchivo);
                if(updArc != null)
                {
                    updArc.ContenidoArchivo = model.ContArchivo;
                    updArc.MimeArchivo = model.mimeArc;
                    updArc.NombreArchivo = model.NameArchivo;
                    updArc.FechaSubido = DateTime.Now;
                    updArc.IdTipoArchivo = model.TpArchivo;
                    updArc.IdUsuario = model.User;
                }
                _context.Update(updArc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Archivo", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            ViewData["Archivos"] = new SelectList(_context.Archivos, "IdArchivo", "NombreArchivo", model.IdArchivo).SelectedValue;
            ViewData["TpArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            try
            {
                var delArch = _context.Archivos.Find(Id);
                if(delArch != null)
                {
                    _context.Remove(delArch);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Archivo", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }catch(Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Archivo", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            return View();
        }
    }
}
