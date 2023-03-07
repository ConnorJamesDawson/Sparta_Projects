namespace FizzBuzz.app;

public class FizzBuzzer
{

    public static string FizzBuzz(int input)
    {
        if (input % 3 == 0 && input % 5 == 0) return "FizzBuzz";
        else if (input % 3 == 0) return "Fizz";
        else if (input % 5 == 0) return "Buzz";

        return input.ToString();
    }

}
