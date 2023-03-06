<img src="https://boolerang.co.uk/wp-content/uploads/job-manager-uploads/company_logo/2018/04/SG-Logo-Black.png" alt="Sparta Logo" width="200"/>

---
# Lab - Unit Tests

Implement and unit test a method to manage film certification details: 

Given an age (integer), the method should return a string containing the film classifications a person of that age is allowed to see.

The requirements you have been given are:
1. If someone is **under 12** - U, PG and 12 films are available
2. If someone is under **under 15** - U, PG, 12 and 15 films are available
3. **Over 18** - all films are available

The following method is a partly completed implementation of the requirements:

```csharp
public static string AvailableClassifications(int ageOfViewer)
{
    string result;
    if (ageOfViewer < 12)
    {
        result = "U, PG & 12 films are available.";
    }
    else if (ageOfViewer < 15)
    {
        result = "U, PG, 12 & 15 films are available.";
    }
    else
    {
        result = "All films are available.";
    }
    return result;
}
```
Paste this method into the `Program` class of the *CodeToTest* project you used in the lesson.

Add a new class called `Classification_Tests` to the *UnitTests* project you used in the lesson.  Write unit tests in this class to check the `AvailableClassifications` method fulfils the requirements above.  Run the tests and make sure they pass.

Are the requirements correct and complete? Check the film British Board of Film Classification site https://www.bbfc.co.uk/ and amend the requirements if necessary.

Change the unit tests so that they reflect the amended requirements.  Update the `AvailableClassifications` method so the tests pass.

Consider whether you have enough tests.  What are the partitions?  What are the boundary values?  You don't need to consider ages less that 0 or any upper age limit.

 Write unit tests/test cases to cover all the partitions and boundary values.  You may need to modify the `AvailableClassifications` method code so that all the tests pass.

Commit and push your code into GitHub before the demo session, and be prepared to demonstrate your work.
