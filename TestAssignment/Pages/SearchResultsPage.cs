using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAssignment.Pages
{
    internal class SearchResultsPage(IWebDriver driver)
    {
        protected readonly IWebDriver Driver = driver;

        private IWebElement SearchResults => Driver.FindElement(By.Id("search"));
        private IWebElement FirstResultTitle => Driver.FindElement(By.XPath("//h3[1]"));

        public bool AreSearchResultsDisplayed()
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                wait.Until(_ => SearchResults);
                return true;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        public string FirstResultTitleText()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(_ => FirstResultTitle);
            return FirstResultTitle.Text;
        }

    }
}
