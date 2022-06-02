using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web_app_Museo.Data;
using web_app_Museo.Models;

namespace web_app_Museo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (MuseoContext db = new MuseoContext())
            {
                var quantita = db.ClassificaProdotti.ToList();
                  return View(quantita);
            }
          
        }

        public IActionResult Privacy()
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