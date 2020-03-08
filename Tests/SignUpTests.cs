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

            Assert.That(SignUpWindow.IsUserSignedInSuccessfully, Is.True);
        }

        [Test]
        public void GivenExistingUserNameAndPassword_WhenUserFilledOutSignUpForm_ThenSuccessfullSigningInAlertIsShowed()
        {
            SignUpWindow = DemoBlazeHomePage.ClickSignUpLink();

            SignUpWindow.FillOutForm(TestUserData);

            Assert.That(SignUpWindow.IsUserAlreadyExisting, Is.False);
        }

        [Test]
        public void WhenUserDidNotFillOutSignUpFormAndAcceptIt_ThenFailedSigningInAlertIsShowed()
        {
            SignUpWindow = DemoBlazeHomePage.ClickSignUpLink();

            SignUpWindow.FillOutForm(TestUserWithMissingData);

            Assert.That(SignUpWindow.IsUserDidNotEnterRequiredData, Is.True);
        }
    }
}
