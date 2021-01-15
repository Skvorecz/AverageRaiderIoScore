using Prism.Mvvm;

namespace AverageRaiderIoScore
{
    class Character : BindableBase
    {
        private double raiderIoScore;

        public string Name { get; set; }
        public string Realm { get; set; }
        public Region Region { get; set; } = Region.eu;
        public double RaiderIoScore
        {
            get => raiderIoScore;
            set
            {
                raiderIoScore = value;
                RaisePropertyChanged(nameof(RaiderIoScore));
            }
        }
        public double ItemLvl { get; set; }
    }
}