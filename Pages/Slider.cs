using System;
using System.Threading;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp.Pages
{
    public class Slider : BasePage
    {
        private By ActiveImageLocator => By.CssSelector("div.carousel-item.active img");

        public Slider(IWebDriver driver) : base(driver) { }

        public bool IsImageChanged()
        {
            var firstImage = GetElementAfterWaiting(ActiveImageLocator);
            ClickOnElementAfterWaiting(By.CssSelector("a.carousel-control-next"));
            Thread.Sleep(1000);
            var secondImage = GetElementAfterWaiting(ActiveImageLocator);

            Console.WriteLine(firstImage.GetAttribute("alt"));
            Console.WriteLine(secondImage.GetAttribute("alt"));

            return firstImage.GetAttribute("alt") != secondImage.GetAttribute("alt");
        }
    }
}