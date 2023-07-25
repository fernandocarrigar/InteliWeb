using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InteliWeb2.Controllers
{
    public class PublicacionesController : Controller
    {
        private readonly InteliWebContext _context;

        public PublicacionesController(InteliWebContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int seccion, int tppub, int user, int servicio, int archivo, int i, int r)
        {
            var publicac = _context.Publicaciones.Include(p => p.IdArchivoNavigation).Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdSeccionPublicacionNavigation).Include(p => p.IdTipoPublicacionNavigation).Include(p => p.IdServicioNavigation);

            ViewData["Archivos"] = new SelectList(_context.Archivos, "IdArchivo", "NombreArchivo");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["Seccion"] = new SelectList(_context.SeccionPublicaciones, "IdSeccionPublicacion", "SeccionPublicacion");
            ViewData["TipoPub"] = new SelectList(_context.TipoPublicaciones, "IdTipoPublicacion", "TipoPublicacion");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if((seccion == 0) && (tppub == 0) && (user == 0) && (servicio == 0) && (archivo == 0))
                {return View(await publicac.ToListAsync()); }
                else if((seccion != 0) && (tppub == 0) && (user == 0) && (servicio == 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdSeccionPublicacion == seccion).ToListAsync()); }
                else if((seccion == 0) && (tppub != 0) && (user == 0) && (servicio == 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).ToListAsync()); }
                else if ((seccion == 0) && (tppub == 0) && (user != 0) && (servicio == 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion == 0) && (tppub == 0) && (user == 0) && (servicio != 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdServicio == servicio).ToListAsync()); }
                else if ((seccion == 0) && (tppub == 0) && (user == 0) && (servicio == 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdArchivo == archivo).ToListAsync()); }
                else if ((seccion != 0) && (tppub != 0) && (user == 0) && (servicio == 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdSeccionPublicacion == seccion).ToListAsync()); }
                else if ((seccion != 0) && (tppub == 0) && (user != 0) && (servicio == 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion != 0) && (tppub == 0) && (user == 0) && (servicio != 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdServicio == servicio).ToListAsync()); }
                else if ((seccion != 0) && (tppub == 0) && (user == 0) && (servicio == 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdArchivo == archivo).Where(p => p.IdSeccionPublicacion == seccion).ToListAsync()); }
                else if ((seccion == 0) && (tppub != 0) && (user != 0) && (servicio == 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion == 0) && (tppub != 0) && (user == 0) && (servicio != 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdServicio == servicio).ToListAsync()); }
                else if ((seccion == 0) && (tppub != 0) && (user == 0) && (servicio == 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdArchivo == archivo).ToListAsync()); }
                else if ((seccion == 0) && (tppub == 0) && (user != 0) && (servicio != 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdServicio == servicio).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion == 0) && (tppub == 0) && (user != 0) && (servicio == 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdArchivo == archivo).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion == 0) && (tppub == 0) && (user == 0) && (servicio != 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdArchivo == archivo).Where(p => p.IdServicio == servicio).ToListAsync()); }
                else if ((seccion != 0) && (tppub != 0) && (user != 0) && (servicio == 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion != 0) && (tppub != 0) && (user == 0) && (servicio != 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdServicio == servicio).ToListAsync()); }
                else if ((seccion != 0) && (tppub != 0) && (user == 0) && (servicio == 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdArchivo == archivo).Where(p => p.IdSeccionPublicacion == seccion).ToListAsync()); }
                else if ((seccion != 0) && (tppub == 0) && (user != 0) && (servicio != 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdServicio == servicio).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion != 0) && (tppub == 0) && (user != 0) && (servicio == 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdArchivo == archivo).Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion != 0) && (tppub == 0) && (user == 0) && (servicio != 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdArchivo == archivo).Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdServicio == servicio).ToListAsync()); }
                else if ((seccion == 0) && (tppub != 0) && (user != 0) && (servicio != 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdServicio == servicio).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion == 0) && (tppub != 0) && (user != 0) && (servicio == 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdArchivo == archivo).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion == 0) && (tppub != 0) && (user == 0) && (servicio != 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdArchivo == archivo).Where(p => p.IdServicio == servicio).ToListAsync()); }
                else if ((seccion == 0) && (tppub == 0) && (user != 0) && (servicio != 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdArchivo == archivo).Where(p => p.IdServicio == servicio).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion != 0) && (tppub != 0) && (user != 0) && (servicio != 0) && (archivo == 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdServicio == servicio).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion != 0) && (tppub != 0) && (user != 0) && (servicio == 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdArchivo == archivo).Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion != 0) && (tppub != 0) && (user == 0) && (servicio != 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdArchivo == archivo).Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdServicio == servicio).ToListAsync()); }
                else if ((seccion != 0) && (tppub == 0) && (user != 0) && (servicio != 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdArchivo == archivo).Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdServicio == servicio).Where(p => p.IdUsuario == user).ToListAsync()); }
                else if ((seccion == 0) && (tppub != 0) && (user != 0) && (servicio != 0) && (archivo != 0))
                { return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdArchivo == archivo).Where(p => p.IdServicio == servicio).Where(p => p.IdUsuario == user).ToListAsync()); }
            }
            catch(Exception e) { }

            return View(await publicac.Where(p => p.IdTipoPublicacion == tppub).Where(p => p.IdArchivo == archivo).Where(p => p.IdSeccionPublicacion == seccion).Where(p => p.IdServicio == servicio).Where(p => p.IdUsuario == user).ToListAsync());
        }

        public IActionResult Create(int i, int r)
        {
            ViewData["Archivos"] = new SelectList(_context.Archivos, "IdArchivo", "NombreArchivo");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["Seccion"] = new SelectList(_context.SeccionPublicaciones, "IdSeccionPublicacion", "SeccionPublicacion");
            ViewData["TipoPub"] = new SelectList(_context.TipoPublicaciones, "IdTipoPublicacion", "TipoPublicacion");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, PublicacionesViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var publicac = new Publicacione()
                {
                    FechaPublicacion = DateTime.Now,
                    TextoPublicado = model.TxtPub,
                    IdArchivo = model.idArch,
                    IdTipoPublicacion = model.idTpPub,
                    IdSeccionPublicacion = model.idSecPub,
                    IdUsuario = model.idUser,
                    IdServicio = model.idServ
                };
                _context.Add(publicac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Publicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            ViewData["Archivos"] = new SelectList(_context.Archivos, "IdArchivo", "NombreArchivo", model.idArch);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario", model.idUser);
            ViewData["Seccion"] = new SelectList(_context.SeccionPublicaciones, "IdSeccionPublicacion", "SeccionPublicacion", model.idSecPub);
            ViewData["TipoPub"] = new SelectList(_context.TipoPublicaciones, "IdTipoPublicacion", "TipoPublicacion", model.idTpPub);
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio", model.idServ);
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, PublicacionesViewModel model)
        {
            var updPub = _context.Publicaciones.Find(Id);
            if(updPub != null)
            {
                model.IdPub = updPub.IdPublicacion;
                model.FecPub = updPub.FechaPublicacion;
                model.idArch = updPub.IdArchivo;
                model.TxtPub = updPub.TextoPublicado;
                model.idTpPub = updPub.IdTipoPublicacion;
                model.idSecPub = updPub.IdSeccionPublicacion;
                model.idUser = updPub.IdUsuario;
                model.idServ = updPub.IdServicio;
            }

            ViewData["Publicacion"] = new SelectList(_context.Publicaciones, "IdPublicacion", "FechaPublicacion").SelectedValue;
            ViewData["Archivo"] = new SelectList(_context.Archivos, "IdArchivo", "NombreArchivo");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["Seccion"] = new SelectList(_context.SeccionPublicaciones, "IdSeccionPublicacion", "SeccionPublicacion");
            ViewData["TipoPub"] = new SelectList(_context.TipoPublicaciones, "IdTipoPublicacion", "TipoPublicacion");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            ViewData["TipoArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, PublicacionesViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var updPub = _context.Publicaciones.Find(model.IdPub);
                if(updPub != null)
                {
                    updPub.FechaPublicacion = DateTime.Now;
                    updPub.IdArchivo = model.idArch;
                    updPub.TextoPublicado = model.TxtPub;
                    updPub.IdTipoPublicacion = model.idTpPub;
                    updPub.IdSeccionPublicacion = model.idSecPub;
                    updPub.IdUsuario = model.idUser;
                    updPub.IdServicio = model.idServ;
                }
                _context.Update(updPub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Publicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            ViewData["Publicacion"] = new SelectList(_context.Publicaciones, "IdPublicacion", "FechaPublicacion").SelectedValue;
            ViewData["Archivo"] = new SelectList(_context.Archivos, "IdArchivo", "NombreArchivo");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["Seccion"] = new SelectList(_context.SeccionPublicaciones, "IdSeccionPublicacion", "SeccionPublicacion");
            ViewData["TipoPub"] = new SelectList(_context.TipoPublicaciones, "IdTipoPublicacion", "TipoPublicacion");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            ViewData["TipoArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1");
            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;
            try
            {
                var delPub = _context.Publicaciones.Find(Id);
                if(delPub != null)
                {
                    _context.Remove(delPub);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Publicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Publicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }
    }
}
