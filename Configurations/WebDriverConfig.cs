using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
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

        public static void LaunchBrowser(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    Driver = new ChromeDriver();
                    break;
                case "firefox":
                    Driver = new FirefoxDriver();
                    break;
                case "edge":
                    Driver = new EdgeDriver();
                    break;
                default:
                    throw new ArgumentException("Invalid browser specified");
            }
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
