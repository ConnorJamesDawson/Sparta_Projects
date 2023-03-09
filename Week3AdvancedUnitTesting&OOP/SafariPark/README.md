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



Further reading -

https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces - Polymorphism