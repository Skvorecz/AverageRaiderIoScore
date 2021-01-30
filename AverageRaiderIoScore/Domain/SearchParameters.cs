using System.Collections.Generic;

namespace AverageRaiderIoScore.Domain
{
    class SearchParameters
    {
        public List<Character> Characters { get; }

        public SearchParameters(List<Character> characters)
        {
            Characters = characters;
        }
    }
}
