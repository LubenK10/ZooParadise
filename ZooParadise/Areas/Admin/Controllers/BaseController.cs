using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ZooParadise.Areas.Admin.Constants.AdminConstants;

namespace ZooParadise.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRollName)]

    public class BaseController : Controller
    {
       
    }
}
