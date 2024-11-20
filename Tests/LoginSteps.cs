using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlowTestAutomationFramework.Tests
{
    [Binding]
    public class LoginSteps
    {
        [When(@"I enter valid credentials ""([^""]*)"" and ""([^""]*)""")]
        public void WhenIEnterValidCredentialsAnd(string validUser, string validPassword)
        {

        }

        [When(@"I click on the ""([^""]*)"" button")]
        public void WhenIClickOnTheButton(string p0)
        {

        }

        [Then(@"I should see the message ""([^""]*)""")]
        public void ThenIShouldSeeTheMessage(string p0)
        {

        }

        [When(@"I enter invalid credentials ""([^""]*)"" and ""([^""]*)""")]
        public void WhenIEnterInvalidCredentialsAnd(string invalidUser, string invalidPassword)
        {

        }

        [Then(@"I should see an error message ""([^""]*)""")]
        public void ThenIShouldSeeAnErrorMessage(string p0)
        {

        }

        [When(@"I leave the username and password fields empty")]
        public void WhenILeaveTheUsernameAndPasswordFieldsEmpty()
        {

        }
    }
}
