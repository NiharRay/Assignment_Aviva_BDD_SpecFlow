Feature: GoogleSearchResult
	In order to get 5th link on Google Search engine for provided keyword
	As a user I search a keyword in Google
	I want to see the 5th link as result

@GoogleSearch
Scenario: Finding 5th search result of a given keyword
	Given I launch 'http://www.google.com'
	When I provide 'TCS' keyword to search
	Then I should get 5th result url

@GoogleSearch
Scenario: Invalid Finding 5th search result of a given keyword
	Given I launch 'http://www.google.com'
	When I provide ' ' keyword to search
	Then I should get 5th result url
