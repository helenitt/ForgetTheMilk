using ForgetTheMilk.Controllers;
using System;

namespace ConsoleVerification
{
    // This class is no longer needed once you have NUnit Tests 
    // should be changed from console app to class library
    class Program
    {
        static void Main(string[] args)
        {
            TestDescriptionNoDueDate();
            TestMayDueDateWrapsYear();
            TestMayDueDateDoesNotWrapYear();

            Console.ReadLine();
        }

        // Extracted to NUnit TaskTest
        public static void TestDescriptionNoDueDate()
        {
            // Arrange
            var input = "Test Description No Due Date - Walk the Dog";
            Console.WriteLine("Scenario: " + input);

            // Act
            var task = new Task(input, default(DateTime));

            // Assert
            var descriptionShouldBe = input;
            DateTime? dueDateShouldBe = null;
            var success = descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate;
            var failureMessage = "Description: " + task.Description + " should be " + descriptionShouldBe
                                 + Environment.NewLine
                                 + "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;
            PrintOutcome(success, failureMessage);
        }

        private static void TestMayDueDateWrapsYear()
        {
            // Arrange
            var input = "Test Due Date - Day in Past - Holidays May 8 - As of 2015/5/31";
            Console.WriteLine("Scenario: " + input);
            var today = new DateTime(2015, 5, 31);

            // Act
            var task = new Task(input, today);

            // Assert
            var dueDateShouldBe = new DateTime(2016, 5, 8);
            var success = dueDateShouldBe == task.DueDate;
            var failureMessage = "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;

            PrintOutcome(success, failureMessage);
        }

        private static void TestMayDueDateDoesNotWrapYear()
        {
            // Arrange
            var input = "Test Due Date - Day in Future - Holidays May 8 - As of 2015/5/4";
            Console.WriteLine("Scenario: " + input);
            var today = new DateTime(2015, 5, 4);

            // Act
            var task = new Task(input, today);

            // Assert
            var dueDateShouldBe = new DateTime(2015, 5, 8);
            var success = dueDateShouldBe == task.DueDate;
            var failureMessage = "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;

            PrintOutcome(success, failureMessage);
        }

        public static void PrintOutcome(bool success, string failureMessage)
        {
            if (success)
            {
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("ERROR: ");
                Console.WriteLine(failureMessage);
            }
            Console.WriteLine();
        }
    }
}
