namespace TestJaggedArray;

internal class Program
{
    static void Main(string[] args)
    {
        int countRow1 = 2;
        int countRow2 = 4;
        int p = 6;
        string[][] newJaggedArray = new string[][]{
            new string[countRow1],
            new string[countRow2]
        };

        List<string> _list = new List<string> { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta" };
        for (int i = 0; i < countRow1; i++)
        {
            for (int j = 0; j < countRow2; j++)
            {
                Console.WriteLine($"Trying to wrtie to {i} {j}");
                try
                {
                    newJaggedArray[i][j] = _list[p++];
                    Console.WriteLine($"Writing {_list[p]} to {i} {j}");
                }
                catch (IndexOutOfRangeException e)
                {
                    break;
                }
            }
        }
    }
}