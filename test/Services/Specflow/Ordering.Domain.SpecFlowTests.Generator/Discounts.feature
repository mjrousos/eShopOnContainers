Feature: Discounts
	Apply the right product discount to each line item of a given order

@mytag
Scenario: Apply the higher discount to all the line items for a same product
	Given An order with 2 units of a given product (id 1) with a discount of 10
	When I add a unit of this same product (id 1) but a higher discount of 20 is applied
	Then all the units will have the higher discount of 20 applied for the given product (id 1)
