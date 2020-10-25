using Bogus;
using demoblaze_selenium_csharp.Models;
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
            Assert.IsTrue(TestedPageOrWindow.IsWindowOpened());
        }

        [Test]
        public void GivenNonExistingUserNameAndPassword_WhenUserFilledOutSignUpForm_ThenSuccessfullSigningInAlertIsShowed()
        {
            var fakeUser = GenerateFakeUser();

            TestedPageOrWindow.FillOutFormWithBrowserAlert(fakeUser);

            Assert.IsTrue(TestedPageOrWindow.IsUserSignedInSuccessfullyAlertShowed());
        }

        [Test]
        public void GivenExistingUserNameAndPassword_WhenUserFilledOutSignUpForm_ThenSuccessfullSigningInAlertIsShowed()
        {
            TestedPageOrWindow.FillOutFormWithBrowserAlert(User);

            Assert.IsTrue(TestedPageOrWindow.IsUserAlreadyExistaAlertShowed());
        }

        [Test]
        public void WhenUserDidNotFillOutSignUpFormAndAcceptIt_ThenRequestToCompleteFormAlertIsShowed()
        {
            TestedPageOrWindow.FillOutFormWithBrowserAlert(new User() { Name = string.Empty, Password = string.Empty });

            Assert.IsTrue(TestedPageOrWindow.IsRequestToCompleteFormAlertIsShowed());
        }

        protected override SignUpWindow SelectTestedAppPage()
            => NavigationBar.ClickSignUpLink();

        private User GenerateFakeUser()
        {
            var faker = new Faker("pl");
            return new User()
            {
                Name = faker.Name.FirstName(),
                Password = faker.Internet.Password()
            };
        }
    }
}
