using System;

namespace AverageRaiderIoScore.Domain
{
    [Serializable]
    class AppSnapshot
    {
        public SearchParameters SearchParameters { get; }

        public AppSnapshot(SearchParameters searchParameters)
        {
            SearchParameters = searchParameters;
        }
    }
}