using AverageRaiderIoScore.Domain;

namespace AverageRaiderIoScore.Workers
{
    interface IRaiderIoCharactersLoader
    {
        void LoadCharacters(SearchParameters searchParameters);
    }
}