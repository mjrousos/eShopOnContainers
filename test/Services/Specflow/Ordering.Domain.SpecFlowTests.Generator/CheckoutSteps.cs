using System;
using TechTalk.SpecFlow;

namespace Shopping.Domain.SpecFlowTests
{
    [Binding]
    public class CheckoutSteps
    {
        [Given(@"An order with (.*) units of a given product \(id (.*)\)")]
        public void GivenAnOrderWithUnitsOfAGivenProductId(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I check out the order")]
        public void WhenICheckOutTheOrder()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a checkedOut event should be emited indicating the (.*) units of product \(id (.*)\)")]
        public void ThenACheckedOutEventShouldBeEmitedIndicatingTheUnitsOfProductId(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
