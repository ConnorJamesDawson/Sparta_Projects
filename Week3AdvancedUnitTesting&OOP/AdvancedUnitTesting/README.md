# Advanced Unit Testing with NUINT

## What is nunit?

Xunit.x, msTest - alternate testing software, mostly they are the same, but there are significant small differences.

nunit framework allows the keywords to function inside the scope of the project it is attached to.

### Test Runners
Test runners run the tests that are setup, run in visual studio 

You can run tests from the command line, need to be in actual test project, dotnet test --list-tests to list tests, dotnet test runs the available tests

## What is a constraint unit? What is a classical unit test?

The constraint unit tests are the assertion functions covered in lessons

https://docs.nunit.org/articles/nunit/writing-tests/assertions/assertion-models/classic.html For classic model tests

## TestCaseSource

If you want to use data for multiple methods use TestCaseSource("Method") - Has to be static

private static object[] AddCases = //This is a field 
{
	new int[]{ 2, 4, 6}
};

## TestFixture

Not needed anymore, just used to mark a class as a test fixture and may provide inline constructor arguments.

## TestConstuctors

Each test has a constructor that is called before the class.

### SetUp

Any method in SetUp is called before any test, allowing tests to not interfere with each other

### Helper Method

When you have alot of tests and not all of them use everything in the SetUp, just split them up and make them into Methods with meaningful names

## [Category("Name")]

Allows you to bunch tests by a certain trait in the test explorer to sort them into

## Characteristics of a good Unit Tests

Fast - Some big projects might have thousands of tests, tests need to be able to run in milliseconds
Isolated - The tests should be able to run on it's own without outside help 
Repeatable - Conistsant results
Self-Checking - The test must be able to say wether the test has passed or not
Timely - If a test is taking to long to make, it needs to be broken down most likely

## Naming your tests
The name of your test should consist of three parts:

The name of the method being tested.
The scenario under which it's being tested.
The expected behavior when the scenario is invoked.

so ProgramAdd_MultipleNumbers_ReturnsCorrectResult

## [Ignore("Message")]

Marks the tests to be skipped for now. Can be put at the start of the test class to Ignore all tests or under [Test] to Ignore specific tests.

## Further Reading 
- [Classic Model nunit test methods](https://docs.nunit.org/articles/nunit/writing-tests/assertions/assertion-models/constraint.html)
- [Attributes for nunit](https://docs.nunit.org/articles/nunit/writing-tests/attributes.html)
- [Characteristics of a good unit test](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#characteristics-of-a-good-unit-test)

## github Questions Part 1

### Advanced Unit Testing

- What is the difference between the NUnit Framework and NUnit3TestAdapter?

The NUnit3TestAdapter extension works with the Visual Studio Unit Test window to allow integrated test execution in Visual Studio, the framework is the code source on which the tests are made.

- Give some other examples of NUnit test runners

TestDriven.NET, ReSharper and MBunit.

- What does the attribute [SetUp] indicate and when does the associated method run?

The SetUp attribute is used inside a TestFixture to provide a common set of functions that are performed just before each test method is called.

- If an NUnit class has a constructor, when does it run?

The constructor is only run once, unlike SetUp, when the test class is called to run tests.

- What are the three A's of unit testing?

Arrange
Act
Assert

- How do you exclude a test from being run?

To exculde a test from geing run you use the [Ignore] keyword under the [Test] keyword

- What does the [TestCaseSource] attribute do?

[TestCaseSource] is used to point towards the information to be used on the Test which is different from [TestCase()] where you feed the information directly.

- What is the TDD cycle?

Write a failing test - Test fails until made to pass - Refactor the code

- What are the advantages of using TDD?

By starting tests with the simplest functionality first, you can use them to guide your logic as you build up functionality. This helps you to break a problem down into smaller, more manageable pieces, thus aiding the problem solving process.

Fewer bugs and errors.

- What are the pitfalls of doing TDD?

slow process - If you begin TDD, you’ll get the sensation that you simply need an extended duration of your time for straightforward implementations. YOu need to write tests for simple processes when you could just write the process and save time.

Tests help to seek out bugs, but they can not find bugs that you simply introduce within the test code and in implementation code. If you haven’t understood the matter you would like to unravel, writing tests most likely doesn’t help.