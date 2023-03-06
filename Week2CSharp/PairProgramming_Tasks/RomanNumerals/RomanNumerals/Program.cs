namespace RomanNumerals
{
    public class Program
    {
        static void Main(string[] args)
        {
            string romanNumeral = "MMCM";
            Console.WriteLine($"Number of {romanNumeral} is {PassRomanNumerals(romanNumeral)}");
        }

        public static int PassRomanNumerals(string input)
        {
            input = input.ToUpper();
            int counter = 0;
            for(int i=0; i < input.Length; i++)
            {
                int next = i+1;
                if(next >= input.Length)
                {
                    next = i;
                }
                switch (input[i])
                {
                    case 'I':
                        if (input[next] == 'V' || input[next] == 'X') counter--;
                        else counter++;
                        break;
                    case 'V':
                        counter += 5;
                        break;
                    case 'X':
                        if (input[next] == 'L' || input[next] == 'C' || input[next] == 'D' || input[next] == 'M') counter-=10;
                        else counter += 10;
                        break;
                    case 'L':
                        counter += 50;
                        break;
                    case 'C':
                        if (input[next] == 'D' || input[next] == 'M') counter -= 100;
                        else counter += 100;
                        break;
                    case 'D':
                        counter += 500;
                        break;
                    case 'M':
                        counter += 1000;
                        break;
                }
                
            }
            return counter;
        }
    }
}