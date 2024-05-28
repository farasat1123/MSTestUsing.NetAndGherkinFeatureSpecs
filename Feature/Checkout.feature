Feature: Checkout
  As a user
  I want to checkout my cart items
  So that I can purchase them

  Background:
    Given I am logged in

  @login @addToCartWithMultipleItems @checkout
  Scenario: Checkout with valid information
    Given I have added the following items to the cart
      | product                  |
      | Sauce Labs Backpack      |
      | Sauce Labs Bolt T-Shirt  |
    When I proceed to checkout
    And I enter the following checkout information
      | FirstName | LastName | ZipCode |
      | John      | Doe      | 12345   |
    Then I should see the order confirmation message "Thank you for your order!"
