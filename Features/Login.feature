Feature: Login
	
	@ui
	Scenario: Verify successful login with valid credentials
		Given User navigate to Login page
		When User provide values for username and password 'John Doe' and 'ThisIsNotAPassword'
		And User click Login button
		Then User is redirected to Make Appointment page

	@ui
	Scenario: Verify failure message on login with invalid credentials
		Given User navigate to Login page
		When User provide values for username and password 'John Doe' and 'InvalidPassword'
		And User click Login button
		Then Error message is displayed on the login page