using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class LogInTests : LogInBaseTest
    {
        public override void SetupBeforeEveryLogInTest() => base.SetupBeforeEveryLogInTest();

        [Test, Order(11)]
        public void WhenCustomerOpensLogInWindow_ThenWindowIsOpened()
        {
            Assert.That(LogInWindow.IsWindowOpened(), Is.True);
        }

        [Test, Order(12)]
        public void GivenSignedUpCustomerNameAndWrongPassword_WhenCustomerFilledOutLogInFormUsingIncorrectPassword_ThenFailedWrongPasswordAlertIsShowed()
        {
            TestUser.Password = "qwerty123";
            LogInWindow.FillOutFormWithBrowserAlert(TestUser);

            Assert.That(LogInWindow.IsWrongPasswordAlertShowed(), Is.True);
        }

        [Test, Order(13)]
        public void WhenCustomerDidNotFillOutLogInFormAndAcceptIt_ThenCompleteFormAlertIsShowed()
        {
            LogInWindow.FillOutFormWithBrowserAlert(TestUserWithMissingData);

            Assert.That(LogInWindow.IsRequestToCompleteFormAlertIsShowed(), Is.True);
        }

        [Test, Order(14)]
        public void GivenSignedUpUserNameAndPassword_WhenUserFilledOutLogInForm_ThenSuccessfullLoggedInInAlertIsShowed()
        {
            LoggedInUserHomePage = LogInWindow.FillOutFormAndLogIn(TestUser);

            Assert.That(LoggedInUserHomePage.IsUserLoggedInSuccessfully(), Is.True);
        }
    }
}
