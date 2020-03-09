﻿using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class LogInTests : LogInBaseTest
    {
        public override void SetupBeforeEveryLogInTest() => base.SetupBeforeEveryLogInTest();

        [Test, Order(6)]
        public void WhenUserOpensLogInWindow_ThenWindowIsOpened()
        {
            Assert.That(LogInWindow.IsWindowOpened(), Is.True);
        }

        [Test]
        public void GivenSignedUpUserNameAndPassword_WhenUserFilledOutLogInForm_ThenSuccessfullloggedInInAlertIsShowed()
        {
            LoggedInUserHomePage = LogInWindow.FillOutFormAndLogIn(TestUserData);

            Assert.That(LoggedInUserHomePage.IsUserLoggedInSuccessfully(), Is.True);
        }
    }
}
