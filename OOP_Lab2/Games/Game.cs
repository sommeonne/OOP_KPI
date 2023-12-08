abstract class Game
{
    public int ID { get; set; }
    public string User { get; }
    public string Opponent { get; }
    public int Rating { get; }
    public int NewRating { get; set; }
    public string GameResult { get; }

    public static int lastAssignedId = 1;
    public abstract int GameRating(int rating);

    public Game(string user, string opponent, int rating, string result)
    {
        User = user;
        Opponent = opponent;
        Rating = GameRating(rating);
        GameResult = result;
    }
}



