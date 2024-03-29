# Exceptions and Numeric Data Types

## What is an exception?

An exception is a problem that arises during the execution of a program 

## What is the difference between an exception and other types of errors?

An Error "indicates serious problems that a reasonable application should not try to catch." 

An Exception "indicates conditions that a reasonable application might want to catch."

## How would you use a try-catch block when handling exceptions? 

try
{
	Block of code to try;
}
Catch(exceptionType Thrown exception)
{
	Code block for what happens when the error is thrown;
}

## In handling exceptions, when is the finally block run?

finally is run after the system has either caught the exception or has not found one

## What is meant by a "Strongly Typed Language"?  

- You have defined what type the data is - statically typed
- We cannot assign differently typed data to a variable - type safe

## Why is C# described as memory safe? -  

- Memory safe, 00000001, memory sizes are known and syntax errors are thrown when converting one data type to a smaller memory data type which would lead to a loss of data

## What happens if you add 3 to the largest int?  To the largest unsigned int?  

Adding 3 to the max int value would cause a numerical overflow 

## What data types can int be safely converted to?

long, float, decimel

## How would you find out the largest value an Int32 value type can be?  

Int32.MaxValue

## What is casting?  

Casting is the explicit conversion of data types where it would lead to some data loss such as (int)16.10 would make the number lose the decimal numbers

## How can you prevent silent overflow of integers?  

Have the code in a checked{} code block where it would throw an exception if the value were to overflow 
