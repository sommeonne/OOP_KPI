using OOP_Lab2;
using OOP_Lab2.Accounts;

class Program
{
    static void Main()
    {
        BaseAccount Serhii_Base = new BaseAccount("Serhii", 200);
        BaseAccount Petro_Base = new BaseAccount("Petro", 100);
        StreakAccount Nastia_Streak = new StreakAccount("Nastia", 300);
        PremiumAccount Polina_Premium = new PremiumAccount("Polina", 500);

        try
        {
            Serhii_Base.GameResult(Petro_Base, true, 25,"standart");
            Serhii_Base.GameResult(Nastia_Streak, false, 50, "standart");
            Serhii_Base.GameResult(Petro_Base, true, 30, "training");

            Petro_Base.GameResult(Petro_Base, false, 100, "");
            Petro_Base.GameResult(Nastia_Streak, true, 23, "training");

            Nastia_Streak.GameResult(Serhii_Base, true, 15, "standart");
            Nastia_Streak.GameResult(Petro_Base, true, 20,"standart");
            Nastia_Streak.GameResult(Polina_Premium, true, 20, "standart");

            Polina_Premium.GameResult(Serhii_Base, true, 80,"standart");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error: {ex.Message}");
        }

        Serhii_Base.GetStats();
        Petro_Base.GetStats();
        Nastia_Streak.GetStats();
        Polina_Premium.GetStats();
    }
}

