using Microsoft.AspNetCore.Mvc;

namespace VentasSD.Controllers
{
    public class VistaVendedorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
