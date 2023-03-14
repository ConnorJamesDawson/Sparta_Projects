using Calculator;
using System.Runtime.CompilerServices;

internal class Program
{
    public static void Main(string[] args)
    {
        bool quit = false;

        InputHandling.WelcomeMessage();

        while (!quit)
        {// Have a general reset before any calculation 

            InputHandling.handleInput(InputHandling.ReadInput());
        }
    }
}