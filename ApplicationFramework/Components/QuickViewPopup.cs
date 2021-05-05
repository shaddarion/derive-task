using System.Collections.Generic;
using System.Linq;
using AutomationFramework.Providers;
using OpenQA.Selenium;

namespace ApplicationFramework.Components
{
    public class QuickViewPopup
    {
        public QuickViewPopup()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(By.ClassName("fancybox-iframe")));
        }
        
        private readonly IWebDriver Driver = DriverProvider.GetDriver();

        private By ColorList => By.Id("color_to_pick_list");
        private By Button_AddToCart => By.Name("Submit");

        public List<string> GetItemColors()
        {
            return Driver.FindElement(ColorList).FindElements(By.TagName("a"))
                .Select(item => item.GetAttribute("title")).ToList();
        }

        public QuickViewPopup SelectColor(string color)
        {
            Driver.FindElement(ColorList).FindElement(By.XPath($"//a[@title = '{color}']")).Click();
            return this;
        }

        public AddedItemPopup Click_AddToCart_Button()
        {
            Driver.FindElement(Button_AddToCart).Click();
            Driver.SwitchTo().Window(Driver.CurrentWindowHandle);
            return new AddedItemPopup();
        }
    }
}
