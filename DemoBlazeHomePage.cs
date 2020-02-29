using System;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp
{
    internal class DemoBlazeHomePage
    {
        private readonly IWebDriver _driver;

        public DemoBlazeHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string HomePageUrl => "https://www.demoblaze.com/index.html";

        public By NavbarLocator => By.Id("navbarExample");

        internal void GoTo()
        {
            _driver.Navigate().GoToUrl(HomePageUrl);
        }

        internal bool PageIsOpened() => _driver.FindElement(NavbarLocator).Displayed;
        
    }
}