Feature: E-commerce Platform Functionality

  Scenario: User registers on the platform
    Given a user is on the registration page
    When they provide valid registration details
    Then their account should be created successfully

  Scenario: User searches for products
    Given a user is on the homepage
    When they search for a specific product
    Then they should see a list of products matching their search criteria

  Scenario: User adds a product to the cart
    Given a user is on a product page
    When they add the product to the cart
    Then the product should appear in their shopping cart

  Scenario: User proceeds to checkout
    Given a user has products in their shopping cart
    When they proceed to the checkout page
    Then they should be able to enter payment and shipping information

  Scenario: User completes a purchase
    Given a user is on the checkout page
    When they confirm their order
    Then the purchase should be completed and they should receive an order confirmation

  Scenario: User views order history
    Given a user is logged into their account
    When they navigate to the order history page
    Then they should see a list of their previous orders

  Scenario: User applies discount code
    Given a user is on the checkout page
    When they enter a valid discount code
    Then the discount should be applied to their order total

  Scenario: User tracks an order
    Given a user is on the order tracking page
    When they enter their order number
    Then they should see the current status of their order

  Scenario: User logs in
    Given a user is on the login page
    When they enter valid credentials
    Then they should be able to access their secure profile page

  Scenario: Unauthorized access to secure page
    Given a user is not logged in
    When they attempt to access a secure page
    Then they should be redirected to the login page

  Scenario: Platform performance testing
    Given the platform is under test
    When various functionalities are tested
    Then it should perform consistently without errors

  Scenario: User accesses help resources
    Given a user is on the help page
    When they look for support articles
    Then they should find the information they need

  Scenario: User contacts customer support
    Given a user is on the help page
    When they should be able to contact customer support
    Then they should find the information they need
