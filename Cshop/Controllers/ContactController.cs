using Microsoft.AspNetCore.Mvc;
using Cshop.Models;
using Cshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



namespace Cshop.Controllers
{
    public class ContactController : Controller
    {
        private readonly DatabaseContext _context;
        public ContactController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        /*[Route("/contact-test")]*/
        [HttpPost]
        public IActionResult LeaveMessage(string fullName, string email, string message)
        {

            _context.Messages.Add(new Message()
                {
                    FullName = fullName,
                    Email = email,
                    Body = message,
                    CreatedAt = DateTime.Now
                }
            );
            try
            {
                _context.SaveChanges();
                ViewData["msg"] = $"A message from {fullName}, {email} has been sent successfully. <br /> Message Body: {message}";
            }
            catch (Exception ex)
            {

                ViewData["msg"] = $"Some thing went wrong.{ex.Message}";
            }


            return View();

        }
    }
}
