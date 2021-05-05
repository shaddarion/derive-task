using System;
using AutomationFramework.ExtensionMethods;
using AutomationFramework.Providers;
using OpenQA.Selenium;

namespace ApplicationFramework.Components
{
    public class ShoppingCartComponent
    {
        private readonly IWebDriver Driver = DriverProvider.GetDriver();

        private By ShoppingCart => By.XPath("//a[@title = 'View my shopping cart']");
        private By Button_CheckOut => By.Id("button_order_cart");
        private By QuantityItems => By.ClassName("ajax_cart_quantity");

        private void Hover_ShoppingCart() => Driver.Ex_HoverElement(Driver.FindElement(ShoppingCart));

        public int TotalItems
        {
            get
            {
                var addedItems = Driver.FindElement(QuantityItems).Text;
                return Convert.ToInt32(addedItems);
            }
        }

        public void Click_CheckOut_Button()
        {
            Hover_ShoppingCart();
            Driver.FindElement(Button_CheckOut).Ex_Click();
        }
    }
}
