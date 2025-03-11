using CURAHealthServices_QAAutomation.APIModels;
using DotNetEnv;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CURAHealthServices_QAAutomation.API_Steps
{
    [Binding]
    public class EmployeeApiSteps
    {
        EmployeeResponse _employeeResponse;

        [Given(@"I call the API end point")]
        public void CallTheAPIEndPoint()
        {
            Env.Load("config.env");
            var apiUrl = Env.GetString("API_URL");

            var client = new RestClient(apiUrl);
            var request = new RestRequest("/employees", Method.Get);

            request.AddHeader("Cookie", "humans_21909=1");

            try
            {
                var response = client.Execute(request);

                Assert.That(response, Is.Not.Null, "API response is NULL.");
                Assert.That(!string.IsNullOrEmpty(response.Content), "API response content is empty.");

                if (response.IsSuccessful)
                {
                    _employeeResponse = JsonConvert.DeserializeObject<EmployeeResponse>(response.Content);
                }
                else if ((int)response.StatusCode == 492)
                {
                    throw new Exception("Error Code: 492. You have made too many requests try again after some time.");
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        [Then(@"I verify that '([^']*)' has salary of '([^']*)'")]
        public void VerifyEmployeeNameAndSalary(string employeeName, string salary)
        {
            try
            {
                var employeeDetails = _employeeResponse.Data.FirstOrDefault(x => x.EmployeeName.Equals(employeeName));

                Assert.That(employeeDetails.EmployeeSalary, Is.EqualTo(int.Parse(salary)));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Then(@"I verify that employee has following details:")]
        public void VerifyThatEmployeeHasFollowingDetails(Table employeeTable)
        {
            try
            {
                var expectedEmployee = employeeTable.CreateInstance<Employee>();
                var actualEmployee = _employeeResponse.Data.Where(x => x.Id == expectedEmployee.Id).FirstOrDefault();

                Assert.That(actualEmployee.Equals(expectedEmployee), "Values of Employee is not as expected.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}