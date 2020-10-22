using System.Threading;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class NavigationBar : BasePage
    {
        public NavigationBar(IWebDriver driver) : base(driver) { }

        public ContactWindow ClickContactLink()
        {
            Click(By.LinkText("Contact"));

            return new ContactWindow(Driver);
        }

        public SignUpWindow ClickSignUpLink()
        {
            Click(By.Id("signin2"));

            return new SignUpWindow(Driver);
        }

        public LogInWindow ClickLogInLink()
        {
            Click(By.Id("login2"));

            return new LogInWindow(Driver);
        }

        public CartPage ClickCartLink()
        {
            Click(By.Id("cartur"));
            Thread.Sleep(500);

            return new CartPage(Driver);
        }

        public HomePage ClickHomeLink()
        {
            Click(HomeLinkLocator);

            return new HomePage(Driver);
        }

        public AboutUsWindow ClickAboutLink()
        {
            Click(By.LinkText("About us"));

            return new AboutUsWindow(Driver);
        }
    }
}