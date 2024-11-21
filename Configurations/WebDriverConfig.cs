using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlowTestAutomationFramework.Configurations
{
    public static class WebDriverConfig
    {
        public static IWebDriver Driver 
        { 
            get; 
            private set; 
        }

        public static void LaunchBrowser()
        {
            Driver = new EdgeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
        }

        public static void LaunchApp()
        {
            Driver.Url = "https://parabank.parasoft.com/";
        }

        public static void QuitBrowser()
        {
            if (Driver != null)
            {
                Driver.Quit();
           
            }
        }
    }
}
