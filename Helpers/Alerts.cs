using demoblaze_selenium_csharp.Pages;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Helpers
{
    public class Alerts : BasePage
    {
        public Alerts(IWebDriver driver) : base(driver) { }

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
