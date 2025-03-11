using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace CURAHealthServices_QAAutomation.Utils
{
    public class DriverHelper
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
                Console.WriteLine("WebDriver initialized.");
            }
            return _driver;
        }

        public static void QuitDriver()
        {
            Debug.WriteLine("Web driver Quit()");

            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
                Console.WriteLine("WebDriver closed.");
            }
        }
    }
}
