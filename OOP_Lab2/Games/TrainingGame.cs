namespace OOP_Lab2.Games
{
    class TrainingGame: Game
    {
        public override int GameRating(int rating)
        {
            return 0;
        }
        public TrainingGame(string user, string opponent, int rating, string result) : base(user, opponent, rating, result)
        {

        }
    }
}
