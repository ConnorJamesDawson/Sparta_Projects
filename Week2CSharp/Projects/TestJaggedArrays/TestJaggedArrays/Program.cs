namespace TestJaggedArrays;

internal class Program
{
    static void Main(string[] args)
    {
        string[][] fruits = new string[2][] 
        {
                    new string[] { "Apple", "Apricot" },
                    new string[] { "Mango", "Orange", "Melon"}
        };

        foreach (var animalGroup in fruits)
        {
            foreach (var animal in animalGroup)
            {
                Console.WriteLine(animal);
            }
        }
    }
}