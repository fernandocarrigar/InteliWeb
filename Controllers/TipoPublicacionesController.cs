using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InteliWeb2.Controllers
{
    public class TipoPublicacionesController : Controller
    {
        private readonly InteliWebContext _context;

        public TipoPublicacionesController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int search, int i, int r)
        {
            ViewData["TipoPub"] = new SelectList(_context.TipoPublicaciones, "IdTipoPublicacion", "TipoPublicacion");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if(search == null || search == 0)
                {
                    return View(await _context.TipoPublicaciones.ToListAsync());
                }
            }catch(Exception e) { }

            return View(await _context.TipoPublicaciones.Where(tp => tp.IdTipoPublicacion == search).ToListAsync());
        }

        public IActionResult Create(int i, int r)
        {
            ViewData["TipoPub"] = new SelectList(_context.TipoPublicaciones, "IdTipoPublicacion", "TipoPublicacion");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, TipoPublicacionesViewModel model)
        {
            ViewData["TipoPub"] = new SelectList(_context.TipoPublicaciones, "IdTipoPublicacion", "TipoPublicacion", model.idTpPub);
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var tppub = new TipoPublicacione()
                {
                    TipoPublicacion = model.TpPub
                };
                _context.Add(tppub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoPublicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, TipoPublicacionesViewModel model)
        {
            var updTpPub = _context.TipoPublicaciones.Find(Id);
            if(updTpPub != null)
            {
                model.idTpPub = updTpPub.IdTipoPublicacion;
                model.TpPub = updTpPub.TipoPublicacion;
            }
            ViewData["TipoPub"] = new SelectList(_context.TipoPublicaciones, "IdTipoPublicacion", "TipoPublicacion", model.TpPub).SelectedValue;
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, TipoPublicacionesViewModel model)
        {
            ViewData["TipoPub"] = new SelectList(_context.TipoPublicaciones, "IdTipoPublicacion", "TipoPublicacion", model.idTpPub).SelectedValue;
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var updTpPub = _context.TipoPublicaciones.Find(model.idTpPub);
                if(updTpPub != null)
                {
                    updTpPub.TipoPublicacion = model.TpPub;
                }
                _context.Update(updTpPub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoPublicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                var delTpPub = _context.TipoPublicaciones.Find(Id);
                if(delTpPub != null)
                {
                    _context.Remove(delTpPub);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoPublicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoPublicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }

    }
}
