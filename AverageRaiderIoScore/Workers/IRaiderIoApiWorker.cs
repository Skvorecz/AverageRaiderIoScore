using AverageRaiderIoScore.Domain;

namespace AverageRaiderIoScore.Workers
{
    interface IRaiderIoApiWorker
    {
        string LoadCharacter(Character character);
    }
}