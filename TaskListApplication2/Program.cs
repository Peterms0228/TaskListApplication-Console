using System;
using System.Collections.Generic;


namespace TaskListApplication2
{
    class Program : TaskManager
    {
        //Temporary Memory
        public static List<Task> taskList = new List<Task>();

        static void Main(string[] args)
        {
            //test Data
            for (int i = 1; i <= 10; i++) { 
                taskList.Add(new Task("Task " + i, DateTime.Now));
            }
          
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
                        taskList = addTask(taskList);
                        break;
                    case "2":
                        if (taskList.Count == 0)
                            Console.WriteLine("No Task Yet");
                        else
                            viewTask(taskList);
                        break;
                    case "3":
                        if (taskList.Count == 0)
                            Console.WriteLine("No Task Yet");
                        else
                            taskList = updateTask(taskList);
                        break;
                    case "4":
                        if (taskList.Count == 0)
                            Console.WriteLine("No Task Yet");
                        else
                            taskList = deleteTask(taskList);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
