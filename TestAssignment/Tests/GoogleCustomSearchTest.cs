using TestAssignment.GoogleSearchApi;

namespace TestAssignment.Tests
{
    internal class GoogleCustomSearchTest
    {
        protected GoogleSearch GoogleSearch;

        [Test]
        public async Task Selenium_Tutorial_Custom_Search()
        {
            //Arrange
            GoogleSearch = new GoogleSearch();

            //Act
            var result = await GoogleSearch.CustomGoogleSearchResult();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Items.Count, Is.GreaterThan(0), "Search results are not displayed");
                Assert.That(result.Items[0].Snippet, Does.Contain("Selenium"),
                    "First search result does not contain word 'Selenium'");
            });

        }
    }
}
