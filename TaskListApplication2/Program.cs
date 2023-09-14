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
            

            //date checking           
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

            //status = pending while adding
            task.status = Status.Pending;
            taskList.Add(task);
            Console.WriteLine(task.name + "\t" + task.dueDate.ToString(dateFormat) + "\t" + task.status);
            Console.WriteLine("Task Added Successfully");
        }

        static void viewTask()
        {
            
            Console.WriteLine("Task List:");
            for (int i = 0; i < taskList.Count; i++)
            {
                int count = i + 1;
                Console.WriteLine(count + ". " + taskList[i].name + "\t" +
                    taskList[i].dueDate.ToString(dateFormat) + "\t" + 
                    taskList[i].status);
            }
        }

        static void updateTask()
        {

        }

        static void deleteTask()
        {

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
