namespace TestAssignment.Tests
{
    internal class SeleniumTutorialTests : BaseTest
    {

        [Test]
        public void Selenium_Tutorial_Search()
        {
            //Arrange/Act
            LandingPage.EnterSearchPrompt("Selenium C# tutorial");
            LandingPage.ClickSearchButton();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(SearchResultsPage.AreSearchResultsDisplayed, Is.True, "Search results are not displayed");
                Assert.That(SearchResultsPage.FirstResultTitleText, Does.Contain("Selenium"), 
                    "First search result does not contain word 'Selenium'");
            });
        }
    }
}
