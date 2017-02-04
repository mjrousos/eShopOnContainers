using System;
using TechTalk.SpecFlow;

namespace Ordering.Domain.SpecFlowTests.Generator
{
    [Binding]
    public class SpecFlowDiscountsSteps
    {
        [Given(@"An order with (.*) units of a given product \(id (.*)\) with a discount of (.*)")]
        public void GivenAnOrderWithUnitsOfAGivenProductIdWithADiscountOf(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I add a unit of this same product \(id (.*)\) but a higher discount of (.*) is applied")]
        public void WhenIAddAUnitOfThisSameProductIdButAHigherDiscountOfIsApplied(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"all the units will have the higher discount of (.*) applied for the given product \(id (.*)\)")]
        public void ThenAllTheUnitsWillHaveTheHigherDiscountOfAppliedForTheGivenProductId(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
