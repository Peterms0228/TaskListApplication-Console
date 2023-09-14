using System;
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
            Console.WriteLine("Task Added:" + task.name + "\t" + 
                task.dueDate.ToString(dateFormat) + "\t" + task.status);

        }

        static void viewTask()
        {           
            Console.WriteLine("Task List:");
            for (int i = 0; i < taskList.Count; i++)
            {
                int count = i + 1;
                Console.WriteLine(count + ". " + "\t" + 
                    taskList[i].name + "\t" +
                    taskList[i].dueDate.ToString(dateFormat) + "\t" + 
                    taskList[i].status);
            }
        }

        static void updateTask()
        {
            
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
                if (int.TryParse(taskNoStr, out int taskNo))
                {
                    if ( 0 < taskNo && taskNo <= taskList.Count)
                    {
                        int i = taskNo - 1;
                        Console.WriteLine("Task Removed:" + taskList[i].name + "\t" +
                            taskList[i].dueDate.ToString(dateFormat) + "\t" +
                            taskList[i].status);
                        taskList.RemoveAt(i);
                    }
                    else
                    {
                        Console.WriteLine("Task Not Found");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Task No");
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

    }
}
