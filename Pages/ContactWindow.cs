using System;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class ContactWindow : BaseWindow
    {
        private string alertMessage;
        private readonly string exepectedAlertMessage = "Thanks for the message!!";

        public ContactWindow(IWebDriver driver) : base(driver) { }        

        public override bool IsWindowOpened() => WaitForElementVisibility(WindowLocator);

        public override bool IsWindowClosed() => IsElementDisplayed(WindowLocator);

        public void FillOutContactForm(ContactFormData contactFormData)
        {
            WaitForElementVisibility(WindowLocator);
            SetUserEmail(contactFormData);
            SetUserName(contactFormData);
            SetUserMessage(contactFormData);
            Click(SendMessageButtonLocator);
        }

        internal bool IsMessageSentSuccessfully() 
            => IsBrowserAlertContainsExpectedMessage();

        private bool IsBrowserAlertContainsExpectedMessage()
        {            
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                alertMessage = alert.Text;                
                alert.Accept();
            }
            catch (NoAlertPresentException exception)
            {
                Console.WriteLine(exception.Message);                
            }
            return exepectedAlertMessage == alertMessage;
        }

        private void SetUserEmail(ContactFormData contactFormData) => 
            SetText(EmailInputLocator, contactFormData.Email);

        private void SetUserName(ContactFormData contactFormData) 
            => SetText(NameInputLocator, contactFormData.Name);       
        
        private void SetUserMessage(ContactFormData contactFormData)
            => SetText(NameInputLocator, contactFormData.Name);

        public override void ClickCloseWindow()
        {
            WaitForElementVisibility(CloseWindowLocator);
            Click(CloseWindowLocator);
        }

        public override By WindowLocator => By.XPath(ContactWindowXpath + base.WindowXpath);
        public override By CloseWindowLocator => By.XPath(ContactWindowXpath + base.WindowXpath);
        public string ContactWindowXpath => "//div[@id='exampleModal']";
        public By EmailInputLocator => By.Id("recipient-email");
        public By NameInputLocator => By.Id("recipient-name");
        public By SendMessageButtonLocator => By.CssSelector("[onclick='send()']");
    }    
}