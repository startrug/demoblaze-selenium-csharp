using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace demoblaze_selenium_csharp.Pages
{
    public class ContactPage : BasePage
    {
        private WebDriverWait _wait;

        public ContactPage(IWebDriver driver) : base(driver) { }

        public By NewWindowLocator => By.ClassName("modal-content");

        internal bool ContactPageIsOpened() => WaitForElement(NewWindowLocator).Displayed;

        private IWebElement WaitForElement(By locator)
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _wait.Until(EC.ElementIsVisible(locator));
            return _driver.FindElement(locator);
        }
    }
}