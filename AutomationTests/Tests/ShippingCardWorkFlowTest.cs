using FluentAssertions;
using NUnit.Framework;

namespace AutomationTests.Tests
{
    [TestFixture]
    public class ShippingCardWorkFlowTest : BaseTest
    {
        [Category("ShippingCard"), Category("SmokeTest")]
        [Test]
        public void CanAddAndRemoveItems()
        {
            //Arrange
            const int maxItems = 2;
            var addedItems = 0;

            const string searchWord = "Dress";

            Pages.HomePage.Header
                .Input_SearchField_Value(searchWord)
                .Click_Search_Button();
            
            var items = Pages.SearchResultPage.GetAllItems();

            //Getting colors for each item
            foreach (var item in items)
            {
                item.Colors = item.Click_QuickView_Button().GetItemColors();
                Pages.SearchResultPage.Click_CloseQuickViewPopup_Button();
            }

            //Act
            foreach (var item in items)
            {
                if (item.Colors.Count <= 0)
                    continue;

                foreach (var col in item.Colors)
                {
                    if (addedItems >= maxItems)
                        break;

                    item
                        .Click_QuickView_Button()
                        .SelectColor(col)
                        .Click_AddToCart_Button()
                        .Click_ContinueShopping_button();
                    
                    addedItems++;
                }
            }

            Pages.SearchResultPage.Header.Click_Logo();
            Pages.HomePage.Header.ShoppingCart.Click_CheckOut_Button();
            
            //Assert: Items count on ShoppingCard control
            Pages.HomePage.Header.ShoppingCart.TotalItems.Should().Be(maxItems, "Incorrect amount of items added");

            //Assert: Items count on ShoppingCardSummary page
            Pages.ShoppingCartSummary.Quantity.Should().Be(maxItems, "Added items label counter has wrong value");
            Pages.ShoppingCartSummary.GetAddedTableItems().Should().Be(maxItems, "Added items table contains incorrect number of items");
        }
    }
}
