using System.Collections.Generic;
using System.Linq;
using ApplicationFramework.Components;
using OpenQA.Selenium;

namespace ApplicationFramework.Pages
{
    public class SearchResultPage : BasePage
    {
        private By Items => By.XPath("//ul[contains(@class, 'product_list')]/*");
        private By Button_CloseQuickViewPopup => By.CssSelector(".fancybox-close");


        public SearchResultPage Click_CloseQuickViewPopup_Button()
        {
            Driver.SwitchTo().Window(Driver.CurrentWindowHandle);
            Driver.FindElement(Button_CloseQuickViewPopup).Click();
            return this;
        }

        public List<SearchedItemComponent> GetAllItems()
        {
            var items = Driver.FindElements(Items);
            return items.Select(item => new SearchedItemComponent(item).Parse()).ToList();
        }
    }
}
