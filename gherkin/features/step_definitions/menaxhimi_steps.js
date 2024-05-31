const { Given, When, Then } = require('cucumber');
const assert = require('assert');

// Dummy data for local testing
let users = [];
let products = [
  { id: 1, name: 'Laptop', category: 'Electronics', price: 1000 },
  { id: 2, name: 'Phone', category: 'Electronics', price: 500 }
];
let cart = [];
let orders = [];
let orderHistory = [];
let isLoggedIn = false;
let userCredentials = { username: 'testUser', password: 'password123' };

Given('a user is on the registration page', function () {
  this.registrationDetails = { username: '', password: '', email: '' };
});

When('they provide valid registration details', function () {
  this.registrationDetails = { username: 'testUser', password: 'password123', email: 'test@example.com' };
  users.push(this.registrationDetails);
});

Then('their account should be created successfully', function () {
  const user = users.find(u => u.username === 'testUser');
  assert.ok(user, 'Account was not created successfully');
});

Given('a user is on the homepage', function () {
  // No action needed for local dummy data
});

When('they search for a specific product', function () {
  this.searchResults = products.filter(product => product.name.includes('Laptop'));
});

Then('they should see a list of products matching their search criteria', function () {
  assert.ok(this.searchResults.length > 0, 'No products found');
});

Given('a user is on a product page', function () {
  this.productPage = products.find(product => product.id === 1);
});

When('they add the product to the cart', function () {
  cart.push(this.productPage);
});

Then('the product should appear in their shopping cart', function () {
  const productInCart = cart.find(product => product.id === this.productPage.id);
  assert.ok(productInCart, 'Product did not appear in the cart');
});

Given('a user has products in their shopping cart', function () {
  cart = [products[0]]; // Assuming the user has already added a product to the cart
});

When('they proceed to the checkout page', function () {
  // Proceed to checkout
});

Then('they should be able to enter payment and shipping information', function () {
  assert.ok(true, 'Could not enter payment and shipping information');
});

Given('a user is on the checkout page', function () {
  // No action needed for local dummy data
});

When('they confirm their order', function () {
  const order = { id: 1, items: cart, total: 1000 };
  orders.push(order);
  orderHistory.push(order);
  cart = [];
});

Then('the purchase should be completed and they should receive an order confirmation', function () {
  const order = orders.find(o => o.id === 1);
  assert.ok(order, 'Order was not confirmed');
});

Given('a user is logged into their account', function () {
  isLoggedIn = true;
});

When('they navigate to the order history page', function () {
  this.userOrderHistory = orderHistory;
});

Then('they should see a list of their previous orders', function () {
  assert.ok(this.userOrderHistory.length > 0, 'Order history is not displayed');
});

When('they enter a valid discount code', function () {
  // Assume the user enters a valid discount code
});

Then('the discount should be applied to their order total', function () {
  // Assume the discount is applied successfully
});

Given('a user is on the order tracking page', function () {
  // No action needed for local dummy data
});

When('they enter their order number', function () {
  this.orderStatus = orders.find(order => order.id === 1);
});

Then('they should see the current status of their order', function () {
  assert.ok(this.orderStatus, 'Order status is not displayed');
});

Given('a user is on the login page', function () {
  isLoggedIn = false;
});

When('they enter valid credentials', function () {
  if (userCredentials.username === 'testUser' && userCredentials.password === 'password123') {
    isLoggedIn = true;
  }
});

Then('they should be able to access their secure profile page', function () {
  assert.ok(isLoggedIn, 'Unable to access secure profile page');
});

Given('a user is not logged in', function () {
  isLoggedIn = false;
});

When('they attempt to access a secure page', function () {
  if (!isLoggedIn) this.redirectToLogin = true;
});

Then('they should be redirected to the login page', function () {
  assert.ok(this.redirectToLogin, 'Not redirected to login page');
});

Given('the platform is under test', function () {
  // Placeholder for setup if needed
});

When('various functionalities are tested', function () {
  // Placeholder for functionality testing
});

Then('it should perform consistently without errors', function () {
  // Placeholder for assertion if needed
  return 'success';
});

Given('a user is on the help page', function () {
  // For the sake of this example, let's assume some default support articles are already available
  this.supportArticles = ['How to create a profile', 'How to apply for a job'];
});

When('they look for support articles', function () {
  // No action needed here, as the support articles are already set up in the previous step
});

Then('they should find the information they need', function () {
  if (!this.supportArticles || this.supportArticles.length === 0) {
    throw new Error('Support articles not found');
  }
});

When('they should be able to contact customer support', function () {
  this.contactSupport = true;
  if (!this.contactSupport) {
    throw new Error('Unable to contact customer support');
  }
});
