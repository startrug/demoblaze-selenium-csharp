using demoblaze_selenium_csharp.Enum;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    public class CartBaseTest : BaseTest
    {
        [SetUp]
        public virtual void SetupBeforeEveryContactTest()
        {
            CartPage = DemoBlazeHomePage.ClickLink<CartPage>(LinkText.Cart);
        }
    }
}