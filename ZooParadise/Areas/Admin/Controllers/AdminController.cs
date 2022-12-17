using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooParadise.Areas.Admin.Controllers;

namespace ZooParadise.Areas.Administrator.Controllers
{

    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
