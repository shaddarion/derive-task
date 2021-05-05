using ApplicationFramework.Enums;
using ApplicationFramework.Pages;
using AutomationFramework.Providers;
using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace ApplicationFramework.Components
{
    public class NavigationMenuComponent
    {
        private readonly IWebDriver Driver = DriverProvider.GetDriver();
        
        private By TopMenu(string itemName) => By.XPath($"//div[@id = 'block_top_menu']//a[.= '{itemName}']");

        public SearchResultPage GoTo(NavigationCategories category)
        {
            Driver.FindElement(TopMenu(EnumExtensions.GetEnumMemberAttributeValue(typeof(NavigationCategories), category))).Click();
            
            return new SearchResultPage();
        }
    }
}
