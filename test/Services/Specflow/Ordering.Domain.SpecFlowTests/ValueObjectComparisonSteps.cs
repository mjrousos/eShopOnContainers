using Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Shopping.Domain.SpecFlowTests
{
    [Binding]
    public class ValueObjectComparisonSteps
    {
        Address _address1;
        Address _address2;
        bool comparisonResult = false;
        [Given(@"An instance of an address value object with a given street, city , state, zipcode and country")]
        public void GivenAnInstanceOfAnAddressValueObjectWithAGivenStreetCityStateZipcodeAndCountry()
        {
            _address1 = new Address("Puerta del sol", "Madrid", "Madrid", "Spain", "28001");
        }
        
        [Given(@"a second instance with the exact same values")]
        public void GivenASecondInstanceWithTheExactSameValues()
        {
            _address2 = new Address("Puerta del sol", "Madrid", "Madrid", "Spain", "28001");
        }

        [When(@"I compare both instances")]
        public void WhenICompareBothInstances()
        {
            comparisonResult = _address1.Equals(_address2);
        }
        
        [Then(@"the equality operator should return true")]
        public void ThenTheEqualityOperatorShouldReturnTrue()
        {
            Assert.AreEqual(true, comparisonResult);
        }
    }
}
