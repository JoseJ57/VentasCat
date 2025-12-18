using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VentasSD.Controllers
{
    [Authorize(Roles = "Vendedor")]
    public class VistaVendedorController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }
    }
}
