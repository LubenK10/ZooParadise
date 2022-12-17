using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooParadise.Core.Constants;
using ZooParadise.Core.Contracts;
using ZooParadise.Core.Models.Pet;
using ZooParadise.Core.Models.PetModels;
using ZooParadise.Extensions;
using ZooParadise.Models;
using static ZooParadise.Areas.Admin.Constants.AdminConstants;

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
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllPetsModel query)
        {
            var result = await petService.All(
                query.AnimalType,
                query.Colour,
                query.Gender,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllPetsModel.PetsPerPage);

            query.TotalPetCount = result.PetsCount;
            query.AnimalTypes = await petService.AllAnimalTypesNames();
            query.Colours = await petService.AllColoursNames();
            query.Genders = await petService.AllGendersNames();
            query.Pets = result.Pets;

            return View(query);
        }
        public async Task<IActionResult> Mine()
        {
             if (User.IsInRole(AdminRollName))
            {
                return RedirectToAction("Mine", "Pet", new { area = AreaName });
            }
      
            IEnumerable<PetServiceModel> myPet;
            var userId = User.Id();
      
            if (await managerService.IdExist(userId))
            {
                int agentId = await managerService.TakeManagerId(userId);
                myPet = await petService.AllPetsByManagerId(agentId);
            }
            else
            {
                myPet = await petService.AllPetsByUserId(userId);
            }

            return View(myPet);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if ((await petService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await petService.PetDetailsById(id);


            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (await managerService.IdExist(User.Id()) == false)
            {
                return RedirectToAction("Become", "Manager");
            }

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

            if (await managerService.IdExist(User.Id()) == false)
            {
                RedirectToAction("Become", "Manager");
            }

            if (ModelState.IsValid)
            {
                model.AnimalTypes = await petService.AllAnimalTypes();
                model.Genders = await petService.AllGenders();
                model.Colours = await petService.AllColours();

                return View(model);
            }

            var managerId = await managerService.TakeManagerId(User.Id());

            int id = await petService.Create(model, managerId);

            TempData[MessageConstants.SuccessMessage] = "You have just added a pet!";

            return RedirectToAction("Details", new { id });
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await petService.Exists(id)) == false)
            {
                return RedirectToAction("Pet", "All");
            }

            var pet = await petService.PetDetailsById(id);
            var animalTypeId = await petService.GetAnimalTypeId(id);
            var colourId = await petService.GetColourId(id);
            var genderId = await petService.GetGenderId(id);

            var model = new PetModel()
            {
                Description = pet.Description,
                ImageUrl = pet.ImageUrl,
                Price = pet.Price,
                Name = pet.Name,
                Age = pet.Age,
                AnimalType = animalTypeId,
                Colour = colourId,
                Gender = genderId,
                AnimalTypes = await petService.AllAnimalTypes(),
                Colours = await petService.AllColours(),
                Genders = await petService.AllGenders()
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PetModel model)
        {
             if (id != model.Id)
             {
                 return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
             }
            
             if ((await petService.Exists(model.Id)) == false)
             {
                 ModelState.AddModelError("", "Pet does not exist");
                 model.AnimalTypes = await petService.AllAnimalTypes();
                 model.Colours = await petService.AllColours();
                 model.Genders = await petService.AllGenders();

                return View(model);
             }
            
             if ((await petService.HasManagerWithId(model.Id, User.Id())) == false)
             {
                 return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
             }
            
            
             if (ModelState.IsValid == false)
             {
                model.AnimalTypes = await petService.AllAnimalTypes();
                model.Colours = await petService.AllColours();
                model.Genders = await petService.AllGenders();

                return View(model);
             }
            
             await petService.Edit(model.Id, model);

            TempData[MessageConstants.SuccessMessage] = "You successefully edited a pet!";

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
             if ((await petService.Exists(id)) == false)
             {
                 return RedirectToAction(nameof(All));
             }
         
             if ((await petService.HasManagerWithId(id, User.Id())) == false)
             {
                 return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
             }
         
             var pet = await petService.PetDetailsById(id);
         
             var model = new DeletePetModel()
             {
                 Name = pet.Name,
                 ImageUrl = pet.ImageUrl,
                 Age = pet.Age
             };
         
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id, DeletePetModel model)
        {
            if ((await petService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }
       
            if ((await petService.HasManagerWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }
       
            await petService.Delete(id);

            TempData[MessageConstants.SuccessMessage] = "The pet was deleted!";

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Adopt(int id)
        {
           if ((await petService.Exists(id)) == false)
           {
               return RedirectToAction(nameof(All));
           }
   
           if (!User.IsInRole(AdminRollName) && await managerService.IdExist(User.Id()))
           {
               return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
           }
   
           if (await petService.IsAdopted(id))
           {
               return RedirectToAction(nameof(All));
           }
   
           await petService.Adopt(id, User.Id());

            TempData[MessageConstants.SuccessMessage] = "You have adopted a pet!";

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if ((await petService.Exists(id)) == false ||
                (await petService.IsAdopted(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }
       
            if ((await petService.IsAdoptedByUser(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }
       
            await petService.Leave(id);

            TempData[MessageConstants.SuccessMessage] = "You have left the pet!";

            return RedirectToAction(nameof(Mine));
        }
    }
}

