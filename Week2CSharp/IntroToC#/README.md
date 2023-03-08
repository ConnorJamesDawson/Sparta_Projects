# C# Basics and .NET
 
## What's compile time and run time?

compile time is the time it takes the computer to compile the given code, Run time is the time it takes the computer to run the application

##W hat is .NET?  

.NET is an open source developer platform, created by Microsoft, for building many different types of applications.

## What is the difference between .NET Framework, NET Core, and .NET5/.NET6/.NET7?  

.Net frame is for windows only
.NetCore is for UWP and ActiveServerPage.NEt (websites severs / cloud workloads)

Form .NET 5 onwars it became multiplatform for all disaplins, a build once run everwhere

## What is a conditional breakpoint?  

a conditional breakpoint is where once a certain condition is met a breakpoint is activated in the code that wouldn't otherwise have been activated

## What is the difference between compiling to debug and release formats?

Debug includes debug information in the compiled files (allowing easy debugging such as breakpoints and console staying open instead of crashing) while Release 
usually has optimizations enabled with the debugging options disabled.

# Methods
 
## What makes up a method signature?  

A method signature is made up of the methods name and parameter types takes as arguments

## What is a method body?  

A method body is the block of code inside of the method

## In a method signature, what does the void keyword mean?  

The void keyword means the method does not return any result

## What is method overloading?  

Method overloading is where multiple methods of the same name take different parameter types as input 

## What is an out parameter?  

The out parameter in C# is used to pass arguments to methods by reference, which then alters the reference.

int initializeInMethod;
OutArgExample(out initializeInMethod);
Console.WriteLine(initializeInMethod);     // value is now 44

void OutArgExample(out int number)
{
    number = 44;
}

## What are named arguments and why are they useful?

Named arguments enable you to specify an argument for a parameter by matching the argument with its name rather than with its position in the parameter list.

This is useful for the readability of the code as the code can specifically see what values are going to which arguement

## What is a tuple, and why is it useful?

Tuples are used to store multiple items in a single variable. These can be very useful for returning multiple data types instead of relying on multiple methods to return one datat type
