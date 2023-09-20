using System;
using System.Collections.Generic;


namespace TaskListApplication2
{
    class Program
    {
        public static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            //TaskCSVManager taskCSVManager = new TaskCSVManager();

            //test only
            taskManager.loadTestData();
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
                        taskManager.addTaskCSV();
                        break;
                    case "2":
                        taskManager.viewTaskCSV();
                        break;
                    case "3":
                        taskManager.updateTaskCSV();
                        break;
                    case "4":
                        taskManager.deleteTaskCSV();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
