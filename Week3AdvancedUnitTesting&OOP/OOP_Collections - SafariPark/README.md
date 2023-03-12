# Object Orientated Programming

## Encapsulation code

Encapsulation principles promotes having only the nessisary information public and the rest private to prevent misuse of the information from outside influence

### Traditonal/Basic way to preform Encapsulation

{
	private _firstName
	
	public GetFirstName{ return _firstName};
	public SetFirstName(string input){_firstName = input};

}

Except that example above is not a good method to preform encapsulation at all since you can still edit firstName in that example, so you would go with the following.

### Standard way to perform Encapsulation
{

    public string FirstName
    {
        get;
        init;
    } = "";

}

This example does the first example in less lines and made more secure through the keywords in the scope of FirstName:

- get; is short hand for GetFirstName and also creates the value of firstName, which is automatically private.
- init; Only allows the information to be edited when the call is initialised/Instantiated allowing the name to be set when created but readOnly after that.
- init; could also be set or private set, set would just exacly like the SetFirstName in the first example and private set would only allow firstName to be edited in the constructor so use init for a more flexible system.
- = ""; Allows you to set a deafault to the property but this is only useful when the property is not getting set in the classes constructor.

init allows this code to work as an alternative to woring in the constructor:
        Person Alin = new Person()
        {
            FirstName = "Alin - George",
            LastName = "Rusu",
            Age = 23
        };
## Inheritence

The relationship between 2 or more classes

Child contructor need : base to send informtaion to the parent e.g

    public Hunter(string firstName, string lastName, string camera = "" ) : base (firstName, lastName)
    {
        _camera = camera;
    }

? after the type such as string? means the type can be nullable

Abstract classes are used to mark a class as non instantiable, kind of like a bookmark to other coders that this class shouldn't be used on it's own and should only be used with it's child classes.

Methods in an abstarct class don't have to have a body as long as the implementation is done in it's children, this reduces the amount of duplicate code in the classes

To edit what a classes generates from a ToString you need, this can be used with Class.ToString() or just Class

Really veritile by passing arguments into the ToString

    public override string ToString()
    {
        return $"Message";
    }

If you want the parents method return as well you just need base.ToString() to add that return.

## Polymorphism

If you are gonna make a interface you need to note it with an I at the beggining

Everything in an interface is public and abstract.

The interface class is very useful to bind classes together and combine common functionality to allow seperate abstarct classes to present data to one another.

In the interface class you only need to declare the values to be used in all of the other classes, nothing else needs to be added.

## Equality and Comparisson

To generate an EqualTo functionality just Generate Equals and click both boxes, that'll make an equals that checks all values against one another, we can edit this to only check FullNqme for example 

## Collections

### LinkedLists vs Lists

Link lists are good for lists where the only use is if you are accessing sequential data (either forwards or backwards) random access is relatively expensive since it must walk the chain each time (hence why it doesn't have an indexer). So unless you need a list where the order is not going to be shuffeled around/added to in real time just use a List.Linked lists are just better for speed and memory

### Queue - First in First out

For queue its a list that can only be accessed at the front of the list with Enqueue and Dequeue (Dequeue also returns that first element)

### Stack - Last in first out

Push - Push on top of the 'stack'
Pop - Pop off the top of the stock
Peek - Look at the first element

### HashSet - unordered

Cannot have duplicates in a Hashset (two different objects with the same HashCode), if the two objects have the same Hashcode then the system goes to the Equals to see if they are truely the same object.

Further reading -

https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces - Polymorphism

## GitHub Questions Part 3 OOP-Continued

- What is an abstract method? An abstract class?

Abstract class: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class). 
Abstract method: can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).

- What is an interface? Can an abstract class be instantiated?

An interface is an abstract class that is used to joint two or more classes to use common functionality as a aprt of polymorphism.
An abstract class cannot be instantiated.

- Does an Abstract class have to have Abstract methods?  Describe a scenario where you would use an abstract class.

An abstract class does not have to have abstract methods. An abstract class could be used for a parent class that is never supposed to be instantiated so a parent Weapon class

- What is the difference between method overloading and method overriding?

Overloading is the ability to have multiple methods within the same class with the same name, but with different parameters. 
Overriding is known as compile-time (or static) polymorphism because each of the different overloaded methods is resolved when the application is compiled.

- What are the similarities and differences between classes and structs?

Structures are value types; classes are reference types. 

A variable of a structure type contains the structure's data, rather than containing a reference to the data as a class type does. 

Structures use stack allocation; classes use heap allocation.

- What class is the base class for all C# classes?

The Object Class

- What properties and methods does the Object class have?

ToString(), Equals(), GetHashCode(), GetType()

- What does the Object ToString() method do by default?

The default implementation of the ToString method returns the fully qualified name of the type of the Object

### Object Equality and Comparison

- How would you override the Equals method?

public override bool Equals()

- If you override Equals, what other method do you need to override and why?

If you are gonna override Equals you need to override the GetHashCode method as well as that is used for comparisons in the Hashdown collections to differentiate between duplicates

- How would you implement the CompareTo method of the IComparable interface?

    public int CompareTo(Person? other)
    {
        if (other == null) return 1;
        // This will sort by lowest value goes first, 1,2,3 a,b,c
        if (LastName != other.LastName)
        {
            return this.LastName.CompareTo(other.LastName);
        }
        else if (FirstName != other.FirstName)
        {
            return FirstName.CompareTo(other.FirstName);
        }
        else
        {
            return Age.CompareTo(other.Age);
        }
    }

- What is the relationship between CompareTo and Equals?

CompareTo method is comparing instance of object with parameter of String object. 
Equals method determine the value of both are the same or not. 

### Collections

- What is the best Collection type for fast access of sequentially stored items?

LinkedList as they are stored sequentially

- What is the difference between a Stack and a Queue?

Queue - First in first out
Stack - Last in first out

- What other Collection types are available? Briefly describe them.

Lists - a form of array
HashSet - an unordered list that is defined by what the element contains
Dictionary - A way of storing information in a list but adding a 'key' to the element to easily access that element later on
