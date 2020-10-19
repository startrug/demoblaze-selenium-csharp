using System.Collections.Generic;
using System.Linq;
using demoblaze_selenium_csharp.Pages;
using demoblaze_selenium_csharp.Values;

namespace demoblaze_selenium_csharp.Tests
{
    public class CartAndOrderTestsBase : BaseTest<HomePage>
    {
        protected static List<Product> GnerateListOfProducts(params Product[] products)
            => products.Select(p => p).ToList();

        protected override HomePage SelectTestedAppPage()
            => NavigationBar.ClickHomeLink();

        protected int totalAmount = 0;
    }
}