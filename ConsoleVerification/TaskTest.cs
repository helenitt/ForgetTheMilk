using ForgetTheMilk.Controllers;
using NUnit.Framework;
using System;

namespace ConsoleVerification
{
    public class CreateTaskTest : AssertionHelper
    {
        [Test]
        public void DescriptionNoDueDate()
        {
            // Arrange
            var input = "Test Description No Due Date - Walk the Dog";

            // Act
            var task = new Task(input, default(DateTime));

            // Assert
            Assert.AreEqual(input, task.Description);
            Assert.AreEqual(null, task.DueDate);
            // Can use this one when you inherit from AssertionHelper
            Expect(task.Description, Is.EqualTo(input));
        }

        [Test]
        public void MayDueDateWrapsYear()
        {
            // Arrange
            var input = "Test Due Date - Day in Past - Holidays May 8 - As of 2015/5/31";
            var today = new DateTime(2015, 5, 31);

            // Act
            var task = new Task(input, today);

            // Assert
            Expect(task.DueDate, Is.EqualTo(new DateTime(2016, 5, 8)));
        }

        [Test]
        public void MayDueDateDoesNotWrapYear()
        {
            // Arrange
            var input = "Test Due Date - Day in Future - Holidays May 8 - As of 2015/5/4";
            var today = new DateTime(2015, 5, 4);

            // Act
            var task = new Task(input, today);

            // Assert
            Expect(task.DueDate, Is.EqualTo(new DateTime(2015, 5, 8)));
        }

        [Test]
        [TestCase("Shop Jan 8", 1)]
        [TestCase("Shop Feb 8", 2)]
        [TestCase("Shop Mar 8", 3)]
        [TestCase("Shop Apr 8", 4)]
        [TestCase("Shop May 8", 5)]
        [TestCase("Shop Jun 8", 6)]
        [TestCase("Shop Jul 8", 7)]
        [TestCase("Shop Aug 8", 8)]
        [TestCase("Shop Sep 8", 9)]
        [TestCase("Shop Oct 8", 10)]
        [TestCase("Shop Nov 8", 11)]
        [TestCase("Shop Dec 8", 12)]
        public void DueDate(string input, int expectedMonth)
        {
            // Arrange
            var today = new DateTime(2015, 5, 31);

            // Act
            var task = new Task(input, today);

            // Assert
            Expect(task.DueDate, Is.Not.Null);
            Expect(task.DueDate.Value.Month, Is.EqualTo(expectedMonth));
        }
    }
}
