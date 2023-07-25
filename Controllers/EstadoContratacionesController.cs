using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InteliWeb2.Controllers
{
    public class EstadoContratacionesController : Controller
    {
        private readonly InteliWebContext _context;

        public EstadoContratacionesController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int search, int i, int r)
        {
            ViewData["EdoContra"] = new SelectList(_context.EstadoContrataciones, "IdEstadoContratacion", "EstadoContratacion");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if(search == null || search == 0)
                {
                    return View(await _context.EstadoContrataciones.ToListAsync());
                }
            }catch(Exception e) { }

            return View(await _context.EstadoContrataciones.Where(ec => ec.IdEstadoContratacion == search).ToListAsync());
        }

        public IActionResult Create(int i, int r)
        {
            ViewData["EdoContra"] = new SelectList(_context.EstadoContrataciones, "IdEstadoContratacion", "EstadoContratacion");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, EdoContratacionesViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var edoCont = new EstadoContratacione()
                {
                    EstadoContratacion = model.EdoContratacion
                };
                _context.Add(edoCont);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "EstadoContrataciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            ViewData["EdoContra"] = new SelectList(_context.EstadoContrataciones, "IdEstadoContratacion", "EstadoContratacion", model.idEdoContrat);
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, EdoContratacionesViewModel model)
        {
            var updEdoC = _context.EstadoContrataciones.Find(Id);
            if(updEdoC != null)
            {
                model.idEdoContrat = updEdoC.IdEstadoContratacion;
                model.EdoContratacion = updEdoC.EstadoContratacion;
            }
            ViewData["EdoContra"] = new SelectList(_context.EstadoContrataciones, "IdEstadoContratacion", "EstadoContratacion", model.EdoContratacion).SelectedValue;
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, EdoContratacionesViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var updEdoC = _context.EstadoContrataciones.Find(model.idEdoContrat);
                if(updEdoC != null)
                {
                    updEdoC.EstadoContratacion = model.EdoContratacion;
                }
                _context.Update(updEdoC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "EstadoContrataciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            ViewData["EdoContra"] = new SelectList(_context.EstadoContrataciones, "IdEstadoContratacion", "EstadoContratacion", model.EdoContratacion).SelectedValue;
            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                var delEdoCont = _context.EstadoContrataciones.Find(Id);
                if(delEdoCont != null)
                {
                    _context.Remove(delEdoCont);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "EstadoContrataciones", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "EstadoContrataciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }

    }
}
