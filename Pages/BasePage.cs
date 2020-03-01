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

        protected IWebElement IsElementPresent(By locator) => _driver.FindElement(locator);

        public By NewWindowLocator => By.ClassName("modal-content");
        protected string WindowContentLocator => "//div[@class='modal-content']";
        public By CloseLocator => By.XPath("//div[@id='exampleModal']//button[text()='Close']");


        internal void ClickClose()
        {
            WaitForElementVisibility(NewWindowLocator);
            Click(CloseLocator);
        }

        internal bool IsWindowClosed() => IsElementPresent(NewWindowLocator).Displayed;        

        protected bool WaitForElementVisibility(By locator)
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _wait.Until(EC.ElementIsVisible(locator));
            return _driver.FindElement(locator).Displayed;
        }

        public bool IsWindowOpened(WindowType windowType)
        {
            switch (windowType)
            {
                case WindowType.Contact:
                    return WaitForElementVisibility(By.XPath($"//div[@id='exampleModal']" +
                        $"{WindowContentLocator}"));                    
                case WindowType.AboutUs:
                    return WaitForElementVisibility(By.XPath($"//div[@id='videoModal']" +
                        $"{WindowContentLocator}"));                    
                case WindowType.LogIn:
                    return WaitForElementVisibility(By.XPath($"//div[@id='logInModal']" +
                        $"{WindowContentLocator}"));                    
                case WindowType.SignUp:
                    return WaitForElementVisibility(By.XPath($"//div[@id='signInModal']" +
                        $"{WindowContentLocator}"));                    
                default:
                    throw new Exception("Incorrect window type");
            }
        }
    }
}