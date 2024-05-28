using TechTalk.SpecFlow;

namespace AutomationUsingMSTest.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        private static bool isLoggedIn = false;

        [BeforeScenario]
        public void BeforeScenario()
        {
            // Check if the user is not already logged in and the scenario requires login
            if (!isLoggedIn && ScenarioContext.Current.ScenarioInfo.Tags.Contains("login"))
            {
                // Perform login
                // Set isLoggedIn to true to indicate that the user is logged in
                isLoggedIn = true;
                // You can perform login steps here if needed
            }
        }
    }
}
