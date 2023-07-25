using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;

namespace InteliWeb2.Controllers
{
    public class TipoReportesController : Controller
    {
        private readonly InteliWebContext _context;

        public TipoReportesController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int search, int i, int r)
        {
            ViewData["TpReportes"] = new SelectList(_context.TipoReportes, "IdTipoReporte", "TipoReporte1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if (search == null || search == 0)
                {
                    return View(await _context.TipoReportes.ToListAsync());
                }
            }
            catch (Exception e) { }

            return View(await _context.TipoReportes.Where(u => u.IdTipoReporte == search).ToListAsync());

        }

        public IActionResult Create(int i, int r)
        {
            ViewData["TpReportes"] = new SelectList(_context.TipoReportes, "IdTipoReporte", "TipoReporte1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoReporteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tpreporte = new TipoReporte()
                {
                    TipoReporte1 = model.TpReporte
                };
                _context.Add(tpreporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TpReportes"] = new SelectList(_context.TipoReportes, "IdTipoReporte", "TipoReporte1");
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, TipoReporteViewModel model)
        {
            var updat = _context.TipoReportes.Find(Id);
            if (updat != null)
            {
                model.IdTpReporte = updat.IdTipoReporte;
                model.TpReporte = updat.TipoReporte1;
            }
            ViewData["TpReporte"] = new SelectList(_context.TipoReportes, "IdTipoReporte", "TipoReporte1", model.TpReporte).SelectedValue;
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TipoReporteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var updat = _context.TipoReportes.Find(model.IdTpReporte);
                if (updat != null)
                {
                    updat.TipoReporte1 = model.TpReporte;
                }
                _context.Update(updat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["TpReporte"] = new SelectList(_context.TipoReportes, "IdTipoReporte", "TipoReporte1", model.IdTpReporte).SelectedValue;
            return View(model);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var delTpRepor = _context.TipoReportes.Find(Id);

                if (delTpRepor != null)
                {
                    _context.Remove(delTpRepor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }catch(Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index));
            }

            return View();
            
        }
    }
}
