using System.Linq;
using System.Collections.ObjectModel;
using Prism.Commands;

namespace AverageRaiderIoScore
{
    class ViewModel
    {
        public DelegateCommand AddCharacterCommand { get; }
        public string[] Regions { get; } = new string[] { "eu", "us" };
        public ObservableCollection<Character> Characters { get; }

        public ViewModel()
        {
            Characters = new ObservableCollection<Character>();
            AddCharacterCommand = new DelegateCommand(() => AddCharacter());
        }

        private void AddCharacter()
        {
            Characters.Add(new Character());
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