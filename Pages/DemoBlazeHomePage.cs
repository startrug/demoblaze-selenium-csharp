using System;
using demoblaze_selenium_csharp.Tests;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class DemoBlazeHomePage : BasePage
    {
        public DemoBlazeHomePage(IWebDriver driver) : base(driver) { }
        
        public string HomePageUrl => "https://www.demoblaze.com/index.html";

        public By NavbarLocator => By.Id("navbarExample");

        public By ContactLinkLocator => By.LinkText("Contact");

        public By AboutUsLocator => By.LinkText("About us");

        public By CartLocator => By.Id("cartur");

        public const string HomePageTitle = "STORE";

        internal void GoTo()
        {
            _driver.Navigate().GoToUrl(HomePageUrl);
        }

        internal bool IsPageOpened() => _driver.FindElement(NavbarLocator).Displayed;

        internal bool IsPageTitleCorrect() => _driver.Title == HomePageTitle;

        internal ContactPage ClickContactLink()        {

            Click(ContactLinkLocator);            
            return new ContactPage(_driver);
        }

        internal AboutUsPage ClickAboutUsLink()
        {
            Click(AboutUsLocator);
            return new AboutUsPage(_driver);
        }

        internal CartPage ClickCartLink()
        {
            Click(CartLocator);
            return new CartPage(_driver);
        }
    }
}