using demoblaze_selenium_csharp.Enums;

namespace demoblaze_selenium_csharp.Models
{
    public class WebDriverConfiguration
    {
        public BrowserName BrowserName { get; set; }
        public string ScreenshotsPath { get; set; }
        public int DefaultTimeout { get; set; }
        public string BrowserLanguage { get; set; }
    }
}