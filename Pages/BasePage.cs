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
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Alert = new Alerts(driver);
        }

        protected IWebDriver Driver { get; private set; }
        protected WebDriverWait Wait { get; private set; }
        protected Alerts Alert { get; set; }

        protected void Click(By locator) => Driver.FindElement(locator).Click();

        protected void SetText(By locator, string text) => LocateElement(locator).SendKeys(text);

        protected string GetTextOfElement(By locator) => LocateElement(locator).Text;

        protected IWebElement LocateElement(By locator) => Driver.FindElement(locator);

        protected IWebElement GetElementAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator));

        protected bool IsElementDisplayedImmediately(By locator) => LocateElement(locator).Displayed;

        protected bool IsElementDisplayedAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator)).Displayed;

        protected bool IsElementDisappearedAfterWaiting(By locator)
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

        protected bool IsBrowserAlertShowed(string alertType) => Alert.IsBrowserAlertContainsExpectedMessage(alertType);

        protected void ClickOnElementAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator)).Click();
        protected void ClickOnClickableElement(By locator) => Wait.Until(EC.ElementToBeClickable(locator)).Click();
        protected void ClickOnExistingElement(By locator) => Wait.Until(EC.ElementExists(locator)).Click();
        protected IWebElement WaitAndFind(By locator)
        {
            Wait.Until(EC.ElementIsVisible(locator));
            return Driver.FindElement(locator);
        }

        protected void WaitForBrowserAlert() => Wait.Until(EC.AlertIsPresent());

        protected By HomeLinkLocator => By.PartialLinkText("Home");
    }
}