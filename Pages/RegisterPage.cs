using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlowTestAutomationFramework.Pages
{
    public class RegistrationPage : BasePage
    {
        private readonly By FirstNameField = By.Id("customer.firstName");
        private readonly By LastNameField = By.Id("customer.lastName");
        private readonly By AddressField = By.Id("customer.address.street");
        private readonly By CityField = By.Id("customer.address.city");
        private readonly By StateField = By.Id("customer.address.state");
        private readonly By ZipCodeField = By.Id("customer.address.zipCode");
        private readonly By PhoneField = By.Id("customer.phoneNumber");
        private readonly By SSNField = By.Id("customer.ssn");
        private readonly By UsernameField = By.Id("customer.username");
        private readonly By PasswordField = By.Id("customer.password");
        private readonly By ConfirmPasswordField = By.Id("repeatedPassword");
        private readonly By RegisterButton = By.CssSelector("input[value='Register']");

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
            
        }

        public void EnterFirstName(string value)
        {
            FillElement(FirstNameField, value);
        }

        public void EnterLastName(string value)
        {
            FillElement(LastNameField, value);
        }

        public void EnterAddress(string value)
        {
            FillElement(AddressField, value);
        }

        public void EnterCity(string value)
        {
            FillElement(CityField, value);
        }

        public void EnterState(string value)
        {
            FillElement(StateField, value);
        }

        public void EnterZipCode(string value)
        {
            FillElement(ZipCodeField, value);
        }

        public void EnterPhone(string value)
        {
            FillElement(PhoneField, value);
        }

        public void EnterSSN(string value)
        {
            FillElement(SSNField, value);
        }

        public void EnterUsername(string value)
        {
            FillElement(UsernameField, value);
        }

        public void EnterPassword(string value)
        {
            FillElement(PasswordField, value);
        }

        public void EnterConfirmPassword(string value)
        {
            FillElement(ConfirmPasswordField, value);
        }

        public void clickRegisterButton()
        {
            ClickElement(RegisterButton);
        }
    }
}
