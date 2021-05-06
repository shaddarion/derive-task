using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutomationFramework.ExtensionMethods;
using AutomationFramework.Providers;
using OpenQA.Selenium;

namespace ApplicationFramework.Components
{
    public class SearchedItemComponent : IEquatable<SearchedItemComponent>
    {
        protected IWebDriver Driver = DriverProvider.GetDriver();
        
        private readonly IWebElement _item;
        private By Item_Name => By.ClassName("product-name");
        private By Item_Price => By.CssSelector(".right-block .product-price");
        private By Button_AddToCard => By.XPath("//a[@title = 'Add to cart']");
        private By Button_QuickView => By.CssSelector(".quick-view");

        public string Name { get; set; }
        public string Price { get; set; }
        public List<string> Colors { get; set; }

        public SearchedItemComponent(IWebElement item)
        {
            _item = item;
            Name = string.Empty;
            Price = string.Empty;
            Colors = new List<string>();
        }

        public SearchedItemComponent Parse()
        {
            Name = _item.FindElement(Item_Name).Text;
            Price = _item.FindElement(Item_Price).Text;

            return this;
        }

        public SearchedItemComponent Hover()
        {
            Driver.Ex_HoverElement(_item);
            FluentWaitProvider.FluentWait.Until(x => _item.GetAttribute("class").Contains("hovered"));
            return this;
        }

        public QuickViewPopup Click_QuickView_Button()
        {
            Hover();
            //TODO: Find better way to handle clicking Quick View button
            Thread.Sleep(300);
            _item.FindElements(Button_QuickView).FirstOrDefault(item => item.Displayed)?.Click();
            return new QuickViewPopup();
        }

        public AddedItemPopup Click_AddToCard_Button()
        {
            Hover();
            _item.FindElements(Button_AddToCard).FirstOrDefault(item => item.Displayed)?.Click();
            return new AddedItemPopup();
        }

        public bool Equals(SearchedItemComponent item)
        {
            return Name == item?.Name
                   && Price == item?.Price;
        }
    }
}
