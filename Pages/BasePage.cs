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

        protected IWebElement WaitForElement(By locator)
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _wait.Until(EC.ElementIsVisible(locator));
            return _driver.FindElement(locator);
        }
    }
}