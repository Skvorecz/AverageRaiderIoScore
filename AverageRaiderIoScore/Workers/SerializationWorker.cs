using AverageRaiderIoScore.Domain;
using Newtonsoft.Json;
using System.IO;

namespace AverageRaiderIoScore.Workers
{
    class SerializationWorker
    {
        public void SerializeAppSnapshot(AppSnapshot appSnapshot, string filePath)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, appSnapshot);
            }
        }

        public AppSnapshot DeserializeAppSnapshot(string filePath)
        {
            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                AppSnapshot snapshot = (AppSnapshot)serializer.Deserialize(file, typeof(AppSnapshot));
                return snapshot;
            }
        }
    }
}