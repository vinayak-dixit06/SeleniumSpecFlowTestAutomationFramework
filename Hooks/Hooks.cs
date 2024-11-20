using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SeleniumSpecFlowTestAutomationFramework.Configurations;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlowTestAutomationFramework.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeScenario]
        public void BeforeScenario()
        {
            WebDriverConfig.LaunchBrowser();
            WebDriverConfig.LaunchApp();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverConfig.QuitBrowser();
        }
    }
}