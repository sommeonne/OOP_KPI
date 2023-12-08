using System;

namespace OOP_Lab2
{
    abstract class GameAccount
    {
        public string UserName { get; set; }
        private int _currentRating;
        public int CurrentRating
        {
            get => _currentRating;
            set
            {
                if (value > 1)
                {
                    _currentRating = value;
                }
                else
                {
                    _currentRating = 1;
                }
            }
        }
        private int GamesCount { get => gamesHistory.Count(); }

        public List<GameAccount> Opponents { get; set; } = new List<GameAccount>();
        private List<Game> gamesHistory = new();

        protected virtual void GameRating(bool result, int rating)
        {
            if (result)
            {
                CurrentRating += rating;
            }
            else
            {
                CurrentRating -= rating;
            }
        }
        public GameAccount(string userName, int initialRating = 100)
        {
            UserName = userName;
            CurrentRating = (initialRating > 1) ? initialRating : 1;
        }

        public void WinGame(Game game)
        {
            GameRating(true, game.Rating);
            game.NewRating = CurrentRating;
        }

        public void LoseGame(Game game)
        {
            GameRating(false, game.Rating);
            game.NewRating = CurrentRating;
        }
        public void GameResult(GameAccount opponent, bool result, int rating, string gameType)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating cannot be less than one.");
            }
            else if (this != opponent)
            {
                if (result)
                {
                    gamesHistory.Add(GameFactory.CreateGame(gameType, UserName, opponent.UserName, rating, "Win"));
                    opponent.gamesHistory.Add(GameFactory.CreateGame(gameType, opponent.UserName, UserName, rating, "Lost"));
                    WinGame(gamesHistory.Last());
                    opponent.LoseGame(opponent.gamesHistory.Last());
                }
                else
                {
                    gamesHistory.Add(GameFactory.CreateGame(gameType, UserName, opponent.UserName, rating, "Lost"));
                    opponent.gamesHistory.Add(GameFactory.CreateGame(gameType, opponent.UserName, UserName, rating, "Win"));
                    LoseGame(gamesHistory.Last());
                    opponent.WinGame(opponent.gamesHistory.Last());
                }

                gamesHistory.Last().ID = ++Game.lastAssignedId;
                opponent.gamesHistory.Last().ID = Game.lastAssignedId;
            }
            {
                if (result)
                {
                    gamesHistory.Add(GameFactory.CreateGame("BOT", UserName, "", rating, "Win"));
                    WinGame(gamesHistory.Last());
                }
                else
                {
                    gamesHistory.Add(GameFactory.CreateGame("BOT", UserName, "", rating, "Lost"));
                    WinGame(gamesHistory.Last());
                }
                gamesHistory.Last().ID = ++Game.lastAssignedId;
            }
        }


        public void GetStats()
        {
            Console.WriteLine($"Game history for {UserName}(Rating: {CurrentRating}):");

            Console.WriteLine("┌────────────────┬──────────┬──────────┬─────────┬────────┬─────────────────┐");
            Console.WriteLine("│      ID        │   User   │ Opponent │ Rating  │ Result │ Current Rating  │");
            Console.WriteLine("├────────────────┼──────────┼──────────┼─────────┼────────┼─────────────────┤");

            for (int i = 0; i < GamesCount; i++)
            {
                Console.WriteLine($"│ {gamesHistory[i].ID,14} │ {gamesHistory[i].User,-8} │ {gamesHistory[i].Opponent,-8} │ {gamesHistory[i].Rating,7} │ {gamesHistory[i].GameResult,-6} │ {gamesHistory[i].NewRating,15} │");
                Console.WriteLine("├────────────────┼──────────┼──────────┼─────────┼────────┼─────────────────┤");
            }

            Console.WriteLine();
        }



    }
}