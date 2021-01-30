using Newtonsoft.Json.Linq;

namespace AverageRaiderIoScore.Workers
{
    class JsonWorker
    {
        private JObject JObject { get; }

        public double RaiderIoScore => JObject["mythic_plus_scores_by_season"][0]["scores"]["all"].Value<double>();
        public double ItemLevel => JObject["gear"]["item_level_equipped"].Value<double>();

        public JsonWorker(string json)
        {
            JObject = JObject.Parse(json);
        }
    }
}
