using System;
using demoblaze_selenium_csharp.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace demoblaze_selenium_csharp.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Alert = new Alerts(driver);
        }

        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Wait { get; set; }
        protected Alerts Alert { get; set; }

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
            Wait.Until(EC.ElementIsVisible(locator));
            return LocateElement(locator).Displayed;
        }

        public bool WaitForElementDisappear(By locator)
        {
            try
            {
                Wait.Until(EC.InvisibilityOfElementLocated(locator));
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Element is still visible");
            }
        }

        public void WaitForElementAndClickOnIt(By locator)
        {
            Wait.Until(EC.ElementIsVisible(locator)).Click();
        }

        protected void WaitForBrowserAlert() => Wait.Until(EC.AlertIsPresent());
    }
}