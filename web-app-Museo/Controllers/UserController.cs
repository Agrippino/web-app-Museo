using Microsoft.AspNetCore.Mvc;

namespace web_app_Museo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
