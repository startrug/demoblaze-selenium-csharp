using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace demoblaze_selenium_csharp.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected void Click(By locator) => Driver.FindElement(locator).Click();

        protected void SetText(By locator, string text)
        {
            IWebElement webElement = LocateElement(locator);
            webElement.SendKeys(text);
        }

        public string GetTextOfElement(By locator)
        {
            return LocateElement(locator).Text;
        }

        protected IWebElement LocateElement(By locator) => Driver.FindElement(locator);

        protected bool IsElementDisplayed(By locator) => LocateElement(locator).Displayed;

        protected bool WaitForElementVisibility(By locator)
        {
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(EC.ElementIsVisible(locator));
            return Driver.FindElement(locator).Displayed;
        }

        protected void WaitForBrowserAlert() => Wait.Until(EC.AlertIsPresent());
    }
}