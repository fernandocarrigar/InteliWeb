using InteliWeb2.Models;
using InteliWeb2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InteliWeb2.Controllers
{
    public class TipoArchivosController : Controller
    {
        private readonly InteliWebContext _context;

        public TipoArchivosController(InteliWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int search, int i, int r)
        {
            ViewData["TipoArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                if(search == null || search == 0)
                {
                    return View(await _context.TipoArchivos.ToListAsync());
                }
            }
            catch(Exception e) { }

            return View(await _context.TipoArchivos.Where(ta => ta.IdTipoArchivo == search).ToListAsync());
        }
        public IActionResult Create(int i, int r)
        {
            ViewData["TipoArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1");
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int i, int r, TipoArchivosViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var tipoarchivo = new TipoArchivo()
                {
                    TipoArchivo1 = model.TpArchivo
                };
                _context.Add(tipoarchivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoArchivos", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            ViewData["TipoArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1");
            return View(model);
        }

        public IActionResult Update(int Id, int i, int r, TipoArchivosViewModel model)
        {
            var updArc = _context.TipoArchivos.Find(Id);
            if(updArc != null)
            {
                model.IdTpArc = updArc.IdTipoArchivo;
                model.TpArchivo = updArc.TipoArchivo1;
            }

            ViewData["TipoArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1", model.TpArchivo).SelectedValue;
            ViewData["i"] = i;
            ViewData["r"] = r;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int i, int r, TipoArchivosViewModel model)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            if (ModelState.IsValid)
            {
                var updArc = _context.TipoArchivos.Find(model.IdTpArc);
                if(updArc != null)
                {
                    updArc.TipoArchivo1 = model.TpArchivo;
                }
                _context.Update(updArc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoArchivos", Action = "Index", r = $"{r}", i = $"{i}" }));
            }

            ViewData["TipoArchivo"] = new SelectList(_context.TipoArchivos, "IdTipoArchivo", "TipoArchivo1", model.IdTpArc).SelectedValue;
            return View(model);
        }

        public async Task<IActionResult> Delete(int i, int r, int Id)
        {
            ViewData["i"] = i;
            ViewData["r"] = r;

            try
            {
                var delTpArch = _context.TipoArchivos.Find(Id);
                if(delTpArch != null)
                {
                    _context.Remove(delTpArch);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoArchivos", Action = "Index", r = $"{r}", i = $"{i}" }));
                }
            }
            catch (Exception e)
            {
                var mensaje = "Valor no encontrado";
                HttpResponseMessage.Equals(mensaje, e.Message);
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { Controller = "TipoArchivos", Action = "Index", r = $"{r}", i = $"{i}" }));
            }
            return View();
        }

    }
}
