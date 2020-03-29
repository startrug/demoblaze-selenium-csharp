using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture, Category("SignUpTests")]
    public class SignUpTests : SignUpBaseTest
    {
        public override void SetupBeforeEverySignUpTest() => base.SetupBeforeEverySignUpTest();

        [Test, Order(7)]
        public void GivenNonExistingUserNameAndPassword_WhenUserFilledOutSignUpForm_ThenSuccessfullSigningInAlertIsShowed()
        {
            SignUpWindow.FillOutFormWithBrowserAlert(TestUser);

            Assert.That(SignUpWindow.IsUserSignedInSuccessfullyAlertShowed, Is.False);
        }

        [Test, Order(8)]
        public void GivenExistingUserNameAndPassword_WhenUserFilledOutSignUpForm_ThenSuccessfullSigningInAlertIsShowed()
        {
            SignUpWindow.FillOutFormWithBrowserAlert(TestUser);

            Assert.That(SignUpWindow.IsUserAlreadyExistaAlertShowed, Is.True);
        }

        [Test, Order(9)]
        public void WhenUserDidNotFillOutSignUpFormAndAcceptIt_ThenRequestToCompleteFormAlertIsShowed()
        {
            SignUpWindow.FillOutFormWithBrowserAlert(TestUserWithMissingData);

            Assert.That(SignUpWindow.IsRequestToCompleteFormAlertIsShowed, Is.True);
        }

        [Test, Order(10)]
        public void WhenUserOpensSignUpWindow_ThenWindowIsOpened()
        {
            Assert.That(SignUpWindow.IsWindowOpened(), Is.True);
        }
    }
}
