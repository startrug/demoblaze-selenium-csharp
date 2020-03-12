using System;
using demoblaze_selenium_csharp.Enum;
using demoblaze_selenium_csharp.Tests;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class HomePage : BasePage
    {
        public const string HomePageTitle = "STORE";

        public HomePage(IWebDriver driver) : base(driver) { }

        internal void GoTo() => Driver.Navigate().GoToUrl(HomePageUrl);

        internal bool IsPageOpened() => Driver.FindElement(HomeLinkLocator).Displayed;

        internal bool IsPageTitleCorrect() => Driver.Title == HomePageTitle;

        public T ClickLink<T>(LinkText link)
        {
            switch (link)
            {
                case LinkText.Home:
                    Click(HomeLinkLocator);
                    return (T)Convert.ChangeType(new HomePage(Driver), typeof(T));
                case LinkText.Contact:
                    Click(ContactLinkLocator);
                    return (T)Convert.ChangeType(new ContactWindow(Driver), typeof(T));
                case LinkText.AboutUs:
                    Click(AboutUsLinkLocator);
                    return (T)Convert.ChangeType(new AboutUsWindow(Driver), typeof(T));
                case LinkText.Cart:
                    Click(CartLinkLocator);
                    return (T)Convert.ChangeType(new CartPage(Driver), typeof(T));
                case LinkText.LogIn:
                    Click(LogInLinkLocator);
                    return (T)Convert.ChangeType(new LogInWindow(Driver), typeof(T));
                case LinkText.SignUp:
                    Click(SignUpLinkLocator);
                    return (T)Convert.ChangeType(new SignUpWindow(Driver), typeof(T));
                default:
                    throw new Exception("No such link text");
            }
        }

        public ProductPage SelectProductAndOpenProductPage(Category category, string productName)
        {
            SelectCategory(category);
            WaitForElementAndClickOnIt(ProductLocator(productName));
            return new ProductPage(Driver);
        }

        public void SelectCategory(Category category)
        {
            switch (category)
            {
                case Category.Phones:
                    Click(PhonesCategoryLocator);
                    break;
                case Category.Laptops:
                    Click(LaptopsCategoryLocator);
                    break;
                case Category.Monitors:
                    Click(MonitorsCategoryLocator);
                    break;
                default:
                    throw new Exception("No such product category");
            }
        }

        public By ProductLocator(string productName) => By.XPath($"//a[text()='{productName}']");

        public string HomePageUrl => "https://www.demoblaze.com/index.html";

        public By HomeLinkLocator => By.PartialLinkText("Home");
        public By ContactLinkLocator => By.LinkText("Contact");
        public By AboutUsLinkLocator => By.LinkText("About us");
        public By CartLinkLocator => By.Id("cartur");
        public By LogInLinkLocator => By.Id("login2");
        public By SignUpLinkLocator => By.Id("signin2");


        public By PhonesCategoryLocator => By.CssSelector("[onclick=\"byCat('phone')\"]");
        public By LaptopsCategoryLocator => By.CssSelector("[onclick=\"byCat('notebook')\"]");
        public By MonitorsCategoryLocator => By.CssSelector("[onclick=\"byCat('monitor')\"]");
    }
}