using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InteliWeb2.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly InteliWebContext _context;

        public ServiciosController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int tpserv, int user, int i, int r)
        {
            var servicios = _context.Servicios.Include(s => s.IdTipoServicioNavigation);
            ViewData["TipoServ"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if ((tpserv == null || tpserv == 0) && (user == null || user == 0))
                {
                    return View(await servicios.ToListAsync());

                }else if((tpserv == null || tpserv == 0) && (user != null || user != 0))
                {
                    return View(await servicios.Where(s => s.IdUsuario == user).ToListAsync());

                }else if((tpserv != null || tpserv != 0) && (user == null || user == 0))
                {
                    return View(await servicios.Where(s => s.IdTipoServicio == tpserv).ToListAsync());
                }
            }catch(Exception e) { }

            return View(await servicios.Where(s => s.IdUsuario == user).Where(s => s.IdTipoServicio == tpserv).ToListAsync());
        }

        public IActionResult Create(int i, int r)
        {
            ViewData["TipoServ"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, ServiciosViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var servicios = new Servicio()
                {
                    NombreServicio = model.NameServ,
                    PrecioServicio = model.PrecioServ,
                    Ubicacion = model.UbiServ,
                    FechaRealizacion = model.FecRealizar,
                    FechaTerminacion = model.FecTerm,
                    IdUsuario = model.idUser,
                    IdTipoServicio = model.IdTipoServ
                };
                _context.Add(servicios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Servicios", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            ViewData["TipoServ"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1", model.IdTipoServ);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario", model.idUser);
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, ServiciosViewModel model)
        {
            var updServ = _context.Servicios.Find(Id);
            if(updServ != null)
            {
                model.IdServ = updServ.IdServicio;
                model.NameServ = updServ.NombreServicio;
                model.PrecioServ = updServ.PrecioServicio;
                model.UbiServ = updServ.Ubicacion;
                model.FecRealizar = updServ.FechaRealizacion;
                model.FecTerm = updServ.FechaTerminacion;
                model.idUser = updServ.IdUsuario;
                model.IdTipoServ = updServ.IdTipoServicio;
            }
            ViewData["Servicios"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio").SelectedValue;
            ViewData["TipoServ"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, ServiciosViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var updServ = _context.Servicios.Find(model.IdServ);
                if(updServ != null)
                {
                    updServ.NombreServicio = model.NameServ;
                    updServ.PrecioServicio = model.PrecioServ;
                    updServ.Ubicacion = model.UbiServ;
                    updServ.FechaRealizacion = model.FecRealizar;
                    updServ.FechaTerminacion = model.FecTerm;
                    updServ.IdUsuario = model.idUser;
                    updServ.IdTipoServicio = model.IdTipoServ;
                }
                _context.Update(updServ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Servicios", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            ViewData["Servicios"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio").SelectedValue;
            ViewData["TipoServ"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                var delServ = _context.Servicios.Find(Id);
                if(delServ != null)
                {
                    _context.Remove(delServ);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Servicios", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Servicios", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }
    }
}
