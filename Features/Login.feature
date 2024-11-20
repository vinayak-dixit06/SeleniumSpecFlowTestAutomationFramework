Feature: Login to Parabank
  As a user of the Parabank website
  I want to test the login functionality
  So that I can ensure it works as expected

  Scenario: Successful login with valid credentials
    When I enter valid credentials "validUser" and "validPassword"
    And I click on the "Log In" button
    Then I should see the message "Accounts Overview"

  Scenario: Login attempt with invalid credentials
    When I enter invalid credentials "invalidUser" and "invalidPassword"
    And I click on the "Log In" button
    Then I should see an error message "The username and password could not be verified."

  Scenario: Login attempt with empty fields
    When I leave the username and password fields empty
    And I click on the "Log In" button
    Then I should see an error message "Please enter a username and password."
