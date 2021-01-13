using System.Linq;
using System.Collections.ObjectModel;

namespace AverageRaiderIoScore
{
    class ViewModel
    {
        public string[] Regions { get; } = new string[] { "eu", "us" };
        public ObservableCollection<Character> Characters { get; }

        public ViewModel()
        {
            Characters = new ObservableCollection<Character>() { new Character { Name = "Skvorr", Realm = "Ashenvale", Region = Region.eu },
                                                                new Character{Name = "Sustamet", Realm = "Gordunni"} };
        }

        private double GetAverageRaiderIoScore()
        {
            return Characters.Select(c => c.RaiderIoScore).Average();
        }

        private double GetAverageItemLvl()
        {
            return Characters.Select(c => c.ItemLvl).Average();
        }
    }
}