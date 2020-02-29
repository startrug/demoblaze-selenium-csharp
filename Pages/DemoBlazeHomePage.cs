using System;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class DemoBlazeHomePage : BasePage
    {
        public DemoBlazeHomePage(IWebDriver driver) : base(driver) { }
        
        public string HomePageUrl => "https://www.demoblaze.com/index.html";

        public By NavbarLocator => By.Id("navbarExample");

        public By ContactLickLocator => By.LinkText("Contact");

        public const string HomePageTitle = "STORE";

        internal void GoTo()
        {
            _driver.Navigate().GoToUrl(HomePageUrl);
        }

        internal bool PageIsOpened() => _driver.FindElement(NavbarLocator).Displayed;

        internal bool PageTitleIsCorrect() => _driver.Title == HomePageTitle;

        internal ContactPage ClickContactLink()        {
            
            _driver.FindElement(ContactLickLocator).Click();
            return new ContactPage(_driver);
        }        
    }
}