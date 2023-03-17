# Code Smells

## Refactoring

Refactoring is changing the code body of a method without changing the output of the method

### When should you refactor?

When there is an objective to refactor the code into

When the project is source controlled already so you have a version to fall back on

When all tests run and pass

## Code Smells

Code that is recognisably bad but still works, e.g brute forcing

Inappropriate Names, Dead Code, Duplicate code, Long Methods, Feature Envy, repeted if else/switch chains

# GitHub Questions

- Define the term "Refactoring" 

Refactoring is changing your code to better fit the new requirements without changing the codes output, this can lead to splittling a method into multiple methods if need be

- When should you refactor your code? 

When you identify new requirements for the code or identify code smells. either through TDD or just general analysis

- When should you NOT refactor your code?

When the code has no identifiable code smells, has the intended output and passes all tests

- Define the term "Code Smells"

Code Smells is code that is recognisably bad but still works, the reasons for the code being recognisably bad could be; Large bloated methods, dead code and inappropriate

- Name some Code Smells

Inappropriate Names, Dead Code, Duplicate code, Long Methods, Feature Envy, repeted if else/switch chains

- What is a data clump?  How should you refactor your code if you find one? 

A data clump is a bloated method that appears to have too much code inside of it's code body, i.e the method is doing too much, a method should have one job as a part of Single Responcibility

- What is feature envy and what should you do about it? 

Feature envy is defined as occurring when a method calls methods on another class more times than on the source class.

This indicates that the method in question is in the wrong class and should be moved

- If a class has several methods which contain if/else or switch blocks that test a "type" attribute, what should you do about it?

Consolidate the methods into one Method if they have the same purpose of testing a 'Type' attribute 
