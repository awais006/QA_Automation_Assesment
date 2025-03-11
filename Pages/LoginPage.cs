using CURAHealthServices_QAAutomation.Utils;
using DotNetEnv;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CURAHealthServices_QAAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement menuToggle => _driver.FindElement(By.ClassName("toggle"));
        private IWebElement LoginPageButton => _driver.FindElement(By.XPath("//a[text()='Login']"));
        private IWebElement HistoryPageButton => _driver.FindElement(By.XPath("//a[text()='History']"));
        private IWebElement UsernameTextbox => _driver.FindElement(By.Name("username"));
        private IWebElement PasswordTextbox => _driver.FindElement(By.Name("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("btn-login"));
        private string ErrorMessage => _driver.FindElement(By.ClassName("text-danger")).Text;

        public void UserNavigateToLoginPage()
        {
            Env.Load("config.env");
            var appUrl = Env.GetString("APP_URL");

            _driver.Navigate().GoToUrl(appUrl);
            menuToggle.Click();
            LoginPageButton.Click();
        }

        public void UserNavigateToHistoryPage()
        {
            Env.Load("config.env");
            var appUrl = Env.GetString("APP_URL");

            _driver.Navigate().GoToUrl(appUrl);
            menuToggle.Click();
            HistoryPageButton.Click();
        }

        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://katalon-demo-cura.herokuapp.com/profile.php#login");
            menuToggle.Click();
            LoginPageButton.Click();
        }

        public void ProvideValuesForUsernameAndPassword(string username, string password)
        {
            UsernameTextbox.SendKeys(username);
            PasswordTextbox.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void RedirectedToMakeAppointmentPage()
        {
            var url = _driver.Url;

            Assert.That(url, Does.Contain("#appointment"), "Make Appointment page is not opened.");
            //_driver.Quit();
        }

        public void ErrorMessageIsDisplayedOnTheLoginPage()
        {
            Assert.That(ErrorMessage, Is.EqualTo("Login failed! Please ensure the username and password are valid."), "Error message is not correct when incorrect credentials are provided.");
        }
    }
}