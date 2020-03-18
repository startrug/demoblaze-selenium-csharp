using System;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace demoblaze_selenium_csharp
{
    public class ScreenshotTaker
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IWebDriver _driver;

        public string ScreenshotFileName { get; private set; }
        public string ScreenshotFilePath { get; private set; }

        public ScreenshotTaker(IWebDriver driver)
        {
            if (driver == null)
                return;
            _driver = driver;
            ScreenshotFileName = TestContext.CurrentContext.Test.Name;
        }

        public void CreateScreenshotIfTestFailed()
        {
            var testResult = TestContext.CurrentContext.Result.Outcome.Status;
            if (testResult == TestStatus.Failed ||
                testResult == TestStatus.Inconclusive)
                TakeScreenshotForFailure();
        }

        public string TakeScreenshot(string screenshotFileName)
        {
            var ss = GetScreenshot();
            var successfullySaved = TryToSaveScreenshot(screenshotFileName, ss);
            return successfullySaved ? ScreenshotFilePath : "";
        }

        public bool TakeScreenshotForFailure()
        {
            ScreenshotFileName = $"FAIL_{ScreenshotFileName}";
            var ss = GetScreenshot();
            var successfullySaved = TryToSaveScreenshot(ScreenshotFileName, ss);
            if (successfullySaved)
                Logger.Error($"Screenshot Of Error => {ScreenshotFilePath}");
            return successfullySaved;
        }

        private bool TryToSaveScreenshot(string screenshotFileName, Screenshot ss)
        {
            try
            {
                SaveScreenshot(screenshotFileName, ss);
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
                Logger.Error(e.StackTrace);
                return false;
            }
        }

        private void SaveScreenshot(string screenshotName, Screenshot ss)
        {
            if (ss == null)
                return;
            ScreenshotFilePath = $"{Reporter.LatestResultsReportFolder}\\{screenshotName}.jpg";
            ScreenshotFilePath = ScreenshotFilePath.Replace('/', ' ').Replace('"', ' ');
            ss.SaveAsFile(ScreenshotFilePath, ScreenshotImageFormat.Png);
        }

        private Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot)_driver)?.GetScreenshot();
        }
    }
}
