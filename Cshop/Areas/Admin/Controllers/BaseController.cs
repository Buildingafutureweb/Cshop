using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Cshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator, ShopOwner")]
    public class BaseController : Controller
    {

    }
}
