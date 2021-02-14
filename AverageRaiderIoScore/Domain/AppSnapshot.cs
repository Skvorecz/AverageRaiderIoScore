namespace AverageRaiderIoScore.Domain
{    
    class AppSnapshot
    {
        public SearchParameters SearchParameters { get; }

        public AppSnapshot(SearchParameters searchParameters)
        {
            SearchParameters = searchParameters;
        }
    }
}