using System.Linq;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using Newtonsoft.Json.Linq;

namespace AverageRaiderIoScore
{
    class ViewModel : BindableBase
    {
        public DelegateCommand AddCharacterCommand { get; }
        public DelegateCommand ExecuteCommand{ get; }
        public string[] Regions { get; } = new string[] { "eu", "us" };
        public ObservableCollection<Character> Characters { get; }

        public ViewModel()
        {
            Characters = new ObservableCollection<Character>();
            AddCharacter();

            AddCharacterCommand = new DelegateCommand(() => AddCharacter());
            ExecuteCommand = new DelegateCommand(() =>
            {
                LoadCharacters();
                RaisePropertyChanged(nameof(AverageRaiderIoScore));
                RaisePropertyChanged(nameof(AverageItemLvl)); 
            });
        }

        private void AddCharacter()
        {
            Characters.Add(new Character());
        }

        private void LoadCharacters()
        {
            var worker = new RaiderIoApiWorker();
            foreach (var character in Characters)
            {
                var json = JObject.Parse(worker.LoadCharacterJson(character));
                character.RaiderIoScore = json["mythic_plus_scores_by_season"][0]["scores"]["all"].Value<double>();
            }
        }

        public double AverageRaiderIoScore => Characters.Select(c => c.RaiderIoScore).Average();

        public double AverageItemLvl => Characters.Select(c => c.ItemLvl).Average();
    }
}