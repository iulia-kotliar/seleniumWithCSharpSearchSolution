using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAssignment.Pages
{
    internal class LandingPage(IWebDriver driver)
    {
        protected readonly IWebDriver Driver = driver;

        private IWebElement SearchField => Driver.FindElement(By.Id("APjFqb"));

        public void EnterSearchPrompt(string searchPrompt)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(_ => SearchField);
            SearchField.Clear();
            SearchField.SendKeys(searchPrompt);
        }
        
        public void ClickSearchButton()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(_ => SearchField);
            SearchField.SendKeys(Keys.Enter);
        }
}
}
