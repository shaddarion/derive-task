using ApplicationFramework.Pages;

namespace ApplicationFramework
{
    public class ApplicationPages
    {
        public HomePage HomePage => new HomePage();
        public SearchResultPage SearchResultPage => new SearchResultPage();
        public ShoppingCartSummaryPage ShoppingCartSummary => new ShoppingCartSummaryPage();
    }
}
