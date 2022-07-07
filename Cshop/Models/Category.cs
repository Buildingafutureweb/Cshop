namespace Cshop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ShopId { get; set; } = 1;
        public List<Product> Products { get; set; }
    }
}
