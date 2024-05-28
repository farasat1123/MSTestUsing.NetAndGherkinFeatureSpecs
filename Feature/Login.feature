Feature: Login
  As a user
  I want to login to the Saucedemo website
  So that I can access my account

  Background:
    Given I navigate to the login page

  @login
  Scenario: Successful login with valid credentials
    When I login with username "standard_user" and password "secret_sauce"
    Then I should be redirected to the inventory page

  @login
  Scenario: Unsuccessful login with invalid credentials
    When I login with username "invalid_user" and password "invalid_password"
    Then I should see an error message "Epic sadface"
