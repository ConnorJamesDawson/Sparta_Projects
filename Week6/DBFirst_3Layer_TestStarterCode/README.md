#Test Doubles using Fakes and Moq
 
- What are the 5 types of test doubles?
test stubs, mocks, dummies, spies, fakes.

- Why should you use an in-memory database for testing?
So you're not testing on a live server. Means the tests will also use less resources.

- Why should you use the Moq framework for testing?
Moq makes it easier to unit test more complicated objects without writing a lot of boilerplate code. It also makes it easier to assert that your tests are passing.

- Why did we refactor our WPF-EF system to use a Service class?
We did that to reduce duplicate code we had with each individual method having their own using statement that was clogging up the processing speed of the app. With the service class we only use a single instance of NorthwindContext to do all CRUD operations

- How does Dependency injection aid unit testing?
Dependency injection helps if you have a class that needs a dependent class-instance to do some sub-processing. Such as with the Customer Manager needed a customer service sub class to function so we needed to moq it

- When would we want to use a dummy?
The dummies are objects that our SUT depends on, but they are never used.

- What does a Stub do?
A stub is an object which returns fake/Made up data. So it emulates what a class should return instead of using the actual classes methods

- How can we use a Moq to check if a method is called with the correct parameters?
When a moq is made you can use .Setup() and in the () you can use a lambda/anonymous method to setup the fake method that can be called by the moq object and determin it's return

So in our example mockService.GetCustomerById("Rock").Returns(new Customer), when the method is called return a new customer

- What is the difference between strict and loose mocking behaviour?
Strict behavior means that exceptions will be thrown if anything that was not set up on our interface is called. 
Loose behavior, on the other hand, does not throw exceptions in situations like this.
