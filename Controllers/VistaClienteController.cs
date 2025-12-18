using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VentasSD.Controllers
{
    [Authorize(Roles = "Cliente")]

    public class VistaClienteController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
