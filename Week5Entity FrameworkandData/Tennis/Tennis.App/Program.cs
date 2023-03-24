namespace Tennis.App;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to a Tennis Match!");
        while(true)
        {
            Console.WriteLine("Who is going to win the round? \n1: Player One \n2: Player Two");

            HandleInput();

        }
    }

    static void HandleInput()
    {
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.WriteLine(MatchController.Player1Scores());
                break;
            case "2":
                Console.WriteLine(MatchController.Player2Scores());
                break;
            default:
                Console.WriteLine("That is an incorrect value");
                HandleInput();
                break;
        }
    }
}