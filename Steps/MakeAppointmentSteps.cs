using CURAHealthServices_QAAutomation.Pages;
using CURAHealthServices_QAAutomation.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CURAHealthServices_QAAutomation.Steps
{
    [Binding]
    public class MakeAppointmentSteps
    {
        private readonly MakeAppointmentPage _makeAppoitmentPage;

        public MakeAppointmentSteps()
        {
            _makeAppoitmentPage = new MakeAppointmentPage(DriverHelper.GetDriver());
        }

        [When(@"User select '([^']*)'")]
        public void UserSelectFacilityStep(string facilityName)
        {
            _makeAppoitmentPage.UserSelectFacility(facilityName);
        }

        [When(@"User select '([^']*)' healthcare program")]
        public void UserSelectHealthcareProgramStep(string healthcareProgram)
        {
            _makeAppoitmentPage.UserSelectHealthcareProgram(healthcareProgram);
        }

        [When(@"User select '([^']*)' visit date")]
        public void UserSelectVisitDateStep(string visitDate)
        {
            _makeAppoitmentPage.UserSelectVisitDate(visitDate);
        }

        [When(@"User provide '([^']*)' comment")]
        public void UserProvideCommentStep(string comment)
        {
            _makeAppoitmentPage.UserProvideComment(comment);
        }

        [When(@"User click Book Appointment button")]
        public void UserClickBookAppointmentButtonStep()
        {
            _makeAppoitmentPage.UserClickBookAppointmentButton();
        }

        [Then(@"User is navigated to Appointment Confirmation page")]
        public void UserIsNavigatedToAppointmentConfirmationPageStep()
        {
            _makeAppoitmentPage.UserIsNavigatedToAppointmentConfirmationPageStep();
        }

        [Then(@"User is not navigated to Appointment Confirmation page")]
        public void UserIsNotNavigatedToAppointmentConfirmationPageStep()
        {
            _makeAppoitmentPage.UserIsNotNavigatedToAppointmentConfirmationPageStep();
        }

        [Then(@"User is redirected to History page")]
        public void UserIsRedirectedToHistoryPageStep()
        {
            _makeAppoitmentPage.UserIsRedirectedToHistoryPage();
        }

        [Then(@"User can see the facility '([^']*)' appointment info")]
        public void UserCanSeeTheFacilityAppointmentInfoStep(string facilityName)
        {
            _makeAppoitmentPage.UserCanSeeTheFacilityAppointmentInfo(facilityName);
        }

    }
}
