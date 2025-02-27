using Google.Apis.Services;
using Google.Apis.CustomSearchAPI.v1;
using Google.Apis.CustomSearchAPI.v1.Data;

namespace TestAssignment.GoogleSearchApi
{
    internal class GoogleSearch
    {
        public async Task<Search> CustomGoogleSearchResult()
        {
            // Read API key and search engine ID from environment variables
            var apiKey = Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
            var searchEngineId = Environment.GetEnvironmentVariable("GOOGLE_SEARCH_ENGINE_ID");

            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(searchEngineId))
            {
                Console.WriteLine("API key or Search Engine ID is not set.");
                return new Search();
            }

            var customSearchService = new CustomSearchAPIService(new BaseClientService.Initializer
            {
                ApiKey = apiKey
            });

            var listRequest = customSearchService.Cse.List();
            listRequest.Q = "Selenium C# tutorial";
            listRequest.Cx = searchEngineId;
            listRequest.Num = 1;

            return await listRequest.ExecuteAsync();
        }
    }
}
