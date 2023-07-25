using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InteliWeb2.Controllers
{
    public class EstadoReportesController : Controller
    {
        private readonly InteliWebContext _context;

        public EstadoReportesController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int search, int i, int r)
        {
            ViewData["EdoReport"] = new SelectList(_context.EstadoReportes, "IdEstadoReporte", "EstadoReporte1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if(search == 0 || search == null)
                {
                    return View(await _context.EstadoReportes.ToListAsync());
                }
            }
            catch(Exception e) { }

            return View(await _context.EstadoReportes.Where(er => er.IdEstadoReporte == search).ToListAsync());
        }

        public IActionResult Create(int i, int r)
        {
            ViewData["EdoReport"] = new SelectList(_context.EstadoReportes, "IdEstadoReporte", "EstadoReporte1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, EstadoReportesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var edoRep = new EstadoReporte()
                {
                    EstadoReporte1 = model.EdoReport
                };
                _context.Add(edoRep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "EstadoReportes", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            ViewData["EdoReport"] = new SelectList(_context.EstadoReportes, "IdEstadoReporte", "EstadoReporte1", model.idEdoReport);
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, EstadoReportesViewModel model)
        {
            var updEdoR = _context.EstadoReportes.Find(Id);
            if(updEdoR != null)
            {
                model.idEdoReport = updEdoR.IdEstadoReporte;
                model.EdoReport = updEdoR.EstadoReporte1;
            }
            ViewData["EdoReport"] = new SelectList(_context.EstadoReportes, "IdEstadoReporte", "EstadoReporte1").SelectedValue;
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        public async Task<IActionResult> Update(int i, int r, EstadoReportesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var updEdoR = _context.EstadoContrataciones.Find(model.idEdoReport);
                if(updEdoR != null)
                {
                    updEdoR.EstadoContratacion = model.EdoReport;
                }
                _context.Update(updEdoR);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EdoReport"] = new SelectList(_context.EstadoReportes, "IdEstadoReporte", "EstadoReporte1").SelectedValue;
            return View(model);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var delEdoRep = _context.EstadoReportes.Find(Id);
                if(delEdoRep != null)
                {
                    _context.Remove(delEdoRep);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
