using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZooParadise.Areas.Admin.Models;
using ZooParadise.Core.Constants;
using ZooParadise.Core.Contracts;
using ZooParadise.Core.Models.Pet;
using ZooParadise.Extensions;

namespace ZooParadise.Areas.Admin.Controllers
{
    public class PetController : BaseController
    {
        private readonly IPetService petService;

        private readonly IManagerService managerService;

        public PetController(
            IPetService _petService,
            IManagerService _managerService)
        {
            petService = _petService;
            managerService = _managerService;
        }


        public async Task<IActionResult> Mine()
        {
            var myPets = new MyPetsModel();
            var managerId = User.Id();
            myPets.AdoptedPets = await petService.AllPetsByUserId(managerId);
            var agentId = await managerService.TakeManagerId(managerId);
            myPets.AddedPets = await petService.AllPetsByManagerId(agentId);

            return View(myPets);
        }
    }
}
