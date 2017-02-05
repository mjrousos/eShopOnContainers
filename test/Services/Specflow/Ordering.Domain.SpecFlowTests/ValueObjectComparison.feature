Feature: ValueObjectComparison
	Two ValueObjects are equals if same object or contain exact same values

@mytag
Scenario: Compare to value objects 
	Given An instance of an address value object with a given street, city , state, zipcode and country
	And a second instance with the exact same values
	When I compare both instances
	Then the equality operator should return true
