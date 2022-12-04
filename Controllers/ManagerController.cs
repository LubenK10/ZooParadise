using Microsoft.AspNetCore.Mvc;

namespace ZooParadise.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
