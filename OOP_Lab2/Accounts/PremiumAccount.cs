namespace OOP_Lab2.Accounts
{
    class PremiumAccount : GameAccount
    {
        protected override void GameRating(bool result, int rating)
        {
            if (result)
            {
                CurrentRating += rating*2;
            }
            else
            {
                CurrentRating -= rating/2;
            }
        }

        public PremiumAccount(string userName, int initialRating=500) : base(userName, initialRating)
        {
       
        }
    }
}
