namespace AverageRaiderIoScore
{
    class Character
    {
        public string Name { get; set; }
        public string Realm { get; set; }
        public Region Region { get; set; } = Region.eu;
        public double RaiderIoScore { get; set; }
        public double ItemLvl { get; set; }
    }
}