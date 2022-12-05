using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooParadise.Core.Constants;
using ZooParadise.Core.Contracts;
using ZooParadise.Core.Models.Manager;
using ZooParadise.Extensions;

namespace ZooParadise.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        private readonly IManagerService managerService;

        public ManagerController(IManagerService _managerService)
        {
            this.managerService = _managerService;
        }

        [HttpGet]
        public async Task<IActionResult> BecomeManager()
        {
            if (await managerService.IdExist(User.Id()))
            {
                TempData[MessageConstants.ErrorMessage] = "You are already a Manager!";

                return RedirectToAction("Index", "Home");
            }
            var model = new ManagerModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BecomePro(ManagerModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await managerService.IdExist(userId))
            {
                TempData[MessageConstants.ErrorMessage] = "You are already a Manager!";

                return RedirectToAction("Index", "Home");
            }

            if (await managerService.PhoneExist(model.PhoneNumber))
            {
                TempData[MessageConstants.ErrorMessage] = "User with that telephone number already exist!";

                return RedirectToAction("Index", "Home");
            }

            await managerService.Create(userId, model.PhoneNumber);

            TempData[MessageConstants.SuccessMessage] = "Congatulation! You are a Manager!";

            return RedirectToAction("All", "Pet");

        }
    }
}
