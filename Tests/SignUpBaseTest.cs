using demoblaze_selenium_csharp.Enum;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    public abstract class SignUpBaseTest : BaseTest
    {
        [SetUp]
        public virtual void SetupBeforeEverySignUpTest()
        {
            SignUpWindow = DemoBlazeHomePage.ClickLink<SignUpWindow>(LinkText.SignUp);
        }
    }
}
