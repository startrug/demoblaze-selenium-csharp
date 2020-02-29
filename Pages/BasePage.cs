using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}