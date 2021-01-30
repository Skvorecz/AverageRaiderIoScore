using System.Collections.Generic;
using AverageRaiderIoScore.Domain;

namespace AverageRaiderIoScore.Workers
{
    class RaiderIoCharactersLoader : IRaiderIoCharactersLoader
    {
        private RaiderIoApiWorker RaiderIoApiWorker { get; }

        public RaiderIoCharactersLoader()
        {
            RaiderIoApiWorker = new RaiderIoApiWorker();
        }
        public void LoadCharacters(SearchParameters searchParameters)
        {
            foreach (var character in searchParameters.Characters)
            {
                var jsonWorker = new JsonWorker(RaiderIoApiWorker.LoadCharacter(character));

                character.RaiderIoScore = jsonWorker.RaiderIoScore;
                character.ItemLvl = jsonWorker.ItemLevel;
            }
        }
    }
}
