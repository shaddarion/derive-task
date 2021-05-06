using System;
using System.Threading;
using ApplicationFramework.Pages;
using AutomationFramework.ExtensionMethods;
using AutomationFramework.Providers;
using FluentAssertions;
using OpenQA.Selenium;
using SettingManager;

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
            SpinWait.SpinUntil(() =>
                Driver.FindElement(By.Id("layer_cart")).GetAttribute("style").Contains("display: none"), 
                TimeSpan.FromSeconds(ApplicationSettings.DefaultWaitTime)).Should().BeTrue("Add item popup has not been closed by clicking Continue Shopping button");
        }

        public ShoppingCartSummaryPage Click_ProceedToCheckout_button()
        {
            Driver.FindElement(Button_ProceedToCheckout).Click();
            return new ShoppingCartSummaryPage();
        }
    }
}
