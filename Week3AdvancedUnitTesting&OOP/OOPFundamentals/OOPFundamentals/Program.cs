namespace OOPFundamentals;

internal class Program
{
    static void Main()
    {
        Person person;

        Random rand = new();

        int myRandomInt = rand.Next(0, 2);

        if (myRandomInt == 0) person = new Customer("Connor", "Dawson", "Newcastle");
        else person = new Employee("Connor", "Davison", "Software Dev");

        person.Print();
    }
}