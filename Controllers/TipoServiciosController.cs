using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Timers;

namespace InteliWeb2.Controllers
{
    public class TipoServiciosController : Controller
    {
        private readonly InteliWebContext _context;

        public TipoServiciosController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int search, int i, int r)
        {
            ViewData["TpServ"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if(search == null || search == 0)
                {
                    return View(await _context.TipoServicios.ToListAsync());
                }
            }
            catch(Exception e) { }

            return View(await _context.TipoServicios.Where(ts => ts.IdTipoServicio == search).ToListAsync());
        }

        public IActionResult Create(int i, int r)
        {
            ViewData["TipoServicios"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, TipoServicioViewModel model)
        {
            View(await _context.TipoServicios.ToListAsync());
            ViewData["TipoServicios"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var tiposervicio = new TipoServicio()
                {
                    TipoServicio1 = model.TipoServ
                };
                _context.Add(tiposervicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoServicios", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, TipoServicioViewModel model)
        {
            ViewData["TipoServicio"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1", model.TipoServ).SelectedValue;
            ViewData["i"] = i;
            ViewData["r"] = r;

            var updat = _context.TipoServicios.Find(Id);
            if (updat != null)
            {
                model.IdTpServ = updat.IdTipoServicio;
                model.TipoServ = updat.TipoServicio1;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, TipoServicioViewModel model)
        {
            ViewData["TipoServicio"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1", model.IdTpServ).SelectedValue;
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var updat = _context.TipoServicios.Find(model.IdTpServ);
                if (updat != null)
                {
                    updat.TipoServicio1 = model.TipoServ;
                }
                _context.Update(updat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoServicios", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                var delTpServ = _context.TipoServicios.Find(Id);
                if(delTpServ != null)
                {
                    _context.Remove(delTpServ);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoServicios", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoServicios", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }

    }
}