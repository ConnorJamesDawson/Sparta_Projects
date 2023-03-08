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
