namespace Cshop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Sn { get; set; }
        public string Detail { get; set; }
        public string Picture { get; set; }
        public int ShopId { get; set; } = 1;
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
