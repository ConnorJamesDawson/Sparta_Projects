namespace AdventOfCode.app;

public class Program
{
    static void Main()
    {

    }

    public static int[][] Elves = new int[][]
    {
        new int[]{1000, 2000, 3000},
        new int[]{4000},
        new int[]{5000, 6000},
        new int[]{7000, 8000, 9000},
        new int[]{10000},
    };

    public static string FindElfHolding(int calorieWanted)
    {
        for (int i = 0; i < Elves.Length; i++)
        {
            for (int j = 0; j < Elves[i].Length; j++)
            {
                if (Elves[i][j] == calorieWanted) return (i + 1).ToString() + " Elf";
            }
        }
        return "-1";
    }

    public static string FindElfHoldingMostCalories()
    {
        int sum = 0;
        int arraySum = 0;
        for (int i = 0; i < Elves.Length; i++)
        {
            for (int j = 0; j < Elves[i].Length; j++)
            {
                arraySum += Elves[i][j];
            }
            if (arraySum > sum) sum = i;
            arraySum = 0;
        }
        return sum.ToString() + " Elf";
    }

}