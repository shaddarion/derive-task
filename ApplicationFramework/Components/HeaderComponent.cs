using ApplicationFramework.Pages;
using AutomationFramework.Providers;
using OpenQA.Selenium;

namespace ApplicationFramework.Components
{
    public class HeaderComponent
    {
        private readonly IWebDriver Driver = DriverProvider.GetDriver();
        
        private By Logo => By.Id("header_logo");
        private By Input_SearchField => By.Id("search_query_top");
        private By Button_Search => By.Name("submit_search");

        public ShoppingCartComponent ShoppingCart => new ShoppingCartComponent();

        public HomePage Click_Logo()
        {
            Driver.FindElement(Logo).Click();
            return new HomePage();
        }

        public HeaderComponent Input_SearchField_Value(string value)
        {
            Driver.FindElement(Input_SearchField).SendKeys(value);
            return this;
        }

        public HeaderComponent Click_Search_Button()
        {
            Driver.FindElement(Button_Search).Click();
            return this;
        }
    }
}
