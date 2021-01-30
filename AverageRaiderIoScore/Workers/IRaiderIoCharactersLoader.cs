using AverageRaiderIoScore.Domain;
using System.Collections.Generic;

namespace AverageRaiderIoScore.Workers
{
    interface IRaiderIoCharactersLoader
    {
        void LoadCharacters(SearchParameters searchParameters);
    }
}