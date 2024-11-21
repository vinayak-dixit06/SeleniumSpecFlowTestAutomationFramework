using BoDi;
using OpenQA.Selenium;
using SeleniumSpecFlowTestAutomationFramework.Configurations;
using SeleniumSpecFlowTestAutomationFramework.Helpers;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlowTestAutomationFramework.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            // Launch the browser and application
            WebDriverConfig.LaunchBrowser("Edge");
            WebDriverConfig.LaunchApp();

            // Create a test node for the scenario in the Extent Report
            string scenarioName = scenarioContext.ScenarioInfo.Title;
            ExtentReportHelper.CreateTest(scenarioName);
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            // Quit the browser after the scenario
            WebDriverConfig.QuitBrowser();

            // Log the result of the scenario in the report
            if (scenarioContext.TestError != null)
            {
                ExtentReportHelper.LogTestFail($"Scenario Failed: {scenarioContext.TestError.Message}");
            }
            else
            {
                ExtentReportHelper.LogTestPass("Scenario Passed");
            }
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // Initialize the Extent Report before the test run starts
            ExtentReportHelper.InitializeReport();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            // Flush the report after the test run completes
            ExtentReportHelper.FlushReport();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            // Log step results in the report
            if (scenarioContext.TestError != null)
            {
                // Log failure details for failed steps
                ExtentReportHelper.LogTestFail($"Step Failed: {scenarioContext.TestError.Message}");
            }
            else
            {
                // Log success for passed steps
                ExtentReportHelper.LogTestPass($"Step Passed: {scenarioContext.StepContext.StepInfo.Text}");
            }
        }
    }
}
