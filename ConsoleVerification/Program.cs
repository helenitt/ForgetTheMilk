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
            var input = "Walk the Dog";
            Console.WriteLine("Scenario: " + input);
            var task = new Task(input);
            var descriptionShouldBe = input;
            DateTime? dueDateShouldBe = null;
            if(descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate)
            {
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("Description: " + task.Description + " should be " + descriptionShouldBe);
                Console.WriteLine("Due Date: " + task.DueDate + " should be " + dueDateShouldBe);
                Console.WriteLine("ERROR");
            }
            Console.WriteLine();

            input = "Holidays May 8";
            Console.WriteLine("Scenario: " + input);
            task = new Task(input);
            dueDateShouldBe = new DateTime(DateTime.Today.Year, 5, 8);
            if(dueDateShouldBe == task.DueDate)
            {
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("Due Date: " + task.DueDate + " should be " + dueDateShouldBe);
                Console.WriteLine("ERROR");
            }
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
