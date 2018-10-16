@GoogleSearch
Feature: GoogleSearchResult
	In order to get 5th link on Google Search engine for provided keyword
	As a user I search a keyword in Google
	I want to see the 5th link as result

@PositiveScenario
Scenario: Finding 5th search result of a given keyword
	Given I launch GoogleHomePage
	When I provide 'AVIVA UK' keyword to search
	Then I should see 6 links in the first search page
	And I should get 5th result

@NegativeScenario
Scenario: Invalid Finding 5th search result of a given keyword
	Given I launch GoogleHomePage
	When I provide 'Aviva insurance terms' keyword to search
	Then I should not see 6 links in the first search page
	And I should get 5th result
