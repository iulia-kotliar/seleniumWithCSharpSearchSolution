using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using TestAssignment.Configuration;
using TestAssignment.Pages;


namespace TestAssignment.Tests
{
    internal abstract class BaseTest
    {
        protected static IWebDriver Driver;
        protected LandingPage LandingPage;
        protected SearchResultsPage SearchResultsPage;

        protected IWebDriver GetDriver()
        {
            return Driver = CreateDriver(ConfigurationProvider.Configuration["browser"]);
        }

        [SetUp]
        public void SetUp()
        {
            Driver = GetDriver();
            Driver.Navigate().GoToUrl("https://www.google.com/");
            LandingPage = new LandingPage(Driver);
            SearchResultsPage = new SearchResultsPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Dispose();
        }

        private IWebDriver CreateDriver(string browserName)
        {
            switch (browserName.ToLowerInvariant())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(GetBrowserArguments());
                    return new ChromeDriver(chromeOptions);
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments(GetBrowserArguments());
                    return new FirefoxDriver(firefoxOptions);
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArguments(GetBrowserArguments());
                    return new EdgeDriver(edgeOptions);
                default:
                    throw new Exception("Provided browser is not supported.");
            }
        }

        private string[] GetBrowserArguments()
        {
            if (ConfigurationProvider.Configuration["browserArguments"] != null)
            {
                return ConfigurationProvider.Configuration["browserArguments"].Split(",");
            }
            return Array.Empty<string>();
        }
    }
}
