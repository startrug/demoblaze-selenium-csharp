using System.Collections.Generic;
using System.Linq;
using demoblaze_selenium_csharp.Values;

namespace demoblaze_selenium_csharp.Tests
{
    public class CartBaseTest : BaseTest
    {
        protected static List<Product> GnerateListOfProducts(params Product[] products)
            => products.Select(p => p).ToList();
    }
}