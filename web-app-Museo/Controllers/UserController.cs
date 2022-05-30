using Microsoft.AspNetCore.Mvc;

namespace web_app_Museo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Dettagli()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AcquistiMensili()
        {
            return View();
        }
    }
}
