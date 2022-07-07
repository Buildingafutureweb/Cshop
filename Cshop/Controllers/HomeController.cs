using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Cshop.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Cshop.Data;

namespace Cshop.Controllers
{
    public class HomeController : Controller
    {

       

        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;



        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }



        public async Task<IActionResult> Products()
        {
            return View(await _context.Products.Include(c => c.Category).ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
