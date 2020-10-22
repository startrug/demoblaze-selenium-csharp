using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Helpers
{
    public class Alerts
    {
        public Alerts(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsBrowserAlertContainsExpectedMessage(string exepectedAlertMessage)
        {
            string currentAlert = GetAlertTextAndAcceptAlert();
            return exepectedAlertMessage == currentAlert;
        }

        public string GetAlertTextAndAcceptAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            var alertMessage = alert.Text;
            alert.Accept();
            return alertMessage;
        }

        private readonly IWebDriver driver;
    }
}
