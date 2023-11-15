using OOP_Lab1;

class Program
{
    static void Main()
    {
        GameAccount Serhii = new GameAccount("Serhii", 150);
        GameAccount Petro = new GameAccount("Petro", 1300);
        GameAccount Nastia = new GameAccount("Nastia", 156);
        GameAccount Polina = new GameAccount("Polina", 20);

        try
        {
            Serhii.GameResult(Petro, true, 25);
            Serhii.GameResult(Nastia, false, 3);
            Serhii.GameResult(Polina, true, 9);

            Petro.GameResult(Serhii, false, 25);
            Petro.GameResult(Nastia, true, 23);

            Nastia.GameResult(Serhii, true, 15);
            Nastia.GameResult(Petro, false, 5);

            Polina.GameResult(Serhii, false, 9);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Serhii.GetStats();
        Petro.GetStats();
        Nastia.GetStats();
        Polina.GetStats();
    }
}

