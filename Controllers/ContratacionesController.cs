using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InteliWeb2.Controllers
{
    public class ContratacionesController : Controller
    {
        private readonly InteliWebContext _context;

        public ContratacionesController(InteliWebContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int user, int servicio, int edoContra, int i, int r)
        {
            var contrata = _context.Contrataciones.Include(c => c.IdUsuarioNavigation).Include(c => c.IdEstadoContratacionNavigation).Include(c => c.IdServicioNavigation);

            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            ViewData["EdoContra"] = new SelectList(_context.EstadoContrataciones, "IdEstadoContratacion", "EstadoContratacion");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if((user == 0) && (servicio == 0) && (edoContra == 0))
                { return View(await contrata.ToListAsync()); }
                else if((user != 0) && (servicio == 0) && (edoContra == 0))
                { return View(await contrata.Where(c => c.IdUsuario == user).ToListAsync()); }
                else if ((user == 0) && (servicio != 0) && (edoContra == 0))
                { return View(await contrata.Where(c => c.IdServicio == servicio).ToListAsync()); }
                else if ((user == 0) && (servicio == 0) && (edoContra != 0))
                { return View(await contrata.Where(c => c.IdEstadoContratacion == edoContra).ToListAsync()); }
                else if ((user != 0) && (servicio != 0) && (edoContra == 0))
                { return View(await contrata.Where(c => c.IdUsuario == user).Where(c => c.IdServicio == servicio).ToListAsync()); }
                else if ((user != 0) && (servicio == 0) && (edoContra != 0))
                { return View(await contrata.Where(c => c.IdUsuario == user).Where(c => c.IdEstadoContratacion == edoContra).ToListAsync()); }
                else if ((user == 0) && (servicio != 0) && (edoContra != 0))
                { return View(await contrata.Where(c => c.IdServicio == servicio).Where(c => c.IdEstadoContratacion == edoContra).ToListAsync()); }

            }
            catch(Exception e) { }

            return View(await contrata.Where(c => c.IdUsuario == user).Where(c => c.IdServicio == servicio).Where(c => c.IdEstadoContratacion == edoContra).ToListAsync());
        }

        public IActionResult Create(int i, int r)
        {
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            ViewData["EdoContra"] = new SelectList(_context.EstadoContrataciones, "IdEstadoContratacion", "EstadoContratacion");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, ContratacionesViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var contrata = new Contratacione()
                {
                    FechaSolicitud = DateTime.Now,
                    FechaInicialContratacion = model.FecIniCont,
                    FechaFinalContratacion = model.FecFinCont,
                    MontoCotizacion = model.MontoCotizado,
                    MontoFinal = model.MontoConseguido,
                    Coomentarios = model.ComUSer,
                    IdServicio = model.idServ,
                    IdEstadoContratacion = model.idEdoContrat,
                    IdUsuario = model.idUser
                };
                _context.Add(contrata);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Contrataciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            ViewData["EdoContra"] = new SelectList(_context.EstadoContrataciones, "IdEstadoContratacion", "EstadoContratacion");
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, ContratacionesViewModel model)
        {
            var updContrat = _context.Contrataciones.Find(Id);
            if (updContrat != null)
            {
                model.IdCont = updContrat.IdContratacion;
                model.FecSolicitud = updContrat.FechaSolicitud;
                model.FecIniCont = updContrat.FechaInicialContratacion;
                model.FecFinCont = updContrat.FechaFinalContratacion;
                model.MontoCotizado = updContrat.MontoCotizacion;
                model.MontoConseguido = updContrat.MontoFinal;
                model.idEdoContrat = updContrat.IdEstadoContratacion;
                model.idServ = updContrat.IdServicio;
                model.ComUSer = updContrat.Coomentarios;
                model.idUser = updContrat.IdUsuario;
            }
            ViewData["Contrat"] = new SelectList(_context.Contrataciones, "IdContratacion", "Coomentarios").SelectedValue;
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            ViewData["EdoContra"] = new SelectList(_context.EstadoContrataciones, "IdEstadoContratacion", "EstadoContratacion");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, ContratacionesViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var updContrat = _context.Contrataciones.Find(model.IdCont);
                if(updContrat != null)
                {
                    updContrat.FechaSolicitud = DateTime.Now;
                    updContrat.FechaInicialContratacion = model.FecIniCont;
                    updContrat.FechaFinalContratacion = model.FecFinCont;
                    updContrat.MontoCotizacion = model.MontoCotizado;
                    updContrat.MontoFinal = model.MontoConseguido;
                    updContrat.Coomentarios = model.ComUSer;
                    updContrat.IdServicio = model.idServ;
                    updContrat.IdEstadoContratacion = model.idEdoContrat;
                    updContrat.IdUsuario = model.idUser;
                }
                _context.Update(updContrat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Contrataciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            ViewData["Contrat"] = new SelectList(_context.Contrataciones, "IdContratacion", "Coomentarios", model.IdCont).SelectedValue;
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            ViewData["EdoContra"] = new SelectList(_context.EstadoContrataciones, "IdEstadoContratacion", "EstadoContratacion");
            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            try
            {
                var delContrat = _context.Contrataciones.Find(Id);
                if(delContrat != null)
                {
                    _context.Remove(delContrat);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Contrataciones", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Contrataciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }
    }
}
