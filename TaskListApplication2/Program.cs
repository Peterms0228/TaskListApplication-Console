using System;
using System.Collections.Generic;


namespace TaskListApplication2
{
    class Program
    {
        public static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            TaskCSVManager taskCSVManager = new TaskCSVManager();

            //test only
            taskCSVManager.loadTestData();
            //test only

            string option = "";
            while(option != "q")
            {
                Console.WriteLine("");
                Console.WriteLine("Simple Task List Application - Yokogawa");
                Console.WriteLine("Enter 1 to Add Task");
                Console.WriteLine("Enter 2 to View Tasks");
                Console.WriteLine("Enter 3 to Update Task");
                Console.WriteLine("Enter 4 to Delete Task");
                Console.WriteLine("Enter q to Quit -->");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        taskCSVManager.addTaskCSV();
                        break;
                    case "2":
                        taskCSVManager.viewTaskCSV();
                        break;
                    case "3":
                        taskCSVManager.updateTaskCSV();
                        break;
                    case "4":
                        taskCSVManager.deleteTaskCSV();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
