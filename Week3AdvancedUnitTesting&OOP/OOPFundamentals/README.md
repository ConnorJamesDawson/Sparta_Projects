# OOP Fundamentals Notes

## What is OOP

Procedral programming is a style where a code in one place is modifying code in another.

It became clear there is problems with Procedral programming, means programs lack modularity

High degree of coupling - harder to use code that relys heavily on other non linked information

Object-Orientated Programming, if the method belongs to certain data it should be kept with the information it needs (in a class)

Benifets of OOP:

- Data and functions are combined
- Better modularity, everything is self contained
- Re use is easier because of the modularity allowing the program wot be dropped into another project easily

The principles of OOP-

- Abstraction
- Encapsulation
- Inheritance
- Polymorphism

## Abstraction

Think of a car, what does it include? 

- Engine
- Doors
- Seats
- Body
ect ect

It's the mindset of What methods should a class have logically

abstract = class

## Encapsulation

How do I work this thing?

A class should be simple, have a consistance interface to use it and have a well defined responsibility

A class should also hide data and implementation inside of it and use functions instead

## Inheritence

Inheritence looks to reduce duplicate code by having a "parent" class for which "child" all use for properties in said classes.

E.g in a FPS game, all guns would have ammo, a sight and can shoot, so a parent class would have these functions so the child classes wouldn't have to, reducing the amount of code needed in the specific guns classes

It allows specilisation of child classes whilst reusing methods from the parent

Use the keyword base to link to arent methods within child classes

## Polymorphism

When information gets added into a class, the class knows what to do with the information without additional input, e.g. AddClass, should be able to add the class to a database without additional input

In the parent class if you want a childs method to override the parent one you need the virtual keyword in the parent method and override in the childs method

## GitHub Questions - OOP Part 2

- What is abstraction?

Data abstraction is the process of hiding certain details and showing only essential information to the user.
Abstraction can be achieved with either abstract classes or interfaces.

- What are the elements of a C# class?

Constructor, Field, Properties and Methods

- What is encapsulation?

Abstraction can be achieved with either abstract classes or interfaces

- How does C# support encapsulation?

c# spports encapsulation by having access specifiers: Private, Public, Protected, internal and protected internal 

- What does a constructor do?

A constructor usually initializes the data members of the new object when the class is instantiated.

- What is the difference between a constructor and other methods?`

A contructor is called everytime the class is instantiated with the [new] keyword whilst the other methods can be called anytime after the constructor is called.

- What is a C# property?
 
Properties is a mechanism able to get and set a private field in the class, a property is able to read, write or compute the information given to the mechanism and can use logic to influence the value given to the property/;

- What is object initialisation?

Object initializers let you assign values to any accessible fields or properties of an object at creation time instead of leaving the Object null

- What does the static keyword mean?

The static keyword is used to make a data item non-instantiable. 

- What is a backing field?

A Backing field is an autogenerated field for any property which can only be used inside the accessors(getter or setter) of that Property

- What does the virtual keyword mean?

The virtual keyword is used to mark a method as being overwriteable in a parent class

- What happens if you attempt to override a method that is not marked virtual?

You cannot override a non-virtual method.

- What does the sealed keyword mean?

Sealed means that is class cannot be inherited from.
