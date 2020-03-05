using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace demoblaze_selenium_csharp.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;
        private WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
        
        protected void Click(By locator)
        {
            _driver.FindElement(locator).Click();
        }

        protected void SetText(By locator, string text)
        {
            IWebElement webElement = LocateElement(locator);
            webElement.SendKeys(text);
        }

        protected IWebElement LocateElement(By locator) => _driver.FindElement(locator);

        protected bool IsElementDisplayed(By locator) => LocateElement(locator).Displayed;                      

        protected bool WaitForElementVisibility(By locator)
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _wait.Until(EC.ElementIsVisible(locator));
            return _driver.FindElement(locator).Displayed;
        }               
    }
}