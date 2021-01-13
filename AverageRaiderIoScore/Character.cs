namespace AverageRaiderIoScore
{
    class Character
    {
        public string Name { get; set; }
        public string Realm { get; set; }
        public Region Region { get; set; } = Region.eu;
        public int RaiderIoScore { get; set; }
        public int ItemLvl { get; set; }
    }
}