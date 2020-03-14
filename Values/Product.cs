using demoblaze_selenium_csharp.Enums;

namespace demoblaze_selenium_csharp.Values
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