using ApplicationFramework.Components;
using AutomationFramework.Providers;
using OpenQA.Selenium;

namespace ApplicationFramework
{
    public class BasePage
    {
        protected IWebDriver Driver = DriverProvider.GetDriver();
        
        public HeaderComponent Header => new HeaderComponent();
        public NavigationMenuComponent NavigationMenu => new NavigationMenuComponent();
    }
}
