﻿using System.IO;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;

namespace demoblaze_selenium_csharp.Helpers
{
    public class WebDriverListener : EventFiringWebDriver
    {
        private readonly IWebDriver driver;
        private readonly Logger logger;

        public WebDriverListener(IWebDriver parentDriver, Logger logger) : base(parentDriver)
        {
            driver = parentDriver;
            this.logger = logger;
            Navigating += WebDriverListener_Navigating;
            Navigated += WebDriverListener_Navigated;
            FindingElement += WebDriverListener_FindingElement;
            ElementClicking += WebDriverListener_ElementClicking;
            ElementClicked += WebDriverListener_ElementClicked;
            ElementValueChanged += WebDriverListener_ElementValueChanged;
        }

        private void WebDriverListener_Navigating(object sender,
            WebDriverNavigationEventArgs e)
        {
            LogMessage($"Navigating to {e.Url}");
        }

        private void WebDriverListener_ElementClicked(object sender,
            WebElementEventArgs e)
        {
            LogScreenshot($"{e.Element} clicked");
        }

        private void WebDriverListener_ElementClicking(object sender,
            WebElementEventArgs e)
        {
            LogMessage($"Clicking on the {e.Element.TagName} `{e.Element.Text}` {e.Element}");
        }

        private void WebDriverListener_FindingElement(object sender,
            FindElementEventArgs e)
        {
            LogMessage($"Finding element `{e.FindMethod}`");
        }

        private void WebDriverListener_ElementValueChanged(object sender,
            WebElementValueEventArgs e)
        {
            LogScreenshot($"Value of the {e.Element} changed to `{e.Value}`");
        }

        private void WebDriverListener_Navigated(object sender,
            WebDriverNavigationEventArgs e)
        {
            LogScreenshot($"Navigated to [{e.Driver.Title}]({e.Url})");
        }

        private void LogMessage(string text)
        {
            logger.Info(text);
        }

        private void LogScreenshot(string text)
        {
            //driver.TakeScreenshot();
            logger.Info(text);
        }
    }
}
