using OpenQA.Selenium;
using SeleniumSpecFlowTestAutomationFramework.Configurations;
using SeleniumSpecFlowTestAutomationFramework.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlowTestAutomationFramework.Tests
{
    [Binding]
    public class RegisterSteps
    {
        private IWebDriver driver;
        private RegistrationPage registrationPage;
        private HomePage homePage;

        public RegisterSteps()
        {
            driver = WebDriverConfig.Driver;
            registrationPage = new RegistrationPage(driver);
            homePage = new HomePage(driver);
        }

        // Scenario 1: Successful registration with valid details

        [Given(@"I am on the Parabank registration page")]
        public void GivenIAmOnTheParabankRegistrationPage()
        {
            homePage.ClickRegistrationLink();
            Thread.Sleep(3000);
        }

        [When(@"I fill in the registration form with the following details:")]
        public void WhenIFillInTheRegistrationFormWithTheFollowingDetails(Table table)
        {
            var userDetails = table.Rows[0];
            foreach (var key in userDetails.Keys)
            {
                Console.WriteLine(key);
            }
            registrationPage.EnterFirstName(userDetails["FirstName"]);
            registrationPage.EnterLastName(userDetails["LastName"]);
            registrationPage.EnterAddress(userDetails["Address"]);
            registrationPage.EnterCity(userDetails["City"]);
            registrationPage.EnterState(userDetails["State"]);
            registrationPage.EnterZipCode(userDetails["ZipCode"]);
            registrationPage.EnterPhone(userDetails["Phone"]);
            registrationPage.EnterSSN(userDetails["SSN"]);
            registrationPage.EnterUsername(userDetails["Username"]);
            registrationPage.EnterPassword(userDetails["Password"]);
            registrationPage.EnterConfirmPassword(userDetails["Confirm"]);
        }

        [Then(@"I should see the success message ""([^""]*)""")]
        public void ThenIShouldSeeTheSuccessMessage(string p0)
        {
            
        }

        // Scenario 2: Registration with missing mandatory fields

        [When(@"I leave mandatory fields empty in the registration form")]
        public void WhenILeaveMandatoryFieldsEmptyInTheRegistrationForm()
        {
            // Intentionally do not fill any field in the form
        }

        [When(@"I fill in the registration form with mismatched passwords")]
        public void WhenIFillInTheRegistrationFormWithMismatchedPasswords(Table table)
        {
            var userDetails = table.Rows[0];
            registrationPage.EnterFirstName(userDetails["FirstName"]);
            registrationPage.EnterLastName(userDetails["LastName"]);
            registrationPage.EnterAddress(userDetails["Address"]);
            registrationPage.EnterCity(userDetails["City"]);
            registrationPage.EnterState(userDetails["State"]);
            registrationPage.EnterZipCode(userDetails["ZipCode"]);
            registrationPage.EnterPhone(userDetails["Phone"]);
            registrationPage.EnterSSN(userDetails["SSN"]);
            registrationPage.EnterUsername(userDetails["Username"]);
            registrationPage.EnterPassword(userDetails["Password"]);
            registrationPage.EnterConfirmPassword(userDetails["Confirm"]);
        }
    }
}
