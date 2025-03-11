using Newtonsoft.Json;

namespace CURAHealthServices_QAAutomation.APIModels
{
    public class EmployeeResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public List<Employee> Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class Employee
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }

        [JsonProperty("employee_salary")]
        public int EmployeeSalary { get; set; }

        [JsonProperty("employee_age")]
        public int EmployeeAge { get; set; }

        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Employee emp)
            {
                return Id == emp.Id &&
                       EmployeeName == emp.EmployeeName &&
                       EmployeeSalary == emp.EmployeeSalary &&
                       EmployeeAge == emp.EmployeeAge &&
                       ProfileImage == emp.ProfileImage;
            }
            return false;
        }
    }
}