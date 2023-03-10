using Vehicle.App;

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

        #region Polymorphism and interfaces
        /*                List<Object> gameObjects = new List<Object>()
                        {
                         new Person("Cathy", "French"),
                         new Airplane(400, 200,  200, "Boeing") { NumPassengers = 55 },
                         new Vehicle(12, 20){NumPassengers = 6 },
                         new Hunter("Henry", "Hodgkins", "Pentax")
                        }; 

                        foreach (var gameObj in gameObjects)
                        {
                            Console.WriteLine(gameObj);
                        }
                Camera IPhone = new("IPhone");
                WaterGun playWet = new WaterGun("PlayWet");
                LaserGun jacks = new LaserGun("Jacks");
                LaserGun phillips = new LaserGun("Phillips");
                WaterGun nerf = new WaterGun("Nerf");
                SniperGun baretta = new SniperGun("baretta");

                List<IShootable> hunters = new List<IShootable>()
                {

                    new Hunter("Jack","L", jacks),
                    new Hunter("Phillip","N", phillips),
                    new Hunter("Nerd","Q", nerf),
                    new Hunter("Brad","A", baretta),
                    new Hunter("Oliver","E", IPhone),
                };

                Random rand = new Random();

                foreach (IShootable hunter in hunters)
                {
                    Console.WriteLine(hunter.Shoot(hunters[rand.Next(0,4)].ToString())); 
                }

                if (hunters[0].Equals(jacks))
                {
                    Console.WriteLine("Test successful");
                }*/
        #endregion

        #region Object Comparison
        /*        Person bobOne = new Person("Bob", "Builder") { Age = 26 };
                Person bobTwo = bobOne; //Two is equal due to the assign without the new keyword
                bool areSame = bobOne.Equals(bobTwo);

                Person bobThree = new("Bob", "Builder") { Age = 25 }; //Three is not the same as One due to the new keyword

                bool areSameOneThree = bobOne.Equals(bobThree);
                Console.WriteLine(areSameOneThree);

                var bobFour = new Person("Bob", "Builder") { Age = 23 }; 

                List<Person> personList = new List<Person> { bobOne, bobTwo, bobThree, bobFour };

                personList.Sort();*/
        #endregion

        #region Collection

        var helen = new Person
        {
            FirstName = "Helen",
            LastName = "Troy",
            Age = 22
        };

        var will = new Hunter
        {
            FirstName = "William",
            LastName = "Shakespeare",
            Age = 457
        };

        Console.WriteLine("List of people");

        List<Person> thePeople = new List<Person> { helen, will };

        foreach (var person in thePeople)
        {
            Console.WriteLine(person);
        }
        Console.WriteLine();

        List<int> numberList = new() { 5, 4, 3, 9, 0 };


        numberList.Add(8);
        numberList.Sort();
        numberList.RemoveRange(1, 2);
        numberList.Insert(2, 1);
        numberList.Reverse();
        numberList.Remove(9);

        foreach (int num in numberList)
        {
            Console.Write($"{num}");
        }
        Console.WriteLine("");
        Console.WriteLine("LinkedList of people");

        LinkedList<Person> thePeopleLinked = new LinkedList<Person>();
        thePeopleLinked.AddFirst(helen);
        thePeopleLinked.AddLast(will);

        LinkedListNode<Person> insertNode = thePeopleLinked.Find(will)!; //
        /* Link lists are good for lists where the only use is if you are accessing sequential data (either forwards or backwards) 
         * random access is relatively expensive since it must walk the chain each time (hence why it doesn't have an indexer). 
         * So unless you need a list where the order is not going to be shuffeled around/added to in real time just use a List.
         * Linked lists are just better for speed and memory*/

        thePeopleLinked.AddBefore(insertNode, new Person
        {
            FirstName = "Linda",
            LastName = "Smith",
            Age = 45
        });

        foreach (Person person in thePeopleLinked)
        {
            Console.WriteLine(person);
        }
        Console.WriteLine("");
        Console.WriteLine("Queue of people");

        var myQueue = new Queue<Person>(); // For queue its a list that can only be accessed at the front of the list with Enqueue and Dequeue
        myQueue.Enqueue(helen);
        myQueue.Enqueue(will);
        myQueue.Enqueue(new Person("Cathy"));

        foreach (var q in myQueue)
        {
            Console.WriteLine(q);
        }
        var first = myQueue.Peek();
        var serve = myQueue.Dequeue();
        Console.WriteLine();
        Console.WriteLine("Stack of numbers");

        int[] original = new int[] { 1, 2, 3, 4, 5 };
        int[] reversed = new int[original.Length];
        var stack = new Stack<int>();
        // Populate the stack
        foreach (var n in original)
        {
            stack.Push(n);
        }
        // Write out the stack
        foreach (var s in stack)
        {
            Console.WriteLine(s);
        }
        // Populate reversed from the stack
        for (int i = 0; i < original.Length; i++)
        {
            reversed[i] = stack.Pop();
        }
        Console.WriteLine();

        Console.WriteLine("HashSet of people");
        var peopleSet = new HashSet<Person>
        {
         helen,
         new Person("Jasmine", "Carter"),
         new Person("Andrei", "Masters")
        };
        var successMartin = peopleSet.Add(
            new Person
            {
                FirstName = "Martin",
                LastName = "Beard"
            });
        var successHelen = peopleSet.Add(
            new Person
            {
                FirstName = "Helen",
                LastName = "Troy",
                Age = 22
            });
        foreach (var entry in peopleSet)
        {
            Console.WriteLine(entry);
        }
        Console.WriteLine();

        var morePeople = new HashSet<Person>
        {
             new Person("Cathy", "French"),
             new Person("Jasmine", "Carter")
        };
        peopleSet.IntersectWith(morePeople);

        var vehicleSet = new HashSet<SafariVehicle>()
        {
             new SafariVehicle{ NumPassengers = 3, Speed = 2},
             new SafariVehicle{Speed = 100}
        };
        var success = vehicleSet.Add(new SafariVehicle { Speed = 100 });

        Console.WriteLine("Dictionary of people");
        var personDict = new Dictionary<string, Person>
        {
             {"helen", helen },
             {"sherlock", new Person("Sherlock", "Holmes") {Age = 40 } }
        };
        var p = personDict["sherlock"];
        personDict.Add("will", will); Console.WriteLine();

        #endregion

    }
}