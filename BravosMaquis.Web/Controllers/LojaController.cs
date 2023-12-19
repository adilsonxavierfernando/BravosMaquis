using Microsoft.AspNetCore.Mvc;

namespace BravosMaquis.Web.Controllers
{
    public class LojaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Bilheteria()
        {
            return View();
        }
    }
}
