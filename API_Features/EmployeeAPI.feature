Feature: Employees API
	
	Scenario: Verify salary of employee Micheal Silva
		Given I call the API end point
		Then I verify that 'Michael Silva' has salary of '198500'

	Scenario: Verify salary of employee having specific ID
		Given I call the API end point
		Then I verify that employee has following details:
		| Id | EmployeeName | EmployeeSalary | EmployeeAge | ProfileImage |
		| 5  | Airi Satou   | 162700         | 33          |              |