using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class LogInTests : BaseTest
    {
        [Test]
        public void GivenSignedUpUserNameAndPassword_WhenUserFilledOutLogInForm_ThenSuccessfullloggedInInAlertIsShowed()
        {
            LogInWindow = DemoBlazeHomePage.ClickLogInLink();

            LoggedInUserHomePage = LogInWindow.FillOutFormAndLogIn(TestUserData);

            Assert.That(LoggedInUserHomePage.IsUserLoggedInSuccessfully(), Is.True);
        }
    }
}
