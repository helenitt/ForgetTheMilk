﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Add a task: ");
                var input = Console.ReadLine();
                var task = new Task(input);
                Console.WriteLine(task.Description);
                Console.WriteLine(task.DueDate);
                Console.WriteLine();
            }
        }
    }
}