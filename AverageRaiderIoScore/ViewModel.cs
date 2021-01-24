using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace AverageRaiderIoScore
{
    class ViewModel : BindableBase
    {
        private const int DungeonsCount = 8;
        private const int BaseRioForDungeon = 10;
        private StringBuilder logTextSb;

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
            Regions = Enum.GetNames(typeof(Region));
            Characters = new ObservableCollection<Character>();
            AddCharacter();

            AddCharacterCommand = new DelegateCommand(() => AddCharacter(),
                                                            () => Characters.Count < 5);
            ExecuteCommand = new DelegateCommand(() =>
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
            });
            DeleteCommand = new DelegateCommand<Character>((c) => Characters.Remove(c));
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
                var jsonAdapter = new JsonAdapter(worker.LoadCharacter(character));
                character.RaiderIoScore = jsonAdapter.RaiderIoScore;
                character.ItemLvl = jsonAdapter.ItemLevel;
            }
        }

        private void LogLine(string text)
        {
            logTextSb.Append(text);
            logTextSb.AppendLine();
            RaisePropertyChanged(nameof(LogText));
        }
    }
}