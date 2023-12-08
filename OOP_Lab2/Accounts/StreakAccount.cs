namespace OOP_Lab2.Accounts
{
    class StreakAccount : GameAccount
    {
        private int winningStreak = 0;

        public StreakAccount(string userName, int initialRating = 100) : base(userName, initialRating)
        {
        }

        protected override void GameRating(bool result, int rating)
        {
            if (result)
            {
                CurrentRating += rating * winningStreak++; 
            }
            else
            {
                CurrentRating -= rating;
                winningStreak=0;
            }
        }
    }
}
