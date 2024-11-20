Feature: Registration on Parabank
  As a new user of the Parabank website
  I want to test the registration functionality
  So that I can ensure new users can register successfully

  Scenario: Successful registration with valid details
    Given I am on the Parabank registration page
    When I fill in the registration form with the following details:
      | FirstName | John          |
      | LastName  | Doe           |
      | Address   | 123 Elm St    |
      | City      | Springfield   |
      | State     | IL            |
      | ZipCode   | 62701         |
      | Phone     | 5551234567    |
      | SSN       | 123-45-6789   |
      | Username  | newuser       |
      | Password  | NewPassword1  |
      | Confirm   | NewPassword1  |
    And I click on the "Register" button
    Then I should see the success message "Your account was created successfully. You are now logged in."

  Scenario: Registration with missing mandatory fields
    Given I am on the Parabank registration page
    When I leave mandatory fields empty in the registration form
    And I click on the "Register" button
    Then I should see an error message "Please fill out this field."

  Scenario: Registration with mismatched passwords
    Given I am on the Parabank registration page
    When I fill in the registration form with mismatched passwords
      | FirstName | John          |
      | LastName  | Doe           |
      | Address   | 123 Elm St    |
      | City      | Springfield   |
      | State     | IL            |
      | ZipCode   | 62701         |
      | Phone     | 5551234567    |
      | SSN       | 123-45-6789   |
      | Username  | newuser       |
      | Password  | NewPassword1  |
      | Confirm   | WrongPassword |
    And I click on the "Register" button
    Then I should see an error message "Passwords do not match."
