using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZooParadise.Core.Contracts;
using ZooParadise.Models;
using static ZooParadise.Areas.Admin.Constants.AdminConstants;

namespace ZooParadise.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetService petService;

        public HomeController(IPetService _petService)
        {
            petService = _petService;
        }

       public async Task<IActionResult> Index()
       {
            if (User.IsInRole(AdminRollName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            var pets = await petService.LastThreePets();
       
           return View(pets);
       }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}