using AutomationFramework.ExtensionMethods;
using AutomationFramework.Providers;
using OpenQA.Selenium;

namespace ApplicationFramework.Components
{
    public class AddedItemPopup
    {
        private readonly IWebDriver Driver = DriverProvider.GetDriver();

        private By Button_ContinueShopping => By.XPath("//div[@id = 'layer_cart']//span[@title = 'Continue shopping']");
        private By Button_ProceedToCheckout => By.XPath("//div[@id = 'layer_cart']//span[@title = 'Proceed to checkout']");

        public void Click_ContinueShopping_button()
        {
            Driver.FindElement(Button_ContinueShopping).Ex_Click();
        }

        public void Click_ProceedToCheckout_button()
        {
            Driver.FindElement(Button_ProceedToCheckout).Click();
        }
    }
}
