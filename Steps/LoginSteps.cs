using CURAHealthServices_QAAutomation.Pages;
using CURAHealthServices_QAAutomation.Utils;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CURAHealthServices_QAAutomation.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;

        public LoginSteps()
        {
            _loginPage = new LoginPage(DriverHelper.GetDriver());
        }

        [Given(@"User navigate to Login page")]
        public void UserNavigateToLoginPageStep()
        {
            _loginPage.UserNavigateToLoginPage();
        }

        [When(@"User navigate to History page")]
        public void UserNavigateToHistoryPageStep()
        {
            _loginPage.UserNavigateToHistoryPage();
        }


        [Given(@"User open the login page")]
        public void OpenTheLoginPageStep()
        {
            _loginPage.NavigateToLoginPage();
        }

        [When(@"User provide values for username and password '([^']*)' and '([^']*)'")]
        public void ProvideValuesForUsernameAndPasswordStep(string username, string password)
        {
            _loginPage.ProvideValuesForUsernameAndPassword(username, password);
        }

        [When(@"User click Login button")]
        public void ClickLoginButtonStep()
        {
            _loginPage.ClickLoginButton();
        }

        [Then(@"User is redirected to Make Appointment page")]
        public void RedirectedToMakeAppointmentPageStep()
        {
            _loginPage.RedirectedToMakeAppointmentPage();
        }

        [Then(@"Error message is displayed on the login page")]
        public void ErrorMessageIsDisplayedOnTheLoginPageStep()
        {
            _loginPage.ErrorMessageIsDisplayedOnTheLoginPage();
        }

        [Given(@"User is logged in using username and password as '([^']*)' and '([^']*)'")]
        public void UserIsLoggedInUsingUsernameAndPasswordStep(string username, string password)
        {
            _loginPage.NavigateToLoginPage();
            _loginPage.ProvideValuesForUsernameAndPassword(username, password);
            _loginPage.ClickLoginButton();
            _loginPage.RedirectedToMakeAppointmentPage();
        }

    }
}
