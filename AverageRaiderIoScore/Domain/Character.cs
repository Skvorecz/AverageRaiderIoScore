using Prism.Mvvm;

namespace AverageRaiderIoScore.Domain
{
    class Character : BindableBase
    {
        private double raiderIoScore;
        private double itemLvl;

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
        public double ItemLvl
        {
            get => itemLvl;
            set
            {
                itemLvl = value;
                RaisePropertyChanged(nameof(ItemLvl));
            }
        }
    }
}