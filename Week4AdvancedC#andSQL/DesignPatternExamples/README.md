# Design Pattern

Pattern examples:

- Factory Method
- Singleton
- Stratergy
- Decorator
- Catagory of patterns - 
Creational, Used when creating objects
Behavioural, Defines the behaviour of an object
Structual, Defines the structure of a group of projects

Has it's roots in engineering, a way of expressing good design principles.

Usually set out like 

- Name
- intent
- Desc of the problem it's trying to solve
- The solution, A tamplate of really not the real solution
- Usually a discussion of trade-offs and consequences
- Other realated patterns

## Model View Controller

Enables seperation of concerns

What is the View, the Model and the Controller

View - What is represented
Model - data
Controller - Controls the dialogue

## Singleton

Ensures there is only one instnace of the object, whilst providing global access

Problem is there is only one instance of the file which leads to high coupling

To make an instance:
- make constructor private.
- Make readonly static property of the same type called Instance
- Use that to retrieve the instance of the object

public class MySingleton()
{
    private MySingleton() {}
    public static MySingleton Instance {get;} = new MySingleton
}

public class MySingleton()
{
    private MySingleton() {}
    public static MySingleton _instance 
    {
        get{
            if(_instance == null)
                _instance = new MySingleton();
        return _instance
        }
    } 
}

Mysingleton singleton = MySingleton.Instance;

## Factory Method

Provides a way of contructing objects within a project to stop the code being littered with new keywords.

So a switch statement, based on responce make certain classes, make sure these classes have common functonality to avaoid issues

## Stratergy

Stratergy allows an algorithm to vary independently from the clients that use it.

The problem: we want instances of a class to have different behaviour which can vary over time.

Define a fanily of algorithms; e.g Weapons for the SafariPark project, a base class that can be interchanged with other classes that can vary in output.

## Decorator

To attach additional responsibilities to an object dynamically, by plaing them in wrapper objects that contain the behaviours

It's more flexible than static inheritence and it avoids classes having too many features high up the inheritence

Uses a base class that doesn't have any arguments but then have classes that would take that base class as an argument around it.

e.g. Weapon Sulferas = new BrandOfRag(new Beserk(newHammer()))

So each enchantment would get the base classes attack of the base weapon (in this case a hammer) then in each enchantment you would have Attack() => _weapon.Attack() + 20; and so would influence the base.Attck() when it is returned.

# GitHub Questions

- What is a Design Pattern?

A design pattern is a set of principles outlined from experienced people in the field to express good design principles for your code.

- What problem does the Singleton Design Pattern try to solve?

The Singleton design tries to solve the problem of programs creating new objects everytime it uses a class that is globally available by tieing the globally available class to an instance of an object when it is first created

- Describe how the Singleton Design Pattern could be implemented in C#

When ever a class is created set it to the instance if it is not already set

public class MySingleton()
{
    private MySingleton() {}
    public static MySingleton _instance 
    {
        get{
            if(_instance == null)
                _instance = new MySingleton();
        return _instance
        }
    } 
}

- What problem does the Factory method pattern attempt to solve?  How is it implemented in C#?

Factory method provides a way of contructing objects within a project in a agile manner to stop the code being littered with new keywords based on if statements.

So a switch statement, based on responce make certain classes

- What is the Strategy Design Pattern?

Stratergy allows an algorithm to vary independently from the clients that use it.

The problem: we want instances of a class to have different behaviour which can vary over time.

Define a fanily of algorithms; e.g Weapons for the SafariPark project, a base class that can be interchanged with other classes that can vary in output.

- What is the Decorator Design Pattern?

To attach additional responsibilities to an object dynamically, by plaing them in wrapper objects that contain the behaviours

- What are the 3 categories of Design Patterns?

Creational, Used when creating objects
Behavioural, Defines the behaviour of an object
Structual, Defines the structure of a group of projects

- What is MVC?

Enables seperation of concerns

View - What is represented
Model - data
Controller - Controls the dialogue
