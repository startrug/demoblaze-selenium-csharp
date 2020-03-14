using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Helpers
{
    public class Alerts
    {
        protected IWebDriver Driver { get; set; }

        public Alerts(IWebDriver driver)
        {
            Driver = driver;
        }

        public bool IsBrowserAlertContainsExpectedMessage(string exepectedAlertMessage)
        {
            string currentAlert = GetAlertTextAndAcceptAlert();
            return exepectedAlertMessage == currentAlert;
        }

        public string GetAlertTextAndAcceptAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            var alertMessage = alert.Text;
            alert.Accept();
            return alertMessage;
        }
    }
}
