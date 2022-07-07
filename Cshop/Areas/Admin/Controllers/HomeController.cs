using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Cshop.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {

       
        public IActionResult Index()
        {
            return View();
        }


        [Route("/w4")]
        public IActionResult Welcome()
        {





            return View();
        }


        /*
        [Route("/myprofile")]
        public IActionResult Myprofile()
        {
            return View();
        }
        */

    }
}
