Feature: Registration on Parabank
  As a new user of the Parabank website
  I want to test the registration functionality
  So that I can ensure new users can register successfully

  Scenario: Successful registration with random details
    Given I am on the Parabank registration page
    When I fill in the registration form with random details
    And I click on the "Register" button
    Then I should see the success message "Your account was created successfully. You are now logged in."

  Scenario: Registration with missing mandatory fields
    Given I am on the Parabank registration page
    When I leave mandatory fields empty in the registration form
    And I click on the "Register" button
    Then I should see a missing username error message "Username is required."

  Scenario: Registration with mismatched passwords
    Given I am on the Parabank registration page
    When I fill in the registration form with mismatched random passwords
    And I click on the "Register" button
    Then I should see an error message "Passwords did not match."
