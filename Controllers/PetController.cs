using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooParadise.Core.Contracts;
using ZooParadise.Core.Models.Pet;
using ZooParadise.Extensions;

namespace ZooParadise.Controllers
{
    [Authorize]
    public class PetController : Controller
    {

        private readonly IPetService petService;

        private readonly IManagerService managerService;

        private readonly ILogger logger;

        public PetController(
            IPetService _petService,
            IManagerService _managerService,
            ILogger<PetController> _logger)
        {
            petService = _petService;
            managerService = _managerService;
            logger = _logger;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddPetModel()
            {
                AnimalTypes = await petService.AllAnimalTypes(),
                Genders = await petService.AllGenders(),
                Colours = await petService.AllColours()

            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddPetModel model)
        {
            
            if (!ModelState.IsValid)
            {
                model.AnimalTypes = await petService.AllAnimalTypes();
                model.Genders = await petService.AllGenders();
                model.Colours = await petService.AllColours();

                return View(model);
            }

            if (await managerService.IdExist(User.Id()) == false)
            {
                RedirectToAction("Become", "Agent");
            }

            var managerId = await managerService.TakeManagerId(User.Id());

            int id = await petService.Create(model, managerId);

            return RedirectToAction("Details", new { id });
        }
    }
}

