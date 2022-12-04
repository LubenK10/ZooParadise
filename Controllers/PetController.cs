using Microsoft.AspNetCore.Mvc;

namespace ZooParadise.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
