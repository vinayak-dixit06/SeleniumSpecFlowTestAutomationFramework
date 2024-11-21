using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlowTestAutomationFramework.Pages
{
    public class BasePage
    {
        public static IWebDriver Driver;

        public BasePage(IWebDriver driver) 
        {
           Driver = driver;
        }

        public void ClickElement(By element)
        {
            Driver.FindElement(element).Click();
        }

        public void FillElement(By element, string value)
        {
            Driver.FindElement(element).SendKeys(value);
        }

        public string ReadElementText(By element)
        {
            var extractedText = Driver.FindElement(element).Text;
            return extractedText;
        }
    }
}
