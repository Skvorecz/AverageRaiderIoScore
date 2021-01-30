using System.Collections.Generic;

namespace AverageRaiderIoScore.Domain
{
    class SearchParameters
    {
        public IList<Character> Characters { get; }

        public SearchParameters(IList<Character> characters)
        {
            Characters = characters;
        }
    }
}
