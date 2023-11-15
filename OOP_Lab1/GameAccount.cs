using System;

namespace OOP_Lab1
{
    class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        private int GamesCount { get => gamesHistory.Count(); }

        public List<GameAccount> Opponents { get; set; } = new List<GameAccount>();
        private List<Game> gamesHistory = new();
      
        public GameAccount(string userName, int initialRating = 100)
        {
            UserName = userName;
            CurrentRating = (initialRating > 1) ? initialRating : 1;
        }

        public void WinGame(GameAccount opponent, int rating)
        {
            CurrentRating += rating;
            gamesHistory.Add(new Game(UserName, opponent.UserName, rating, CurrentRating, "Win"));
        }

        public void LoseGame(GameAccount opponent, int rating)
        {
            CurrentRating -= rating;
            gamesHistory.Add(new Game(UserName, opponent.UserName, rating, CurrentRating, "Lost"));
        }

        public void GameResult(GameAccount opponent, bool result, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating cannot be less than one.");
            }
            else if (this != opponent && !Opponents.Contains(opponent))
            {
                Opponents.Add(opponent);

                if (result)
                {
                    WinGame(opponent, rating);
                    opponent.LoseGame(this, rating);
                }
                else
                {
                    LoseGame(opponent, rating);
                    opponent.WinGame(this, rating);
                }
            }
            else if (this == opponent)
            {
                throw new ArgumentException("Cannot play with yourself");
            }
            else
            {
                throw new ArgumentException("You've already played with this opponent");
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
