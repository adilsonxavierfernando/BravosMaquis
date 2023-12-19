using Microsoft.AspNetCore.Mvc;

namespace BravosMaquis.Web.Controllers
{
    public class ClubeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Direccao()
        {
            return View();
        }
        public IActionResult Formacao()
        {
            return View();
        }
    }
}
