using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using System;
using AverageRaiderIoScore.Workers;
using AverageRaiderIoScore.Domain;
using AverageRaiderIoScore.Properties;

namespace AverageRaiderIoScore
{
    class ViewModel : BindableBase
    {
        #region Fields
        private const int DungeonsCount = 8;
        private const int BaseRioForDungeon = 10;

        private StringBuilder logTextSb;
        private IRaiderIoCharactersLoader raiderIoCharactersLoader;
        private SerializationWorker serializationWorker;
        #endregion

        #region Properties
        public DelegateCommand AddCharacterCommand { get; }
        public DelegateCommand ExecuteCommand { get; }
        public DelegateCommand<Character> DeleteCommand { get; }

        public string[] Regions { get; }
        public ObservableCollection<Character> Characters { get; }

        public string LogText => logTextSb.ToString();
        public double AverageRaiderIoScore => Characters.Select(c => c.RaiderIoScore).Average();
        public double AverageItemLvl => Characters.Select(c => c.ItemLvl).Average();
        public double AverageKeyLevelDone => Math.Round(AverageRaiderIoScore / (BaseRioForDungeon * DungeonsCount), 2);
        #endregion

        public ViewModel()
        {
            logTextSb = new StringBuilder();
            raiderIoCharactersLoader = new RaiderIoCharactersLoader();
            serializationWorker = new SerializationWorker();
            Regions = Enum.GetNames(typeof(Region));
            Characters = new ObservableCollection<Character>();
            AddCharacter();

            AddCharacterCommand = new DelegateCommand(() => AddCharacter(),
                                                            () => Characters.Count < 5);
            ExecuteCommand = new DelegateCommand(() => Execute());
            DeleteCommand = new DelegateCommand<Character>((c) => Characters.Remove(c));

            DeserializeCharacters();
        }

        private void Execute()
        {
            try
            {
                var parameters = new SearchParameters(Characters);
                LoadCharacters(parameters);
                serializationWorker.SerializeAppSnapshot(new AppSnapshot(parameters), Resources.AppSnapshotFilePath);
            }
            catch (Exception ex)
            {
                LogLine(ex.Message);
            }

            RaisePropertyChanged(nameof(AverageRaiderIoScore));
            RaisePropertyChanged(nameof(AverageItemLvl));
            RaisePropertyChanged(nameof(AverageKeyLevelDone));
        }
        private void LoadCharacters(SearchParameters searchParameters)
        {
            raiderIoCharactersLoader.LoadCharacters(searchParameters);
        }

        private void AddCharacter()
        {
            Characters.Add(new Character());
        }

        private void DeserializeCharacters()
        {
            var snapshot = serializationWorker.DeserializeAppSnapshot(Resources.AppSnapshotFilePath);
            var deserializedCharacters = snapshot.SearchParameters.Characters;
            Characters.Clear();
            Characters.AddRange(deserializedCharacters.Select(c => new Character() 
            {
                Region = c.Region,
                Realm = c.Realm,
                Name = c.Name
            }));
        }

        private void LogLine(string text)
        {
            logTextSb.Append(text);
            logTextSb.AppendLine();
            RaisePropertyChanged(nameof(LogText));
        }
    }
}