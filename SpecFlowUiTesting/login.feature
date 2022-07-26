Feature: login
	Login and see new account button

@mytag
Scenario: Login and see new account button
	Given I am logged in to the 'Planned and Projects' app as 'a salesperson'
	When I open the 'Operational' area
	When I open the 'Accounts' sub area of the 'Customers' group
	Then I can see the 'New' command