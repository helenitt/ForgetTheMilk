using ForgetTheMilk.Controllers;
using NUnit.Framework;
using System;

namespace ConsoleVerification
{
    public class CreateTaskTest
    {
        [Test]
        public void DescriptionNoDueDate()
        {
            // Arrange
            var input = "Test Description No Due Date - Walk the Dog";
            var descriptionShouldBe = input;
            DateTime? dueDateShouldBe = null;

            // Act
            var task = new Task(input, default(DateTime));

            // Assert
            var success = descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate;
            var failureMessage = "Description: " + task.Description + " should be " + descriptionShouldBe
                                 + Environment.NewLine
                                 + "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;

            Assert.That(success, failureMessage);            
        }

        [Test]
        public static void TestMayDueDateWrapsYear()
        {
            // Arrange
            var input = "Test Due Date - Day in Past - Holidays May 8 - As of 2015/5/31";
            var today = new DateTime(2015, 5, 31);

            // Act
            var task = new Task(input, today);

            // Assert
            var dueDateShouldBe = new DateTime(2016, 5, 8);
            var success = dueDateShouldBe == task.DueDate;
            var failureMessage = "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;

            Assert.That(success, failureMessage);
        }

        [Test]
        public static void TestMayDueDateDoesNotWrapYear()
        {
            // Arrange
            var input = "Test Due Date - Day in Future - Holidays May 8 - As of 2015/5/4";
            var today = new DateTime(2015, 5, 4);

            // Act
            var task = new Task(input, today);

            // Assert
            var dueDateShouldBe = new DateTime(2015, 5, 8);
            var failureMessage = "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;

            Assert.IsTrue(dueDateShouldBe == task.DueDate, failureMessage);
        }
    }
}
