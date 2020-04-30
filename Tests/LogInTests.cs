using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("LogInTests")]
    public class LogInTests : LogInBaseTest
    {
        [Test, Order(1)]
        public void WhenCustomerOpensLogInWindow_ThenWindowIsOpened()
        {
            Assert.That(TestedPageOrWindow.IsWindowOpened(), Is.True);
        }

        [Test, Order(2)]
        public void GivenSignedUpCustomerNameAndWrongPassword_WhenCustomerFilledOutLogInFormUsingIncorrectPassword_ThenFailedWrongPasswordAlertIsShowed()
        {
            TestUser.Password = "qwerty123";
            TestedPageOrWindow.FillOutFormWithBrowserAlert(TestUser);

            Assert.That(TestedPageOrWindow.IsWrongPasswordAlertShowed(), Is.True);
        }

        [Test, Order(3)]
        public void WhenCustomerDidNotFillOutLogInFormAndAcceptIt_ThenCompleteFormAlertIsShowed()
        {
            TestedPageOrWindow.FillOutFormWithBrowserAlert(TestUserWithMissingData);

            Assert.That(TestedPageOrWindow.IsRequestToCompleteFormAlertIsShowed(), Is.True);
        }

        [Test, Order(4)]
        public void GivenSignedUpUserNameAndPassword_WhenUserFilledOutLogInForm_ThenSuccessfullLoggedInInAlertIsShowed()
        {
            var loggedInUserHomePage = TestedPageOrWindow.FillOutFormAndLogIn(TestUser);

            Assert.That(loggedInUserHomePage.IsUserLoggedInSuccessfully(), Is.True);
        }
    }
}
