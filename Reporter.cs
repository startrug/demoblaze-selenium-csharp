using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace demoblaze_selenium_csharp
{
    public static class Reporter
    {
        private static readonly Logger TheLogger = LogManager.GetCurrentClassLogger();

        public static string LatestResultsReportFolder { get; private set; }
        private static string ApplicationDebuggingFolder => "c://Reports";
        private static ExtentReports ReportManager { get; set; }
        private static string HtmlReportFullPath { get; set; }
        private static TestContext MyTestContext { get; set; }
        public static ExtentTest CurrentTestCase { get; set; }

        internal static void StartReporter()
        {
            TheLogger.Trace("Starting a one time setup for the entire" +
                " .demoblaze-selenium-csharp namespace." +
                "Going to initialize reporter next...");
            CreateReportDirectory();
            var htmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
            ReportManager = new ExtentReports();
            ReportManager.AttachReporter(htmlReporter);
        }

        private static void CreateReportDirectory()
        {
            var filePath = Path.GetFullPath(ApplicationDebuggingFolder);
            LatestResultsReportFolder = Path.Combine(filePath, DateTime.Now.ToString("MMdd_HHmm"));
            Directory.CreateDirectory(LatestResultsReportFolder);

            HtmlReportFullPath = $"{LatestResultsReportFolder}\\TestResults.html";
            TheLogger.Trace("Full path of HTML report => " + HtmlReportFullPath);
        }

        public static void AddTestCaseMetadataToHtmlReports(TestContext testContext)
        {
            MyTestContext = testContext;
            CurrentTestCase = ReportManager.CreateTest(MyTestContext.Test.Name);
        }

        public static void LogPassingTestStepForBugLogger(string message)
        {
            TheLogger.Info(message);
            CurrentTestCase.Log(Status.Pass, message);
        }

        public static void ReportTestOutcome(string screenshotPath)
        {
            var status = MyTestContext.Result.Outcome.Status;

            switch (status)
            {
                case TestStatus.Failed:
                    TheLogger.Error($"Test failed => {MyTestContext.Test.Name}");
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Fail("Fail");
                    break;
                case TestStatus.Inconclusive:
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Warning("Inconclusive");
                    break;
                case TestStatus.Skipped:
                    CurrentTestCase.Skip("Test skipped");
                    break;
                default:
                    CurrentTestCase.Pass("Pass");
                    break;
            }
            ReportManager.Flush();
        }

        public static void LogTestStepForBugLogger(Status status, string message)
        {
            TheLogger.Info(message);
            CurrentTestCase.Log(status, message);
        }
    }
}
