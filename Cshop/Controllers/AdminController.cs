#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Cshop.Data;
using Cshop.Models;
using PagedList;


namespace Cshop.Controllers
{
   /* [Route("/admin/[controller]/[action]")] */
    public class AdminController : Controller
    {
        private readonly DatabaseContext _context;

        private PagedList<Message> messages;
        private string orderlists;

        public AdminController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/Messages
        [Authorize (Roles = "Administrator")]
        public async Task<IActionResult> Messages(int page=1)
        {
            int pageIndex = page;
            int pageSize = 10;


            IQueryable<Message> messageIQ = from m in _context.Messages select m;

            int count = await messageIQ.CountAsync();


            messageIQ = messageIQ.OrderByDescending(m => m.CreatedAt);

            messages = await PagedList<Message>.CreateAsync(messageIQ.AsNoTracking(),pageIndex, pageSize);

            return View(messages);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> OrderLists()
        {


            return View(orderlists);
        }


    }
}
