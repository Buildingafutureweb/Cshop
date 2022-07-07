using System.ComponentModel.DataAnnotations;

namespace Cshop.Models
{
    public class Order 
    {
        

        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Detail { get; set; }
        public string Picture { get; set; }


        public int ShopId { get; set; } = 1;

        public int Quantity { get; set; }

        public decimal? TotalSum { get; set; }


        public virtual OrderList OrderList { get; set; }


        public virtual User User { get; set; }



    }
}
