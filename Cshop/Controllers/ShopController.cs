using Cshop.Data;
using Microsoft.AspNetCore.Mvc;
using Cshop.Models;
using Microsoft.EntityFrameworkCore;

namespace Cshop.Controllers
{




    public class ShopController : Controller
    {
        public class ListModel
        {
            public Shop Shop { get; set; }
            public List<Product> Products { get; set; }
            public string Picture { get; set; }

            public List<Order> Orders { get; set; }

            public List<OrderList> OrderLists { get; set; }


        }

        private readonly DatabaseContext _context;

        public int OrderId { get; private set; }

        //public int ShoppingOrderId { get; private set; }




        // private int ShoppingOrderListId;

        //public int ShoppingOrderListId { get; private set; }

        //private int ShoppingOrderListId;




        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || _context.Shops == null)
            {
                return NotFound();
            }
            else
            {
                ListModel model = new ListModel();
                model.Shop = getShop(id);
                model.Products = _context.Products.Where(p => p.ShopId == id).ToList();
               

                return View(model);

            }

         
        }

        public ShopController(DatabaseContext context)
        {
            _context = context;
        }



        private Shop getShop(int? shopId)
        {
            return (_context.Shops.FirstOrDefault(m => m.ShopId == shopId));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            else
            {
                Product product = await _context.Products.FirstOrDefaultAsync(m =>m.ProductId == id);
                ViewBag.shop = getShop(product.ShopId);
                return View(product);

            }



        }




        private Order getOrder(int? orderId)
        {
            return (_context.Orders.FirstOrDefault(m => m.OrderId == orderId));
        }



        public List<Order> GetOrderItems()
        {
            return _context.Orders.Where(
                order => order.OrderId == OrderId).ToList();
        }



        [HttpPost]
        public async Task<IActionResult> Order(int id, int quantity, decimal totalSum)
        {
            // 1. get data(get product get shop)
            //2. calculate(get totalsum)
            //3. save order, 
            //4. display to view 

            /*if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            else
            {
                Product product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
                ViewBag.shop = getShop(product.ShopId);
                return View(product);

            }*/

            Product product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            ViewBag.shop = getShop(product.ShopId);
            ViewBag.quantity = quantity;

            //ViewBag.order = getOrder(product.OrderId);

            Order order = new Order();


    





            //order.UserId = 
            order.ProductId = product.ProductId;
            order.ProductName = product.ProductName;
            order.Price = product.Price;         
            order.Quantity = quantity;

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.TotalSum = product.Price * quantity;
            }

            order.TotalSum = totalSum;




            var orderItems = GetOrderItems();

            foreach (var item in orderItems)
                {
                    var orderList = new OrderList
                    {
                        OrderId = item.OrderId,
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        Price = item.Price, 
                        ShopId = item.ShopId,
                        Quantity = item.Quantity,
                        TotalSum = item.TotalSum                   
                    };
                    // Set the order total of the shopping cart

                    _context.OrderLists.Add(orderList);

                }

                // Set the order's total to the orderTotal count
                //order.Total = orderTotal;

                // Save the order
               _context.SaveChanges();
            // Empty the shopping cart
            //EmptyCart();
            // Return the OrderId as the confirmation number
            //return order.OrderId;




            _context.Add(order);
            await _context.SaveChangesAsync();

            //order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);

            //order.TotalSum = 0;

            //if (id == 0)
            //{
            //    return NotFound();
            //}

            //order.Quantity = quantity;
            //ViewBag.Quantity = quantity;

            //product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);

         
            return View(order);


        }


        private OrderList getOrderList(int? orderlistId)
        {
            return (_context.OrderLists.FirstOrDefault(m => m.OrderListId == orderlistId));
        }

        /*
        private User getUser(int? accessorId)
        {
            return (_context.Users.FirstOrDefault(m => m.AccessorId == accessorId));
        }
        */



        [HttpPost]
        public async Task<IActionResult> OrderList(int id)
        {


            Product product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            //ViewBag.shop = getShop(product.ShopId);

            //ViewBag.shop = getShop(product.ShopId);


            Order order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);


            OrderList orderlist = new OrderList();

            /*
            orderlist.OrderId = order.OrderId;

            orderlist.ProductId = product.ProductId;
            orderlist.ProductName = product.ProductName;
            orderlist.Price = product.Price;

            orderlist.ShopId = product.ShopId;         
            orderlist.Quantity = order.Quantity;
            orderlist.TotalSum = order.TotalSum;
            */



            _context.Add(orderlist);
            await _context.SaveChangesAsync();


            return View(orderlist);


        }


    }
}
