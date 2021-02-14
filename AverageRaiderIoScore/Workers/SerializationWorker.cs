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
    }
}