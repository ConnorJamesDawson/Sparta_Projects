using static System.Net.Mime.MediaTypeNames;

namespace ExceptionsAndDataTypes;

public class Program
{
    static void Main()
    {
        // Exception = a runtime error has occured and the program "crashes" (throws an exception object) if not handled

        //Error types - Runtime, Syntax, logic

        try
        {
            var text = File.ReadAllText("");

            Console.WriteLine(text);

            Console.ReadLine();
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("Specific Exception: "+e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("General Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("I'm always run");
        }
    }
}