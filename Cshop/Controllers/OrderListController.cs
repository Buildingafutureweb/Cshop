using Cshop.Data;
using Cshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cshop.Controllers
{
    public class OrderListController : Controller
    {

        private readonly DatabaseContext _context;
        

        public OrderListController(DatabaseContext context)
        {
            _context = context;
        }

        //DatabaseContext _context = new DatabaseContext();


        
        public ActionResult Index()
        {
            return View();
        }




        /*
        public IActionResult Index()
        {
            var orderlists = _context.OrderLists.Include(c => c.OrderListId);

            orderlists = _context.OrderLists.Include(c => c.OrderId);

            orderlists = _context.OrderLists.Include(c => c.ProductId);

            orderlists = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Models.OrderList, int>)_context.OrderLists.Include(c => c.ProductName);
            orderlists = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Models.OrderList, int>)_context.OrderLists.Include(c => c.Price);

            orderlists = _context.OrderLists.Include(c => c.ShopId);
            orderlists = _context.OrderLists.Include(c => c.Quantity);

            orderlists = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Models.OrderList, int>)_context.OrderLists.Include(c => c.TotalSum);

            orderlists = _context.OrderLists.Include(c => c.AccessorId);

            orderlists = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Models.OrderList, int>)_context.OrderLists.Include(c => c.AccessorName);

            return View(orderlists.ToList());
        }
        */


        public class ListModel
        {
            public Shop Shop { get; set; }
            public List<Product> Products { get; set; }

            public List<Order> Orders { get; set; }

            public List<OrderList> OrderLists { get; set; }

        }


        private OrderList getOrderList(int? orderlistId)
        {
            return (_context.OrderLists.FirstOrDefault(m => m.OrderListId == orderlistId));
        }


        /*
        [HttpPost]
        public async Task<IActionResult> OrderList(int id)
        {


            OrderList orderlist = new OrderList();


            _context.Add(orderlist);
            await _context.SaveChangesAsync();


            return View(orderlist);

        }
        */



        [HttpPost]
        public async Task<IActionResult> CreateOrderList(int id, int id2, Guid id3)
        {
            OrderList orderlist = new OrderList();


            Product product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            Order order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id2);
            User user = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id3);

            var users = _context.Users.Include(o => o.Order);

            /*
            foreach(User u in users)
            {
                foreach(Order o in u.Order)
                {
                    orderlist.Equals(u.UserId + o.OrderId + o.ProductId + o.ProductName + o.Price + o.ShopId + o.Quantity + o.TotalSum);
                }
                
            }
            */

            /*
            orderlist.OrderId = order.OrderId;
            orderlist.ProductId = product.ProductId;
            orderlist.ProductName = product.ProductName;
            orderlist.Price = product.Price;
            orderlist.ShopId = product.ShopId;
            orderlist.Quantity = order.Quantity;
            orderlist.TotalSum = order.TotalSum;
            orderlist.UserId = user.UserId;
           
            *?


            /*
            db.UserInfo.Add(userInfo);
            if (db.SaveChanges() > 0)
            {
                return Content("ok");
            }
            else
            {
                return Content("Fail");
            }
            */


            //_context.Add(orderlist);
            _context.OrderLists.Add(orderlist);
            await _context.SaveChangesAsync();


            return View(orderlist);


        }




    }
}
