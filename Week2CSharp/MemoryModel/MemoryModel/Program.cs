namespace MemoryModel;

internal class Program
{
    static void Main(string[] args)
    {
        int alin = 100;
        string ruya = "Ruya";
        double alex = 3.3;
        int[] samsung = {11,12,13};
        string[] mubashir = {"ricardo", "connor", "ali" };

        {
            var rakesh = alin;
            rakesh++;

            //Reference types COPY the ADDRESS, so the HEAP informtion is unchanged
            //Samsung is a reference to those values, change them values through a copy now both have the change
            var byron = samsung;
            byron[2] = 44;
            Console.WriteLine(samsung[2]);

            string[] valentin = { "owls", "dog" }; 
            mubashir = valentin;//Original strings now get unreferenced
            mubashir[0] = "a bird"; //Make a new sting and point at that one instead of Owl

            string luke = ruya;
            luke = luke.ToUpper(); //In strings case original is not affected due to it being immutable
            Console.WriteLine(ruya);
            Console.WriteLine(luke);
        }
        //Becase everything is defined in a scope anything created here is thrown off the heap after the { }

        int ali = DemoMethod(samsung, alin);

        PassByReferenceDemo(ref alin, out ali);
    }

    static int DemoMethod(int[] Jack, int max)
    {
        max *= 2;
        Jack[1] = 404;
        return Jack[0];
    }

    static void PassByReferenceDemo(ref int ricardo, out int luke)
    {
        // in is now read only
        // Use ref if you want a reference but modifiable
        luke = ricardo * 3;
        ricardo++;

    }
}