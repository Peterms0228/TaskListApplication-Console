using System;
using System.Collections.Generic;

namespace TaskListApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Task List Application - Yokogawa");

            //Temporary Memory
            List<Task> taskList = new List<Task>();
            string option = "";

            while(option != "q")
            {
                Console.WriteLine("Enter 1 to Add Task");
                Console.WriteLine("Enter 2 to View Tasks");
                Console.WriteLine("Enter 3 to Update Task");
                Console.WriteLine("Enter 4 to Delete Task");
                Console.WriteLine("Enter q to Exit");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        addTask();
                        break;
                    case "2":
                        viewTask();
                        break;
                    case "3":
                        updateTask();
                        break;
                    case "4":
                        deleteTask();
                        break;
                    default:
                        break;
                }
            }
                
            
        }

        static void addTask()
        {

        }

        static void viewTask()
        {

        }

        static void updateTask()
        {

        }

        static void deleteTask()
        {

        }
    }
}
