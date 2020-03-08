using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class SignUpTests : BaseTest
    {
        [Test]
        public void GivenNonExistingUserNameAndPassword_WhenUserFilledOutSignUpForm_ThenSuccessfullSigningInAlertIsShowed()
        {
            SignUpWindow = DemoBlazeHomePage.ClickSignUpLink();

            SignUpWindow.FillOutForm(TestUserData);

            Assert.That(SignUpWindow.IsUserSignedInSuccessfullyAlert, Is.False);
        }

        [Test]
        public void GivenExistingUserNameAndPassword_WhenUserFilledOutSignUpForm_ThenSuccessfullSigningInAlertIsShowed()
        {
            SignUpWindow = DemoBlazeHomePage.ClickSignUpLink();

            SignUpWindow.FillOutForm(TestUserData);

            Assert.That(SignUpWindow.IsUserAlreadyExistingAlert, Is.True);
        }

        [Test]
        public void WhenUserDidNotFillOutSignUpFormAndAcceptIt_ThenFailedSigningInAlertIsShowed()
        {
            SignUpWindow = DemoBlazeHomePage.ClickSignUpLink();

            SignUpWindow.FillOutForm(TestUserWithMissingData);

            Assert.That(SignUpWindow.IsUserDidNotEnterRequiredDataAlert, Is.True);
        }
    }
}
