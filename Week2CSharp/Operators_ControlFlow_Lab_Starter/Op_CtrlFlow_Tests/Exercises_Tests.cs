using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using Op_CtrlFlow;
using System;
using System.Collections.Generic;

namespace Op_CtrlFlow_Tests
{
    public class Exercises_Tests
    {
        // write unit test(s) for MyMethod here
        [TestCase(1, 1,true)]
        [TestCase(2, 1,true)]
        [TestCase(3, 2,false)]
        [TestCase(10, 5,true)]
        public void MyMethod_Test_FunctionWithMultipleValues(int num1, int num2, bool expected)
        {
            bool result = Exercises.MyMethod(num1, num2);
            Assert.That(result, Is.EqualTo(Exercises.MyMethod(num1, num2)));
        }

        [Test]
        public void Average_ReturnsCorrectAverage()
        {
            var myList = new List<int>() { 3, 8, 1, 7, 3 };
            Assert.That(Exercises.Average(myList), Is.EqualTo(4.4));
        }
        
        public void CheckListIsEmpty()
        {
            var myList = new List<int>();
            Assert.That(() => Exercises.Average(myList), Throws.TypeOf<ArgumentNullException>().With.Message.Contain(myList + " is an empty list, please use a populated list"));
        }

        [TestCase(100, "OAP")]
        [TestCase(60, "OAP")]
        [TestCase(59, "Standard")]
        [TestCase(18, "Standard")]
        [TestCase(17, "Student")]
        [TestCase(13, "Student")]
        [TestCase(12, "Child")]
        [TestCase(5, "Child")]
        [TestCase(4, "Free")]
        [TestCase(0, "Free")]
        public void TicketTypeTest(int age, string expected)
        {
            var result = Exercises.TicketType(age);
            Assert.That(result, Is.EqualTo(expected));
        }
        [TestCase(-1)]
        [TestCase(116)]
        public void Exercise_OutOfRange_TicketTypeTest(int age)
        {
            Assert.That(()=>Exercises.TicketType(age), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain(age + " is not a valid age, please add a valid age (between 0 - 115"));
        }

        [TestCase(75, "Pass with Distinction")]
        [TestCase(100, "Pass with Distinction")]

        [TestCase(60, "Pass with Merit")]
        [TestCase(74, "Pass with Merit")]

        [TestCase(59, "Pass")]
        [TestCase(40, "Pass")]

        [TestCase(0, "Fail")]
        [TestCase(39, "Fail")]
        public void Testing_Exercises_Grade_WithMultipleValues(int mark, string expected)
        {
            var result = Exercises.Grade(mark);
            Assert.That(result, Is.EqualTo(expected));
        }
        [TestCase(-1)]
        [TestCase(101)]
        public void Testing_Grade_WithOutOfRangeValues(int mark)
        {
            Assert.That(() => Exercises.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain(mark + " is not a valid input, please add marks between 0 - 100"));
        }

        [TestCase(0, 200)]
        [TestCase(1, 100)]
        [TestCase(2, 50)]
        [TestCase(3, 50)]
        [TestCase(4, 20)]
        public void Testing_Exercises_GetScottishMaxWeddingNumbers_WithMultipleValues(int covidLevel, int expected)
        {
            var result = Exercises.GetScottishMaxWeddingNumbers(covidLevel);
            Assert.That(result, Is.EqualTo(expected));
        }
        [TestCase(-1)]
        [TestCase(5)]
        public void GivenOutOfBoundsInformation_ThrowException(int covidLevel)
        {
            Assert.That(() => Exercises.GetScottishMaxWeddingNumbers(covidLevel), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain(covidLevel + " is not a valid covid level. The covid levels are 0-4, please use the appropiate level"));
        }
    }
}
