Feature: CBTFeature

Scenario: Search for SpecFlow on Google
	Given I navigate to the page "https://www.google.com"
	And I see the page is loaded
	When I enter Search Keyword in the Search Text box
	And I click on Search Button
	Then Search items shows the items related to SpecFlow

