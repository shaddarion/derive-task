using System;
using OpenQA.Selenium;

namespace ApplicationFramework.Pages
{
    public class ShoppingCartSummaryPage : BasePage
    {
        private By ProductsQuantity => By.Id("summary_products_quantity");
        private By CartItem => By.ClassName("cart_item");

        public int Quantity
        {
            get
            {
                var quantity = Driver.FindElement(ProductsQuantity).Text;
                return Convert.ToInt32(quantity.Split(' ')[0]);
            }
        }

        public int GetAddedTableItems() => Driver.FindElements(CartItem).Count;
    }
}
