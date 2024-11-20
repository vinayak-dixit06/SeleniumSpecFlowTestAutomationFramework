using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlowTestAutomationFramework.Pages
{
    public class HomePage : BasePage
    {
        private readonly By RegisterLink = By.XPath("//a[text() = 'Register']");

        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickRegistrationLink()
        {
            ClickElement(RegisterLink);
        }
    }
}
