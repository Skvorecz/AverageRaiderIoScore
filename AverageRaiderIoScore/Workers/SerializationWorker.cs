using AverageRaiderIoScore.Domain;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace AverageRaiderIoScore.Workers
{
    class SerializationWorker
    {
        public async void SerializeAppSnapshotAsync(AppSnapshot appSnapshot, string filePath)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                await Task.Run(() => serializer.Serialize(file, appSnapshot));
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