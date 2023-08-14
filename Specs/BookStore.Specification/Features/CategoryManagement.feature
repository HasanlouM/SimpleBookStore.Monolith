Feature: Managing the category
	In order to categorize the books
	As a store manager
	I want to define a category

@databaseSandbox
Scenario: Difining a gategory
	Given I have entered as a store manager
	When I define a category of 'Software'
	Then I should see 'Software' in the list of categories
