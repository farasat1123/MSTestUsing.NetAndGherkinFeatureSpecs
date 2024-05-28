using AutomationUsingMSTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System;

namespace AutomationUsingMSTest
{
    [Binding]
    public class BaseClass
    {
        protected static IWebDriver driver;
        protected TestDataRepository testDataRepository;
        private static bool loginPerformed = false;

        [BeforeScenario]
        public void TestInitialize()
        {
            if (!loginPerformed)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                // Create an instance of TestDataRepository
                testDataRepository = new TestDataRepository();

                // Get test data from CSV file
                var testDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test_data.csv");
                var loginTestData = testDataRepository.GetLoginTestData(testDataFilePath);

                // Perform login using the first entry in the CSV file
                var firstLoginData = loginTestData.FirstOrDefault();
                if (firstLoginData == null)
                {
                    throw new InvalidOperationException("No test data found in the CSV file.");
                }

                // Initialize login page
                LoginPage loginPage = new LoginPage(driver);
                loginPage.NavigateToLoginPage();

                // Perform login using the first entry in the CSV file
                loginPage.PerformLogin(firstLoginData.Username, firstLoginData.Password);

                loginPerformed = true;
            }
        }

        [AfterScenario]
        public void TestCleanup()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
