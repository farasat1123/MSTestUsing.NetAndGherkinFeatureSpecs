Feature: Add to Cart
  As a user
  I want to add items to the cart
  So that I can purchase them later

  Background:
    Given I am logged in

  @addtocart
  Scenario: Add a single item to the cart
    When I add "Sauce Labs Backpack" to the cart
    Then the cart number should be "1"

 @addoCartWithMultipleItems
  Scenario: Add multiple items to the cart
    When I add the following items to the cart
      | product                  | cartNumber |
      | Sauce Labs Backpack      | 1          |
      | Sauce Labs Fleece Jacket | 2          |
      | Sauce Labs Bolt T-Shirt  | 3          |
      | Sauce Labs Onesie        | 4          |
      | Sauce Labs Bike Light    | 5          |
    
    Then the cart number should be "5"
