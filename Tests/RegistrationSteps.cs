using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumSpecFlowTestAutomationFramework.Configurations;
using SeleniumSpecFlowTestAutomationFramework.Helpers;
using SeleniumSpecFlowTestAutomationFramework.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlowTestAutomationFramework.Tests
{
    [Binding]
    public class RegistrationSteps
    {
        // Necessary Declarations

        private IWebDriver driver;
        private RegistrationPage registrationPage;
        private HomePage homePage;


        // Creating Constructer

        public RegistrationSteps()
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
        }

        [When(@"I fill in the registration form with random details")]
        public void WhenIFillInTheRegistrationFormWithRandomDetails()
        {
            var userDetails = RandomDataHelper.GenerateUserDetails();

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

        [When(@"I click on the ""([^""]*)"" button")]
        public void WhenIClickOnTheButton(string register)
        {
            registrationPage.clickRegisterButton();
            Thread.Sleep(3000);
        }

        [Then(@"I should see the success message ""([^""]*)""")]
        public void ThenIShouldSeeTheSuccessMessage(string p0)
        {
            var acutalMessage = registrationPage.CheckRegistrationSuccessfulMessage();
            var expectedMessage = "Your account was created successfully. You are now logged in.";

            Assert.AreEqual(expectedMessage, acutalMessage);
        }


        // Scenario 2: Registration with missing mandatory fields (Negative Scenario)

        [When(@"I leave mandatory fields empty in the registration form")]
        public void WhenILeaveMandatoryFieldsEmptyInTheRegistrationForm()
        {
            var userDetails = RandomDataHelper.GenerateUserDetails();

            registrationPage.EnterFirstName(userDetails["FirstName"]);
            registrationPage.EnterLastName(userDetails["LastName"]);
            registrationPage.EnterAddress(userDetails["Address"]);
            registrationPage.EnterCity(userDetails["City"]);
            registrationPage.EnterState(userDetails["State"]);
            registrationPage.EnterZipCode(userDetails["ZipCode"]);
            registrationPage.EnterPhone(userDetails["Phone"]);
            registrationPage.EnterSSN(userDetails["SSN"]);
            registrationPage.EnterUsername(""); // Not filling username as it is a mandatory field.
            registrationPage.EnterPassword(userDetails["Password"]);
            registrationPage.EnterConfirmPassword(userDetails["Confirm"]);
        }

        [Then(@"I should see a missing username error message ""([^""]*)""")]
        public void ThenIShouldSeeAMissingUsernameErrorMessage(string p0)
        {
            var acutalMessage = registrationPage.CheckMissingUsernameValidationMessage();
            var expectedMessage = "Username is required.";

            Assert.AreEqual(expectedMessage, acutalMessage);
        }


        // Scenario 3: Registration with mismatched passwords (Negative Scenario)

        [When(@"I fill in the registration form with mismatched random passwords")]
        public void WhenIFillInTheRegistrationFormWithMismatchedRandomPasswords()
        {
            var userDetails = RandomDataHelper.GenerateUserDetails();

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
            registrationPage.EnterConfirmPassword(RandomDataHelper.GenerateRandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()", 10));
        }

        [Then(@"I should see an error message ""([^""]*)""")]
        public void ThenIShouldSeeAnErrorMessage(string p0)
        {
            var acutalMessage = registrationPage.CheckPasswordsDidNotMatchValidationMessage();
            var expectedMessage = "Passwords did not match.";

            Assert.AreEqual(expectedMessage, acutalMessage);
        }
    }
}
