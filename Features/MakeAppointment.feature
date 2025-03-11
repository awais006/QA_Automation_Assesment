Feature: Make Appointment

	@ui
	Scenario: Make appointment in Tokyo Center with Medicaid program
		Given User is logged in using username and password as 'John Doe' and 'ThisIsNotAPassword'
		When User select 'Hongkong CURA Healthcare Center'
		And User select 'Medicaid' healthcare program
		And User select '19/03/2025' visit date
		And User provide 'Test Appointment' comment
		And User click Book Appointment button
		Then User is navigated to Appointment Confirmation page

	@ui
	Scenario: Verify that user is not redirected to Appointment Confirmation page when date is not provided
		Given User is logged in using username and password as 'John Doe' and 'ThisIsNotAPassword'
		When User select 'Hongkong CURA Healthcare Center'
		And User select 'Medicaid' healthcare program
		And User provide 'Test Appointment' comment
		And User click Book Appointment button
		Then User is not navigated to Appointment Confirmation page

	@ui
	Scenario: Verify that user can view history after making an appointment
		Given User is logged in using username and password as 'John Doe' and 'ThisIsNotAPassword'
		When User select 'Hongkong CURA Healthcare Center'
		And User select 'Medicaid' healthcare program
		And User select '19/03/2025' visit date
		And User provide 'Test Appointment' comment
		And User click Book Appointment button
		Then User is navigated to Appointment Confirmation page
		When User navigate to History page
		Then User is redirected to History page
		And User can see the facility 'Hongkong CURA Healthcare Center' appointment info