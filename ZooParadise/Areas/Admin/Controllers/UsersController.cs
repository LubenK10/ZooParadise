using Microsoft.AspNetCore.Mvc;
using ZooParadise.Core.Constants;
using ZooParadise.Core.Contracts.Admin;

namespace ZooParadise.Areas.Admin.Controllers
{
    
    public class UsersController : BaseController
    {
        private readonly IUserService userService;
      
        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        
        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            var model = await userService.All();
      
            return View(model);
        }
      
        
    }
}
