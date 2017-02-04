using TechTalk.SpecFlow;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Shopping.Domain.SpecFlowTests
{
    [Binding]
    public class DiscountsSteps
    {
        private Order _order;

        [Given(@"An order with (.*) units of a given product \(id (.*)\) with a discount of (.*)")]
        public void GivenAnOrderWithLineItemsForProductWithIdAndADiscountOfApplied(int numberOfItems, int productId, int productDiscount)
        {
            _order = new Order(1, 1, new Address("", "", "", "", ""));
            _order.AddOrderItem(productId, "", 100, productDiscount, "", numberOfItems);
        }

        [When(@"I add a unit of this same product \(id (.*)\) but a higher discount of (.*) is applied")]
        public void WhenIAddANewLineItemForTheProductWithIdAndAHigherDiscountOfApplied(int productId, int productDiscount)
        {
            _order.AddOrderItem(productId, "", 100, productDiscount,"");
        }

        [Then(@"all the units will have the higher discount of (.*) applied for the given product \(id (.*)\)")]
        public void ThenAllTheLineItemsForProductWithIdWillHaveTheHigherDiscountOfApplied(int productDiscount, int productId)
        {
            var existingOrdersForProduct = _order.OrderItems.Where(o => o.ProductId == productId).SingleOrDefault();
            Assert.AreEqual(productDiscount, existingOrdersForProduct.GetCurrentDiscount());
            Assert.AreEqual(3, existingOrdersForProduct.Units);
        }
    }
}
