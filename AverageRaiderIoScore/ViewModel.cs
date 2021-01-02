using System.Collections.Generic;
using System.Linq;

namespace AverageRaiderIoScore
{
    class ViewModel
    {
        List<Character> characters;

        private double GetAverageRaiderIoScore()
        {
            return characters.Select(c => c.RaiderIoScore).Average();
        }

        private double GetAverageItemLvl()
        {
            return characters.Select(c => c.ItemLvl).Average();
        }
    }
}
