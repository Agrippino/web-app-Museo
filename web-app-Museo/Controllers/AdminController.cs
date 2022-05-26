using Microsoft.AspNetCore.Mvc;

namespace web_app_Museo.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
