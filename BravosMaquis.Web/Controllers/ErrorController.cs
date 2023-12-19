using Microsoft.AspNetCore.Mvc;

namespace BravosMaquis.Web.Controllers
{
    [ResponseCache(Duration = 0, Location=ResponseCacheLocation.None, NoStore=true)]
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
