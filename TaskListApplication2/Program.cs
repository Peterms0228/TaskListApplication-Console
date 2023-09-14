using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine("Enter q to Quit -->");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        addTask();
                        break;
                    case "2":
                        if (taskList.Count == 0)
                            Console.WriteLine("No Task Yet");
                        else
                            viewTask();
                        break;
                    case "3":
                        if (taskList.Count == 0)
                            Console.WriteLine("No Task Yet");
                        else
                            updateTask();
                        break;
                    case "4":
                        if (taskList.Count == 0)
                            Console.WriteLine("No Task Yet");
                        else
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
            string option = "";
            while (option != "q")
            {
                Console.WriteLine("Enter 1 to Sorted by Due Date (Ascending)");
                Console.WriteLine("Enter 2 to Sorted by Due Date (Descending)");
                Console.WriteLine("Enter 3 to \"Completed\" Task");
                Console.WriteLine("Enter 4 to \"Pending\" Task");
                Console.WriteLine("Enter q to Quit -->");

                option = Console.ReadLine();
                List<Task> sortedTaskList = new List<Task>();
                switch (option)
                {
                    case "1":
                        sortedTaskList = taskList.OrderBy(task => task.dueDate).ToList();
                        displayTaskList(sortedTaskList);
                        break;
                    case "2":
                        sortedTaskList = taskList.OrderByDescending(task => task.dueDate).ToList();
                        displayTaskList(sortedTaskList);
                        break;
                    case "3":
                        sortedTaskList = taskList.Where(task => task.status == Status.Completed).ToList();
                        displayTaskList(sortedTaskList);
                        break;
                    case "4":
                        sortedTaskList = taskList.Where(task => task.status == Status.Pending).ToList();
                        displayTaskList(sortedTaskList);
                        break;
                    default:
                        break;
                }
            }
        }

        static void updateTask()
        {
            displayTaskList(taskList);
            Console.WriteLine("Enter Task No to marked \"Completed\"; q to Quit:");
            string taskNoStr = Console.ReadLine();
            if (!taskNoStr.Equals("q"))
            {
                int taskNo = isTaskNoValid(taskNoStr);
                if (taskNo < 0)
                {
                    Console.WriteLine("Task Not Found");
                }
                else
                {
                    taskList[taskNo].status = Status.Completed;
                    displayColor(taskList[taskNo].status,
                        "Task Updated:" + taskList[taskNo].name + "\t" +
                        taskList[taskNo].dueDate.ToString(dateFormat) + "\t" +
                        taskList[taskNo].status);
                }
            }
        }

        static void deleteTask()
        {
            displayTaskList(taskList);
            Console.WriteLine("Enter Task No to delete; q to Quit::");
            string taskNoStr = Console.ReadLine();
            if (!taskNoStr.Equals("q"))
            {
                int taskNo = isTaskNoValid(taskNoStr);
                if (taskNo < 0)
                {
                    Console.WriteLine("Task Not Found");
                }
                else
                {
                    displayColor(taskList[taskNo].status,
                        "Task Removed:" + taskList[taskNo].name + "\t" +
                        taskList[taskNo].dueDate.ToString(dateFormat) + "\t" +
                        taskList[taskNo].status);
                    taskList.RemoveAt(taskNo);
                }
            }
        }
        static Boolean isStringNull(string str)//check if string null
        {
            if (str.Length <= 0 || str == null || str.Equals(""))
            {
                return true;
            }
            return false;
        }
        //check is the task inside task list
        //0 = Invalid; else Valid
        static int isTaskNoValid(string taskNoStr)
        {
            if (int.TryParse(taskNoStr, out int taskNo))
            {
                if (0 < taskNo && taskNo <= taskList.Count)
                {
                    return taskNo - 1;
                }
            }
            return -1;
        }

        static void displayColor(Status s, String str)//color the task row
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
        static void displayTaskList(List<Task> list) //display list by for-loop
        {
            Console.WriteLine("Task List:");
            for (int i = 0; i < list.Count; i++)
            {
                int no = i + 1;
                displayColor(list[i].status,
                    no + ". " + "\t" +
                    list[i].name + "\t" +
                    list[i].dueDate.ToString(dateFormat) + "\t" +
                    list[i].status);
            }
        }

    }
}
