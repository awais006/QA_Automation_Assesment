using CURAHealthServices_QAAutomation.Utils;
using TechTalk.SpecFlow;

namespace CURAHealthServices_QAAutomation.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public static void BeforeTestRun(ScenarioContext scenarioContext)
        {
            var configTags = scenarioContext.ScenarioInfo.Tags;

            if (configTags.Contains("ui"))
            {
                Console.WriteLine("BeforeTestRun: Initializing WebDriver.");
                DriverHelper.GetDriver();
            }            
        }

        [AfterScenario]
        public static void AfterTestRun(ScenarioContext scenarioContext)
        {
            var configTags = scenarioContext.ScenarioInfo.Tags;

            if (configTags.Contains("ui"))
            {
                Console.WriteLine("AfterTestRun: Quitting WebDriver.");
                DriverHelper.QuitDriver();
            }
        }

    }
}