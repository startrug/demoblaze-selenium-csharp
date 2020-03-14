using System.Collections.Generic;
using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Values;

namespace demoblaze_selenium_csharp.Tests
{
    public class CartBaseTest : BaseTest
    {
        protected Product NewMonitor = new Product(Category.Monitors, "ASUS Full HD");
        protected Product NewPhone = new Product(Category.Phones, "Samsung galaxy s6");
        protected Product NewNotebook = new Product(Category.Laptops, "MacBook Pro");

        protected static List<Product> GnerateListOfProducts(params Product[] products)
        {
            List<Product> productList = new List<Product>();
            foreach (var product in products)
            {
                productList.Add(product);
            }
            return productList;
        }

        public int TotalOrder { get; set; } = 0;
    }
}