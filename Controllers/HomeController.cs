using InteliWeb2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace InteliWeb2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly InteliWebContext _context;

        public HomeController(ILogger<HomeController> logger, InteliWebContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var publicacion = _context.Publicaciones.Include(p => p.IdTipoPublicacionNavigation).Include(p => p.IdArchivoNavigation).Include(p => p.IdUsuarioNavigation).
                Include(p => p.IdSeccionPublicacionNavigation).Include(p => p.IdServicioNavigation);

            ViewData["Archivos"] = new SelectList(_context.Archivos, "IdArchivo", "NombreArchivo");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "IdUsuario", "NombreUsuario");
            ViewData["Seccion"] = new SelectList(_context.SeccionPublicaciones, "IdSeccionPublicacion", "SeccionPublicacion");
            ViewData["TipoPub"] = new SelectList(_context.TipoPublicaciones, "IdTipoPublicacion", "TipoPublicacion");
            ViewData["Servicio"] = new SelectList(_context.Servicios, "IdServicio", "NombreServicio");

            _logger.LogInformation("");

            return View(await publicacion.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Soporte()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}