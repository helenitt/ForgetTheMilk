using ForgetTheMilk.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDescriptionNoDueDate();
            TestMayDueDate();

            Console.ReadLine();
        }

        private static void TestDescriptionNoDueDate()
        {
            var input = "Walk the Dog";
            Console.WriteLine("Scenario: " + input);
            var task = new Task(input);
            var descriptionShouldBe = input;
            DateTime? dueDateShouldBe = null;
            var success = descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate;
            var failureMessage = "Description: " + task.Description + " should be " + descriptionShouldBe
                                 + Environment.NewLine
                                 + "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;
            PrintOutcome(success, failureMessage);
        }

        private static void TestMayDueDate()
        {
            var input = "Holidays May 8";
            Console.WriteLine("Scenario: " + input);
            var task = new Task(input);
            var dueDateShouldBe = new DateTime(DateTime.Today.Year, 5, 8);
            var success = dueDateShouldBe == task.DueDate;
            var failureMessage = "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;

            PrintOutcome(success, failureMessage);
        }

        private static void PrintOutcome(bool success, string failureMessage)
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
