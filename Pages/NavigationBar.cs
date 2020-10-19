using System.Threading;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class NavigationBar : BasePage
    {
        public NavigationBar(IWebDriver driver) : base(driver) { }

        internal ContactWindow ClickContactLink()
        {
            Click(By.LinkText("Contact"));

            return new ContactWindow(Driver);
        }

        internal SignUpWindow ClickSignUpLink()
        {
            Click(By.Id("signin2"));

            return new SignUpWindow(Driver);
        }

        internal LogInWindow ClickLogInLink()
        {
            Click(By.Id("login2"));

            return new LogInWindow(Driver);
        }

        internal CartPage ClickCartLink()
        {
            Click(By.Id("cartur"));
            Thread.Sleep(500);

            return new CartPage(Driver);
        }

        internal HomePage ClickHomeLink()
        {
            Click(HomeLinkLocator);

            return new HomePage(Driver);
        }

        internal AboutUsWindow ClickAboutLink()
        {
            Click(By.LinkText("About us"));

            return new AboutUsWindow(Driver);
        }
    }
}