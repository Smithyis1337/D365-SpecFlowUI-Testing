Feature: createverification

Create a variation

@variation
Scenario: Create a new Variation on a Case
	Given I am logged in to the 'Planned and Projects' app as 'a salesperson'
	When I open the 'Operational' area
	When I open the 'Cases' sub area of the 'Works on Site' group
	When I change the view to 'Repairs WIP' and open record number '6' by clicking in the 'title' column
	When I select the 'Variations' tab
	When I click the 'New Variation. Add New Variation' command on the 'subgrid_variations' subgrid
	When I select 'Axis' form
	When I select the 'Save (CTRL+S)' command
	When I select the 'Spec Lines' tab
	When I open the record at position '0'
	When I enter '15.0' into the 'ebecs_requiredquantity' numeric field on the form
	When I select the 'Save & Close' command
	When I select the 'Submit' command
	Then I can see the value of 'Approved' in the Status field

Scenario: Create a new Variation on a Case Above Limit
	Given I am logged in to the 'Planned and Projects' app as 'a salesperson'
	When I open the 'Operational' area
	When I open the 'Cases' sub area of the 'Works on Site' group
	When I change the view to 'Repairs WIP' and open record number '7' by clicking in the 'title' column
	When I select the 'Variations' tab
	When I click the 'New Variation. Add New Variation' command on the 'subgrid_variations' subgrid
	When I select 'Axis' form
	When I select the 'Save (CTRL+S)' command
	When I select the 'Spec Lines' tab
	When I open the record at position '0'
	When I enter '400.0' into the 'ebecs_requiredquantity' numeric field on the form
	When I select the 'Save & Close' command
	When I select the 'Submit' command
	Then I can see the value of 'Approval Requested' in the Status field
