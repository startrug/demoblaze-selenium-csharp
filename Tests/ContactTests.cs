﻿using demoblaze_selenium_csharp.Pages;
using NUnit.Framework;

namespace demoblaze_selenium_csharp.Tests
{
    [TestFixture]
    public class ContactTests : ContactBaseTest
    {
        public override void SetupBeforeEveryContactTest() => base.SetupBeforeEveryContactTest();

        [Test, Order(2)]
        public void WhenUserOpensContactPage_ThenPageIsOpened()
        {
            Assert.That(ContactWindow.IsWindowOpened(), Is.True);
        }

        [Test, Order(3)]
        public void GivenUserContactFormData_WhenUserFillOutContactFormAndClickSendMessageButton_ThenMessageIsSent()
        {
            ContactWindow.FillOutFormWithBrowserAlert(TestCustomerData);

            Assert.That(ContactWindow.IsMessageSentSuccessfully, Is.True);
        }

        [Test, Order(4)]
        public void WhenUserClosesContactPage_ThenPageIsClosed()
        {
            ContactWindow.ClickCloseWindow();

            Assert.That(ContactWindow.IsWindowClosed(), Is.True);
        }
    }
}
