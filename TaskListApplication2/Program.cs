﻿using System;
using System.Collections.Generic;

namespace TaskListApplication2
{
    class Program
    {
        //Temporary Memory
        static List<Task> taskList = new List<Task>();
        static string dateFormat = "dd/MM/yyyy";
        static void Main(string[] args)
        {
            string option = "";
            while(option != "q")
            {
                Console.WriteLine("");
                Console.WriteLine("Simple Task List Application - Yokogawa");
                Console.WriteLine("Enter 1 to Add Task");
                Console.WriteLine("Enter 2 to View Tasks");
                Console.WriteLine("Enter 3 to Update Task");
                Console.WriteLine("Enter 4 to Delete Task");
                Console.WriteLine("Enter q to Exit -->");

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
            Task task = new Task();

            task.status = Status.Pending;

            //check null
            Console.WriteLine("Enter Task Name:");
            do
            {
                task.name = Console.ReadLine();
                if (isStringNull(task.name))
                {
                    Console.WriteLine("Task Name cannot be empty");
                    Console.WriteLine("Please enter again:");
                }
            } while (isStringNull(task.name));
            
            //check date format         
            bool isValidDate = false;
            do
            {
                Console.WriteLine("Enter Due Date (dd/mm/yyyy) or \"t\" for Today:");
                String inputDate = Console.ReadLine();
                if (DateTime.TryParseExact(inputDate, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    isValidDate = true;
                    task.dueDate = parsedDate;
                } else if (inputDate.Equals("t"))
                {
                    isValidDate = true;
                    task.dueDate = DateTime.Now;
                }
                else
                {
                    Console.WriteLine("Invalid Date format");
                }
            } while (!isValidDate);

            taskList.Add(task);

            displayColor(task.status,
                "Task Added:" + task.name + "\t" +
                task.dueDate.ToString(dateFormat) + "\t" + 
                task.status);

        }

        static void viewTask()
        {           
            Console.WriteLine("Task List:");
            for (int i = 0; i < taskList.Count; i++)
            {
                int count = i + 1;

                if (taskList[i].status == Status.Pending)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else if(taskList[i].status == Status.Completed)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }

                displayColor(taskList[i].status,
                    count + ". " + "\t" +
                    taskList[i].name + "\t" +
                    taskList[i].dueDate.ToString(dateFormat) + "\t" +
                    taskList[i].status);
            }
        }

        static void updateTask()
        {
            if (taskList.Count == 0)
            {
                Console.WriteLine("No Task Yet");
            }
            else
            {
                viewTask();
                Console.WriteLine("Enter Task No to marked \"Completed\":");
                string taskNoStr = Console.ReadLine();
                int taskNo = isTaskNoValid(taskNoStr);
                if (taskNo == 0)
                {
                    Console.WriteLine("Task Not Found");
                }
                else
                {
                    int i = taskNo - 1;
                    taskList[i].status = Status.Completed;
                    
                    displayColor(taskList[i].status,
                        "Task Updated:" + taskList[i].name + "\t" +
                        taskList[i].dueDate.ToString(dateFormat) + "\t" +
                        taskList[i].status);
                }
            }

        }

        static void deleteTask()
        {
            if(taskList.Count == 0)
            {
                Console.WriteLine("No Task Yet");
            }
            else
            {
                viewTask();
                Console.WriteLine("Enter Task No to delete:");
                string taskNoStr = Console.ReadLine();
                int taskNo = isTaskNoValid(taskNoStr);
                if (taskNo == 0)
                {
                    Console.WriteLine("Task Not Found");
                }
                else
                {
                    int i = taskNo - 1;
                    displayColor(taskList[i].status, 
                        "Task Removed:" + taskList[i].name + "\t" +
                        taskList[i].dueDate.ToString(dateFormat) + "\t" +
                        taskList[i].status);
                    taskList.RemoveAt(i);
                }
            }
        }
        static Boolean isStringNull(string str)
        {
            if (str.Length <= 0 || str == null || str.Equals(""))
            {
                return true;
            }
            return false;
        }

        static int isTaskNoValid(string taskNoStr)
        {
            if (int.TryParse(taskNoStr, out int taskNo))
            {
                if (0 < taskNo && taskNo <= taskList.Count)
                {
                    return taskNo;
                }
            }
            return 0;
        }

        static void displayColor(Status s, String str)
        {
            if (s.Equals(Status.Pending))
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else if (s.Equals(Status.Completed))
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(str);
            Console.ResetColor();
        }

    }
}
