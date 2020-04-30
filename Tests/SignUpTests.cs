using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("SignUpTests")]
    public class SignUpTests : BaseTest<SignUpWindow>
    {
        [Test]
        public void WhenUserOpensSignUpWindow_ThenWindowIsOpened()
        {
            Assert.That(TestedPageOrWindow.IsWindowOpened(), Is.True);
        }

        [Test]
        public void GivenNonExistingUserNameAndPassword_WhenUserFilledOutSignUpForm_ThenSuccessfullSigningInAlertIsShowed()
        {
            TestedPageOrWindow.FillOutFormWithBrowserAlert(TestUser);

            Assert.That(TestedPageOrWindow.IsUserSignedInSuccessfullyAlertShowed, Is.False);
        }

        [Test]
        public void GivenExistingUserNameAndPassword_WhenUserFilledOutSignUpForm_ThenSuccessfullSigningInAlertIsShowed()
        {
            TestedPageOrWindow.FillOutFormWithBrowserAlert(TestUser);

            Assert.That(TestedPageOrWindow.IsUserAlreadyExistaAlertShowed, Is.True);
        }

        [Test]
        public void WhenUserDidNotFillOutSignUpFormAndAcceptIt_ThenRequestToCompleteFormAlertIsShowed()
        {
            TestedPageOrWindow.FillOutFormWithBrowserAlert(TestUserWithMissingData);

            Assert.That(TestedPageOrWindow.IsRequestToCompleteFormAlertIsShowed, Is.True);
        }

        protected override SignUpWindow SelectTestedAppPage()
            => NavigationBar.ClickSignUpLink();
    }
}
