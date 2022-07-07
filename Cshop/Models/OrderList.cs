using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cshop.Models
{


    public class OrderList 
    {


        [Key]
        public int OrderListId { get; set; }
     
        public virtual ICollection<Order> Order { get; set; }
      
        public virtual User User { get; set; }


        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public int ShopId { get; set; } = 1;
        public int Quantity { get; set; }
        public decimal? TotalSum { get; set; }

        //public Guid UserId { get; set; }
        public ICollection<Order> GetOrder()
        {
            ICollection<Order> order = null;
            return order;
        }


    }
}
