using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class LogInTests : LogInBaseTest
    {
        public override void SetupBeforeEveryLogInTest() => base.SetupBeforeEveryLogInTest();

        [Test, Order(11)]
        public void WhenUserOpensLogInWindow_ThenWindowIsOpened()
        {
            Assert.That(LogInWindow.IsWindowOpened(), Is.True);
        }

        [Test, Order(12)]
        public void GivenSignedUpUserNameAndWrongPassword_WhenUserFilledOutLogInFormUsingIncorrectPassword_ThenFailedWrongPasswordAlertIsShowed()
        {
            TestUserData.Password = "qwerty123";
            LogInWindow.FillOutFormWithBrowserAlert(TestUserData);

            Assert.That(LogInWindow.IsWrongPasswordAlertShowed(), Is.True);
        }

        [Test, Order(13)]
        public void WhenUserDidNotFillOutLogInFormAndAcceptIt_ThenRequestToCompleteFormAlertIsShowed()
        {
            LogInWindow.FillOutFormWithBrowserAlert(TestUserWithMissingData);

            Assert.That(LogInWindow.IsRequestToCompleteFormAlertIsShowed(), Is.True);
        }

        [Test, Order(14)]
        public void GivenSignedUpUserNameAndPassword_WhenUserFilledOutLogInForm_ThenSuccessfullloggedInInAlertIsShowed()
        {
            LoggedInUserHomePage = LogInWindow.FillOutFormAndLogIn(TestUserData);

            Assert.That(LoggedInUserHomePage.IsUserLoggedInSuccessfully(), Is.True);
        }
    }
}
