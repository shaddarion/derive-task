using System;
using System.Threading;
using OpenQA.Selenium;
using SettingManager;

namespace ApplicationFramework.Pages
{
    public class ShoppingCartSummaryPage : BasePage
    {
        private By ProductsQuantity => By.Id("summary_products_quantity");
        private By CartItem => By.ClassName("cart_item");
        private By Button_DeleteItem => By.ClassName("cart_quantity_delete");
        private By TableRow => By.XPath("//table[@id = 'cart_summary']/tbody/tr");

        public int Quantity
        {
            get
            {
                var quantity = Driver.FindElement(ProductsQuantity).Text;
                return Convert.ToInt32(quantity.Split(' ')[0]);
            }
        }

        public int GetAddedTableItems() => Driver.FindElements(CartItem).Count;

        public ShoppingCartSummaryPage RemoveAllItems()
        {
            var items = Driver.FindElements(Button_DeleteItem);
            var itemsCount = items.Count;
            
            foreach (var item in items)
            {
                item.Click();
                itemsCount--;
                SpinWait.SpinUntil(() => Driver.FindElements(TableRow).Count == itemsCount, TimeSpan.FromSeconds(ApplicationSettings.DefaultWaitTime));
            }

            return this;
        }
    }
}
