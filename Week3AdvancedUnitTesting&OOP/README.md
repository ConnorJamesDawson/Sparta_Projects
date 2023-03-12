# github Questions Part 1

## Advanced Unit Testing

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