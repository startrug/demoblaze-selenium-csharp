using System.Collections.Generic;
using demoblaze_selenium_csharp.Values;

namespace demoblaze_selenium_csharp.Tests
{
    public class CartBaseTest : BaseTest
    {
        protected static List<Product> GnerateListOfProducts(params Product[] products)
        {
            List<Product> productList = new List<Product>();
            foreach (var product in products)
            {
                productList.Add(product);
            }
            return productList;
        }
    }
}