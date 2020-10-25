using demoblaze_selenium_csharp.Models;
using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("LogInTests")]
    public class LogInTests : BaseTest<LogInWindow>
    {
        [Test]
        public void WhenCustomerOpensLogInWindow_ThenWindowIsOpened()
        {
            Assert.IsTrue(TestedPageOrWindow.IsWindowOpened());
        }

        [Test]
        public void GivenSignedUpCustomerNameAndWrongPassword_WhenCustomerFilledOutLogInFormUsingIncorrectPassword_ThenFailedWrongPasswordAlertIsShowed()
        {
            User.Password = "qwerty123";
            TestedPageOrWindow.FillOutFormWithBrowserAlert(User);

            Assert.IsTrue(TestedPageOrWindow.IsWrongPasswordAlertShowed());
        }

        [Test]
        public void WhenCustomerDidNotFillOutLogInFormAndAcceptIt_ThenCompleteFormAlertIsShowed()
        {
            TestedPageOrWindow.FillOutFormWithBrowserAlert(new User() { Name = string.Empty, Password = string.Empty });

            Assert.IsTrue(TestedPageOrWindow.IsRequestToCompleteFormAlertIsShowed());
        }

        [Test]
        public void GivenSignedUpUserNameAndPassword_WhenUserFilledOutLogInForm_ThenSuccessfullLoggedInInAlertIsShowed()
        {
            var loggedInUserHomePage = TestedPageOrWindow.FillOutFormAndLogIn(User);

            Assert.IsTrue(loggedInUserHomePage.IsUserLoggedInSuccessfully());
        }

        protected override LogInWindow SelectTestedAppPage()
            => NavigationBar.ClickLogInLink();
    }
}
