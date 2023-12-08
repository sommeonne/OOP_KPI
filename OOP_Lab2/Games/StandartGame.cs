namespace OOP_Lab2.Games
{
    class StandartGame : Game
    {
        public override int GameRating(int rating)
        {
            return rating;
        }

        public StandartGame(string user, string opponent, int rating, string result): base(user, opponent, rating, result)
        {

        }
    }
}
