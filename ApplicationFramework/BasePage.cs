using ApplicationFramework.Components;
using AutomationFramework.Providers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ApplicationFramework
{
    public class BasePage
    {
        protected IWebDriver Driver = DriverProvider.GetDriver();
        protected IWait<IWebDriver> FluentWait = FluentWaitProvider.FluentWait;
        
        public HeaderComponent Header => new HeaderComponent();
        public NavigationMenuComponent NavigationMenu => new NavigationMenuComponent();
    }
}
