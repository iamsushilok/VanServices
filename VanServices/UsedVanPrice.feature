Feature: UsedVanPrice
	Find out the lowest van price

@mytag
Scenario: See Used Vans Prices
	Given I can see InSync Homepage
	When I am on Used van page I want to see cheapest van
	Then I am about to book cheapest van