using CURAHealthServices_QAAutomation.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V133.Audits;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CURAHealthServices_QAAutomation.Pages
{
    public class MakeAppointmentPage
    {
        private readonly IWebDriver _driver;

        public MakeAppointmentPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement FacilityDropdown => _driver.FindElement(By.Id("combo_facility"));
        private IWebElement VisitDateTextbox => _driver.FindElement(By.Name("visit_date"));
        private IWebElement CommentTextbox => _driver.FindElement(By.Name("comment"));
        private IWebElement BookAppointmentButton => _driver.FindElement(By.Id("btn-book-appointment"));
        private IWebElement MakeAppointment => _driver.FindElement(By.XPath(".//h2[text()='Make Appointment']"));
        private IWebElement AppointmentConfirmation => _driver.FindElement(By.XPath(".//h2[text()='Appointment Confirmation']"));
        private IWebElement HistoryTitle => _driver.FindElement(By.XPath(".//h2[text()='History']"));
        private string FacilityNameInHistory => _driver.FindElement(By.XPath("//p[@id='facility']")).Text;

        private IWebElement HealthcareProgramRadioButton(string programName) => _driver.FindElement(By.XPath($".//input[@type='radio' and @value='{programName}']"));


        public void UserSelectFacility(string facilityName)
        {
            var selectFacility = new SelectElement(FacilityDropdown);
            selectFacility.SelectByValue(facilityName);
        }

        public void UserSelectHealthcareProgram(string HealthcareProgram)
        {
            HealthcareProgramRadioButton(HealthcareProgram).Click();
        }

        public void UserSelectVisitDate(string VisitDate)
        {
            VisitDateTextbox.SendKeys(VisitDate);
        }

        public void UserProvideComment(string comment)
        {
            CommentTextbox.SendKeys(comment);
        }

        public void UserClickBookAppointmentButton()
        {
            BookAppointmentButton.Click();
        }

        public void UserIsNavigatedToAppointmentConfirmationPageStep()
        {
            Assert.That(AppointmentConfirmation.Displayed, "Appointment Confirmation message is not displayed.");
        }

        public void UserIsNotNavigatedToAppointmentConfirmationPageStep()
        {
            Assert.That(MakeAppointment.Displayed, "Appointment Confirmation message is displayed.");
        }

        public void UserIsRedirectedToHistoryPage()
        {
            Assert.That(HistoryTitle.Displayed, "History page is not opened.");
        }

        public void UserCanSeeTheFacilityAppointmentInfo(string facilityName)
        {
            Assert.That(FacilityNameInHistory.Equals(facilityName), "Appointment history is not showing correctly.");
        }
    }
}
