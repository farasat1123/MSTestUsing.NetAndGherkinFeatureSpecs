using TechTalk.SpecFlow;
using AutomationUsingMSTest.Pages;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationUsingMSTest.Page;

namespace AutomationUsingMSTest.StepDefinitions
{
    [Binding]
    public class Checkout : BaseClass
    {
        private InventoryPage inventoryPage;
        private CheckoutPage checkoutPage;

        public Checkout()
        {
            inventoryPage = new InventoryPage(driver);
            checkoutPage = new CheckoutPage(driver);
        }

        [Given(@"I have added the following items to the cart")]
        public void GivenIHaveAddedTheFollowingItemsToTheCart(Table table)
        {
            foreach (var row in table.Rows)
            {
                string product = row["product"];
                inventoryPage.AddToCartByName(product);
            }
        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            inventoryPage.goToCart();
            inventoryPage.ButtonClick("Checkout");
        }

        [When(@"I enter the following checkout information")]
        public void WhenIEnterTheFollowingCheckoutInformation(Table table)
        {
            var row = table.Rows[0];
            string firstName = row["FirstName"];
            string lastName = row["LastName"];
            string zipCode = row["ZipCode"];

            checkoutPage.PerformCheckout(firstName, lastName, zipCode);
        }

        [Then(@"I should see the order confirmation message ""(.*)""")]
        public void ThenIShouldSeeTheOrderConfirmationMessage(string expectedMessage)
        {
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-two.html", driver.Url, "URL Mismatch");
            checkoutPage.ButtonClick("Finish");
            Assert.AreEqual("https://www.saucedemo.com/checkout-complete.html", driver.Url, "URL Mismatch");
            Assert.IsTrue(checkoutPage.CheckForText(expectedMessage));
        }
    }
}
