using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VentasSD.Controllers
{
    [Authorize(Roles = "Administrador")]

    public class VistaAdministradorController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
