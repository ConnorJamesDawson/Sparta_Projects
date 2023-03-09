namespace SafariPark.App;

#region classes and structs
/*public struct Point3D
{
    public int x;
    public int y, z; 
    public Point3D(int x, int y, int z = 5)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
        Person Connor = new Person("Connor", "Dawson", 25);
        Person Stacey = new Person(age: 28, firstName: "Stacey", lastName: "Blair");
        Person Brian = new Person("Brian");

        Person James = new Person("James", "Webb") { Age = 53 };

        Person Alin = new Person()
        {
            FirstName = "Alin - George",
            LastName = "Rusu",
            Age = 23
        };

*//*        Console.WriteLine(Connor.GetFullName);
        Console.WriteLine(Stacey.GetFullName);
        Console.WriteLine(Brian.GetFullName);
        Console.WriteLine(James.GetFullName);
        Console.WriteLine(Alin.GetFullName);*//*

        Point3D p = new Point3D(3, 6, 2);
        var p2 = new Point3D();
        Point3D p3;
        p3.x = 3;
        p3.y = 6;
        p3.z = 2;
        Point3D p4 = new Point3D(1, 7);

        Console.WriteLine($"{p.x} {p.y} {p.z}");
        Console.WriteLine($"{p2.x} {p2.y} {p2.z}");
        Console.WriteLine($"{p3.x} {p3.y} {p3.z}");
        Console.WriteLine($"{p4.x} {p4.y} {p4.z}");


        Person john = new Person("John", "Jones") { Age = 20 };
        Point3D pt3D = new Point3D(5, 8, 2);
        DemoMethod(pt3D, john); //So because structs are value types they get copied so the pt in DemoMethod is a different version of pt3D
        //John gets affected becuase classes are a reference type*/
/*        static void DemoMethod(Point3D pt, Person p)
        {
            pt.y = 1000;
            p.Age = 92;
            p = null; //You are just assiging the ref of p to null becuase John is passes by Value
        }*/
        #endregion


public class Program
{
    static void Main()
    {
        #region Person Inheritence
/*        Hunter hunter = new("Marion", "Jones", "Samsung") {Age = 34 };

        Console.WriteLine(hunter.Age);
        Console.WriteLine(hunter.Shoot());

        Hunter h2 = new() { };
        Console.WriteLine(h2.Shoot());

        Rectangle rect = new(2, 4);

        Console.WriteLine(rect);
        Console.WriteLine($"{hunter}");*/
        #endregion

        Airplane airplane = new Airplane(200, 190, 100, "JetsRUs") { NumPassengers = 150}; 
        airplane.Ascend(500); 
        Console.WriteLine(airplane.Move(3));

        Console.WriteLine(airplane); 

        airplane.Descend(200); 

        Console.WriteLine(airplane.Move()); 

        airplane.Move(); Console.WriteLine(airplane);

    }
}