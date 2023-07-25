using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InteliWeb2.Controllers
{
    public class SeccionPublicacionesController : Controller
    {
        private readonly InteliWebContext _context;

        public SeccionPublicacionesController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int search, int i, int r)
        {
            ViewData["SecPub"] = new SelectList(_context.SeccionPublicaciones, "IdSeccionPublicacion", "SeccionPublicacion");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if(search == null || search == 0)
                {
                    return View(await _context.SeccionPublicaciones.ToListAsync());
                }
            }catch(Exception e) { }
 
            return View(await _context.SeccionPublicaciones.Where(sp => sp.IdSeccionPublicacion == search).ToListAsync());
        }

        public IActionResult Create(int i, int r)
        {
            ViewData["SecPub"] = new SelectList(_context.SeccionPublicaciones, "IdSeccionPublicacion", "SeccionPublicacion");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, SeccionPublicacionesViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var SeccPub = new SeccionPublicacione()
                {
                    SeccionPublicacion = model.SeccPub
                };
                _context.Add(SeccPub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "SeccionPublicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            ViewData["SecPub"] = new SelectList(_context.SeccionPublicaciones, "IdSeccionPublicacion", "SeccionPublicacion", model.idSeccPub);
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, SeccionPublicacionesViewModel model)
        {
            var updSecP = _context.SeccionPublicaciones.Find(Id);
            if(updSecP != null)
            {
                model.idSeccPub = updSecP.IdSeccionPublicacion;
                model.SeccPub = updSecP.SeccionPublicacion;
            }
            ViewData["SecPub"] = new SelectList(_context.SeccionPublicaciones, "IdSeccionPublicacion", "SeccionPublicacion", model.SeccPub).SelectedValue;
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, SeccionPublicacionesViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;
            if (ModelState.IsValid)
            {
                var updSecP = _context.SeccionPublicaciones.Find(model.idSeccPub);
                if(updSecP != null)
                {
                    updSecP.IdSeccionPublicacion = model.idSeccPub;
                    updSecP.SeccionPublicacion = model.SeccPub;
                }
                _context.Update(updSecP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "SeccionPublicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            ViewData["SecPub"] = new SelectList(_context.SeccionPublicaciones, "IdSeccionPublicacion", "SeccionPublicacion", model.idSeccPub).SelectedValue;
            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                var delSecPub = _context.SeccionPublicaciones.Find(Id);
                if(delSecPub != null)
                {
                    _context.Remove(delSecPub);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "SeccionPublicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "SeccionPublicaciones", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }
    }
}
