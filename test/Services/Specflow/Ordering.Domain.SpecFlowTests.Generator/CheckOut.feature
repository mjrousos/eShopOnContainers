Feature: Checkout
	Order checkout process

@mytag
Scenario: When an order is checked out an event should be published
	Given An order with 2 units of a given product (id 1)
	When I check out the order 
	Then a checkedOut event should be emited indicating the 2 units of product (id 1)
