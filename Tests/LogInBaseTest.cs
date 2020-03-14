using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    public abstract class LogInBaseTest : BaseTest
    {
        [SetUp]
        public virtual void SetupBeforeEveryLogInTest()
        {
            LogInWindow = DemoBlazeHomePage.ClickLink<LogInWindow>(LinkText.LogIn);
        }
    }
}
