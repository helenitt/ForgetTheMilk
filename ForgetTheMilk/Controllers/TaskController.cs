using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace ForgetTheMilk.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult Index()
        {
            return View(Tasks);
        }

        public static readonly List<Task> Tasks = new List<Task>();
            
        [HttpPost]
        public ActionResult Add(string task)
        {
            // For when date not manipulated use following
            //var taskItem = new Task(task, DateTime.Today);
            var date = new DateTime(2015, 5, 31);
            var taskItem = new Task(task, date);
            Tasks.Add(taskItem); 
            return RedirectToAction("Index");
        }
    }

    public class Task
    {
        public Task(string task, DateTime today)
        {
            Description = task;
            var dueDatePattern = new Regex(@"(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\s(\d)");
            var hasDueDate = dueDatePattern.IsMatch(task);
            if (hasDueDate)
            {
                var dueDate = dueDatePattern.Match(task);
                var monthInput = dueDate.Groups[1].Value;
                var month = DateTime.ParseExact(monthInput, "MMM", CultureInfo.CurrentCulture).Month;
                var day = Convert.ToInt32(dueDate.Groups[2].Value);
                DueDate = new DateTime(today.Year, month, day);
                if(DueDate < today)
                {
                    DueDate = DueDate.Value.AddYears(1);
                }
            }

        }

        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}