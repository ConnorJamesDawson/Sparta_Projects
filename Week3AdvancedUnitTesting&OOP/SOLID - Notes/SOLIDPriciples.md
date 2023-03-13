# SOLID Principles 

- S: Single Responsibility Principle (SRP)
- O: Open closed Principle (OCP)
- L: Liskov substitution Principle (LSP)
- I: Interface Segregation Principle (ISP)
- D: Dependency Inversion Principle (DIP)

## What is SOLID principles 

It's a methodology of how to structure and write your code, SOLID underlines Design Patterns.

## Single Responsibility Principle (SRP)

- A class should represent only one thing / have one responsibility.
- The class members should be cohesive, the fields and properties should hold information about the class and the methods should manipulate or return that information.

For example in the Safari Park Lesson, we had a Hunter with the _camera field and had a method to return that _camera information, if we wanted to add more functionality to the Camera we need to split Camera from the Hunter and just have a Field take a type of Camera in place of _camera.

High cohesion Low coupling

## Open closed Principle (OCP)

If change is coming, a class should be open for extension not modification.

For example in the Safari Park Lesson, We made a weapon class but made it abstract so it may be used but shouldn't be changed at a bass level, the child classes can change the exisiting code in Weapon to specilise the information, The sniper has a different return string as to the Laser Gun.

Exceptions are another example, we can customise an exception message but the core exception is unchanged, we can even add new exception (extend)

## Liskov substitution Principle (LSP)

You should be able to use any derived class instead of a parent class and have it behave in the same manner without modification.

So all classes that use a method implemented by an Interface, for example, should all have very similar results; throwing exceptions, different answers both violate LSP.

## Interface Segregation Principle (ISP)

Make smaller many interfaces that are more specifice than One general purpose Interface

Interfaces can inherit from each other

## Dependency Inversion Principle (DIP)

High level modules should not depend on low-level modules and low-level modules shouldn't depend on low-level modules.

So avoid using the new keyword as much as possible as this creates high dependancy, if the project were to lose a file it would break.

## Further Reading

https://learn.microsoft.com/en-us/dotnet/api/system.exception?view=net-7.0#choosing-standard-exceptions - Exceptions

## GitHub Questions SOLID

- What are the 5 SOLID principles?

- S: Single Responsibility Principle (SRP)
- O: Open closed Principle (OCP)
- L: Liskov substitution Principle (LSP)
- I: Interface Segregation Principle (ISP)
- D: Dependency Inversion Principle (DIP)

- Describe the Single Responsibility Principle

A class should only have one responsibility for its function and the class should be cohesive with it's informations manipulated or returned by the methods in that class.

- Describe the Open/Closed Principle

If change is coming, a class should be open for extension not modification. Exceptions are an example, we can customise an exception message but the core exception is unchanged, we can even add new exception (extend)

- Describe the Liskov Substitution Principle

You should be able to use any derived class instead of a parent class and have it behave in the same manner without modification.

- Describe the Interface Segregation Principle

Make smaller many interfaces that are more specifice than One general purpose Interface

- Describe the Dependency Inversion Principle

High level modules should not depend on low-level modules and low-level modules shouldn't depend on low-level modules.
