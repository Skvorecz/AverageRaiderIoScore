using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using System;
using AverageRaiderIoScore.Workers;
using AverageRaiderIoScore.Domain;

namespace AverageRaiderIoScore
{
    class ViewModel : BindableBase
    {
        private const int DungeonsCount = 8;
        private const int BaseRioForDungeon = 10;

        private StringBuilder logTextSb;
        private IRaiderIoCharactersLoader raiderIoCharactersLoader;

        public DelegateCommand AddCharacterCommand { get; }
        public DelegateCommand ExecuteCommand { get; }
        public DelegateCommand<Character> DeleteCommand { get; }

        public string[] Regions { get; }
        public ObservableCollection<Character> Characters { get; }

        public string LogText => logTextSb.ToString();
        public double AverageRaiderIoScore => Characters.Select(c => c.RaiderIoScore).Average();
        public double AverageItemLvl => Characters.Select(c => c.ItemLvl).Average();
        public double AverageKeyLevelDone => Math.Round(AverageRaiderIoScore / (BaseRioForDungeon * DungeonsCount), 2);

        public ViewModel()
        {
            logTextSb = new StringBuilder();
            raiderIoCharactersLoader = new RaiderIoCharactersLoader();
            Regions = Enum.GetNames(typeof(Region));
            Characters = new ObservableCollection<Character>();
            AddCharacter();

            AddCharacterCommand = new DelegateCommand(() => AddCharacter(),
                                                            () => Characters.Count < 5);
            ExecuteCommand = new DelegateCommand(() => Execute());
            DeleteCommand = new DelegateCommand<Character>((c) => Characters.Remove(c));
        }

        private void Execute()
        {
            try
            {
                LoadCharacters();
            }
            catch (Exception ex)
            {
                LogLine(ex.Message);
            }

            RaisePropertyChanged(nameof(AverageRaiderIoScore));
            RaisePropertyChanged(nameof(AverageItemLvl));
            RaisePropertyChanged(nameof(AverageKeyLevelDone));
        }
        private void LoadCharacters()
        {
            raiderIoCharactersLoader.LoadCharacters(new SearchParameters(Characters));
        }

        private void AddCharacter()
        {
            Characters.Add(new Character());
        }

        private void LogLine(string text)
        {
            logTextSb.Append(text);
            logTextSb.AppendLine();
            RaisePropertyChanged(nameof(LogText));
        }
    }
}