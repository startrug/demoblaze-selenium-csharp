using demoblaze_selenium_csharp.Enum;

namespace demoblaze_selenium_csharp.Tests
{
    public class Product
    {
        public Product(Category category, string productName)
        {
            Category = category;
            ProductName = productName;
        }

        public Category Category { get; set; }
        public string ProductName { get; set; }
    }
}