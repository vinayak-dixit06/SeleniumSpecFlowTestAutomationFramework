using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace SeleniumSpecFlowTestAutomationFramework.Helpers
{
    public static class ExtentReportHelper
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static ExtentHtmlReporter _htmlReporter;

        // Initialize Extent Report
        public static void InitializeReport()
        {
            // Use the root directory to save the report
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string reportDirectory = Path.Combine(projectDirectory, "..", "..", "..", "TestReports"); // Go to the root folder

            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }

            // Create a timestamp for the report
            string reportPath = Path.Combine(reportDirectory, $"ExtentReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");

            // Create the HTML Reporter and configure it
            _htmlReporter = new ExtentHtmlReporter(reportPath);
            _htmlReporter.Config.DocumentTitle = "Automation Test Report";
            _htmlReporter.Config.ReportName = "Test Execution Report";
            _htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

            // Initialize the ExtentReports instance
            _extent = new ExtentReports();
            _extent.AttachReporter(_htmlReporter);

            // Optional: Print the directory to the console for debugging purposes
            Console.WriteLine($"Report will be saved in: {reportDirectory}");
        }

        // Create a test node
        public static void CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        // Log test status as Pass
        public static void LogTestPass(string message)
        {
            _test.Pass(message);
        }

        // Log test status as Fail
        public static void LogTestFail(string message)
        {
            _test.Fail(message);
        }

        // Log test status as Skip
        public static void LogTestSkip(string message)
        {
            _test.Skip(message);
        }

        // Flush the report
        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
