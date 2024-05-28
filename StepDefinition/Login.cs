using TechTalk.SpecFlow;
using AutomationUsingMSTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUsingMSTest.StepDefinitions
{
    [Binding]
    public class Login
    {
        private static IWebDriver driver;
        private LoginPage loginPage;

        public Login()
        {
            loginPage = new LoginPage(driver);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            driver = new ChromeDriver();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.Quit();
        }

        [Given(@"I navigate to the login page")]
        public void GivenINavigateToTheLoginPage()
        {
            loginPage.NavigateToLoginPage();
        }

        [When(@"I login with username ""(.*)"" and password ""(.*)""")]
        public void WhenILoginWithUsernameAndPassword(string username, string password)
        {
            loginPage.PerformLogin(username, password);
        }

        [Then(@"I should be redirected to the inventory page")]
        public void ThenIShouldBeRedirectedToTheInventoryPage()
        {
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
        }

        [Then(@"I should see an error message ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessage(string errorMessage)
        {
            IWebElement errorElement = driver.FindElement(By.CssSelector("[data-test='error']"));
            Assert.IsTrue(errorElement.Displayed);
            Assert.IsTrue(errorElement.Text.Contains(errorMessage));
        }
    }
}
