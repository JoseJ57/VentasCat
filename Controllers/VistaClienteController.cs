using Microsoft.AspNetCore.Mvc;

namespace VentasSD.Controllers
{
    public class VistaClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
