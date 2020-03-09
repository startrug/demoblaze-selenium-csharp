using demoblaze_selenium_csharp.Enum;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    public class ContactBaseTest : BaseTest
    {
        [SetUp]
        public virtual void SetupBeforeEveryContactTest()
        {
            ContactWindow = DemoBlazeHomePage.ClickLink<ContactWindow>(LinkText.Contact);
        }
    }
}
