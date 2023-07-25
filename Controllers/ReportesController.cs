using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InteliWeb2.Controllers
{
    public class ReportesController : Controller
    {
        private readonly InteliWebContext _context;
        public ReportesController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int i, int r)
        {
            var reportes = _context.Reportes
                .Include(r => r.IdTipoReporteNavigation)
                .Include(r => r.IdUsuarioNavigation)
                .Include(r => r.IdEstadoReporteNavigation)
                .Include(r => r.IdServicioNavigation);
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(await reportes.ToListAsync());
        }

        public IActionResult Create(int i, int r)
        {
            ViewData["TpReporte"] = new SelectList(_context.TipoReportes, "IdTipoReporte", "TipoReporte1");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["EdoReporte"] = new SelectList(_context.EstadoReportes, "IdEstadoReporte", "EstadoReporte1");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, ReportesViewModel model, IFormFile PruebReport)
        {
            var file = PruebReport.OpenReadStream();
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var reporte = new Reporte()
                {
                    Reporte1 = model.DetReporte,
                    PruebaReporte = model.PruebReport,
                    PruebaSolucion = model.SoluctReport,
                    ComentariosSolucion = model.ComentSolucion,
                    FechaReporte = DateTime.Now,
                    IdTipoReporte = model.TpReporte,
                    IdUsuario = model.idUser,
                    IdEstadoReporte = model.idEdoReport,
                    IdServicio = model.idServ
                };
                _context.Add(reporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Reportes", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            ViewData["TpReporte"] = new SelectList(_context.TipoReportes, "IdTipoReporte", "TipoReporte1", model.TpReporte);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario", model.idUser);
            ViewData["EdoReporte"] = new SelectList(_context.EstadoReportes, "IdEstadoReporte", "EstadoReporte1", model.idEdoReport);
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio", model.idServ);
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, ReportesViewModel model)
        {
            var updRep = _context.Reportes.Find(Id);
            if(updRep != null)
            {
                model.IdReport = updRep.IdReporte;
                model.DetReporte = updRep.Reporte1;
                model.FecReporte = updRep.FechaReporte;
                model.TpReporte = updRep.IdTipoReporte;
                model.idUser = updRep.IdUsuario;
            }
            ViewData["Reportes"] = new SelectList(_context.Reportes, "IdReporte", "Reporte1").SelectedValue;
            ViewData["TipoRepor"] = new SelectList(_context.TipoReportes, "IdTipoReporte", "TipoReporte1");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["EdoReporte"] = new SelectList(_context.EstadoReportes, "IdEstadoReporte", "EstadoReporte1");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, ReportesViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var updRep = _context.Reportes.Find(model.IdReport);
                if (updRep != null)
                {
                    updRep.Reporte1 = model.DetReporte;
                    updRep.FechaReporte = model.FecReporte;
                    updRep.IdTipoReporte = model.TpReporte;
                    updRep.IdUsuario = model.idUser;
                }
                _context.Update(updRep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Reportes"] = new SelectList(_context.Reportes, "Idreporte", "Reporte1").SelectedValue;
            ViewData["TipoRepor"] = new SelectList(_context.TipoReportes, "IdTipoReporte", "TipoReporte1");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["EdoReporte"] = new SelectList(_context.EstadoReportes, "IdEstadoReporte", "EstadoReporte1");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");
            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                var delReport = _context.Reportes.Find(Id);
                if(delReport != null)
                {
                    _context.Remove(delReport);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Reportes", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "Reportes", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }
    }
}
