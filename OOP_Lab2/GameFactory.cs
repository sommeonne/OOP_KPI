using OOP_Lab2.Games;
using System;

namespace OOP_Lab2
{
    class GameFactory
    {
        public static Game CreateGame(string gameType, string user, string opponent, int rating, string result)
        {
            return gameType.ToLower() switch
            {
                "standart" => new StandartGame(user, opponent, rating, result),
                "training" => new TrainingGame(user, opponent, rating, result),
                "bot" => new BotGame(user, rating, result),
                _ => throw new ArgumentException("Invalid game type"),
            };
        }

    }
}
