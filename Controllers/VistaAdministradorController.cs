using Microsoft.AspNetCore.Mvc;

namespace VentasSD.Controllers
{
    public class VistaAdministradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
