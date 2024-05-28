using TechTalk.SpecFlow;
using AutomationUsingMSTest.Pages;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AutomationUsingMSTest.Page;

namespace AutomationUsingMSTest.StepDefinitions
{
    [Binding]
    public class AddToCart : BaseClass
    {
        private InventoryPage inventoryPage;

        public AddToCart()
        {
            inventoryPage = new InventoryPage(driver);
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            // Assuming the user is already logged in via the BaseClass
        }

        [When(@"I add ""(.*)"" to the cart")]
        public void WhenIAddToTheCart(string product)
        {
            inventoryPage.AddToCartByName(product);
            // Added a wait command to wait for the cart number to be updated
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(Locators.CartNumber));
        }

        [Then(@"the cart number should be ""(.*)""")]
        public void ThenTheCartNumberShouldBe(string expectedCartNumber)
        {
            string actualCartNumber = inventoryPage.GetCartNumber();
            Assert.AreEqual(expectedCartNumber, actualCartNumber);
        }

        [When(@"I add the following items to the cart")]
        public void WhenIAddTheFollowingItemsToTheCart(Table table)
        {
            foreach (var row in table.Rows)
            {
                string product = row["product"];
                WhenIAddToTheCart(product);
            }
        }
    }
}
