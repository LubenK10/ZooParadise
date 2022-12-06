using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZooParadise.Core.Contracts;
using ZooParadise.Models;

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
           var songs = await petService.LastThreeHouses();
       
           return View(songs);
       }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}