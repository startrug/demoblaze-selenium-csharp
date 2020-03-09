using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class SignUpTests : SignUpBaseTest
    {
        public override void SetupBeforeEverySignUpTest() => base.SetupBeforeEverySignUpTest();

        [Test]
        public void GivenNonExistingUserNameAndPassword_WhenUserFilledOutSignUpForm_ThenSuccessfullSigningInAlertIsShowed()
        {
            SignUpWindow.FillOutForm(TestUserData);

            Assert.That(SignUpWindow.IsUserSignedInSuccessfullyAlert, Is.False);
        }

        [Test]
        public void GivenExistingUserNameAndPassword_WhenUserFilledOutSignUpForm_ThenSuccessfullSigningInAlertIsShowed()
        {
            SignUpWindow.FillOutForm(TestUserData);

            Assert.That(SignUpWindow.IsUserAlreadyExistingAlert, Is.True);
        }

        [Test]
        public void WhenUserDidNotFillOutSignUpFormAndAcceptIt_ThenFailedSigningInAlertIsShowed()
        {
            SignUpWindow.FillOutForm(TestUserWithMissingData);

            Assert.That(SignUpWindow.IsUserDidNotEnterRequiredDataAlert, Is.True);
        }

        [Test, Order(7)]
        public void WhenUserOpensSignUpWindow_ThenWindowIsOpened()
        {
            Assert.That(SignUpWindow.IsWindowOpened(), Is.True);
        }
    }
}
