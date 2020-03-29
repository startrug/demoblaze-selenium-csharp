using System;
using System.Threading;
using demoblaze_selenium_csharp.Enums;
using demoblaze_selenium_csharp.Helpers;
using demoblaze_selenium_csharp.Tests;
using demoblaze_selenium_csharp.Values;
using OpenQA.Selenium;
using ReportingLibrary;

namespace demoblaze_selenium_csharp.Pages
{
    public class HomePage : BasePage
    {
        public const string HomePageTitle = "STORE";

        public HomePage(IWebDriver driver) : base(driver) { }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl(HomePageUrl);
            Reporter.LogPassingTestStep($"Opening demoblaze.com homepage");
        }

        internal bool IsPageOpened()
        {
            var testStepResult = Driver.FindElement(HomeLinkLocator).Displayed;
            LoggerHelpers.LogInfoAboutPageOrWindowOpening("Homepage");
            return testStepResult;
        }

        internal bool IsPageTitleCorrect()
        {
            var testStepResult = Driver.Title == HomePageTitle;
            Reporter.LogTestStep(
                testStepResult,
                "Page title is correct",
                $"Expected page title was {HomePageTitle} but actual page title is: {Driver.Title}"
                );
            return testStepResult;
        }

        public T ClickLink<T>(LinkText link)
        {
            switch (link)
            {
                case LinkText.Home:
                    Click(HomeLinkLocator);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("Homepage");
                    return (T)Convert.ChangeType(new HomePage(Driver), typeof(T));
                case LinkText.Contact:
                    Click(ContactLinkLocator);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("Contact window");
                    return (T)Convert.ChangeType(new ContactWindow(Driver), typeof(T));
                case LinkText.AboutUs:
                    Click(AboutUsLinkLocator);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("About us window");
                    return (T)Convert.ChangeType(new AboutUsWindow(Driver), typeof(T));
                case LinkText.Cart:
                    Click(CartLinkLocator);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("Cart page");
                    Thread.Sleep(500);
                    return (T)Convert.ChangeType(new CartPage(Driver), typeof(T));
                case LinkText.LogIn:
                    Click(LogInLinkLocator);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("Log in window");
                    return (T)Convert.ChangeType(new LogInWindow(Driver), typeof(T));
                case LinkText.SignUp:
                    Click(SignUpLinkLocator);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("Sign up window");
                    return (T)Convert.ChangeType(new SignUpWindow(Driver), typeof(T));
                default:
                    throw new Exception("No such link text");
            }
        }

        public ProductPage SelectProductAndOpenProductPage(Product product)
        {
            SelectCategory(product.Category);
            Reporter.LogPassingTestStep($"Category \"{product.Category}\" has been selected");
            ClickOnElementAfterWaiting(ProductLocator(product.ProductName));
            Reporter.LogPassingTestStep($"Product \"{product.ProductName}\" has been selected");
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