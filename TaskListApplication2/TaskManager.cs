using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TaskListApplication2
{
    class TaskManager : Manager
    {
        public static List<Task> addTask(List<Task> taskList)
        {
            Task task = new Task();

            //check null
            do
            {
                Console.WriteLine("Enter Task Name:");
                task.Name = Console.ReadLine();
                if (isStringNull(task.Name))
                {
                    Console.WriteLine("Task Name cannot be empty");
                }
            } while (isStringNull(task.Name));

            //check date format         
            bool isValidDate = false;
            do
            {
                Console.WriteLine("Enter Due Date (dd/mm/yyyy):");
                String inputDate = Console.ReadLine();
                if (DateTime.TryParseExact(inputDate, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    isValidDate = true;
                    task.DueDate = parsedDate;
                }
                else
                {
                    Console.WriteLine("Invalid Date format");
                }
            } while (!isValidDate);

            
            taskList.Add(task);
            Console.WriteLine("Task Added:");
            displayColor(task.Status,
                task.Name + "\t" +
                task.DueDate.ToString(dateFormat) + "\t" +
                task.Status);

            return taskList;
        }

        public static void viewTask(List<Task> taskList)
        {
            string option = "";
            displayTaskList(taskList);
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
                        sortedTaskList = taskList.OrderBy(task => task.DueDate).ToList();
                        displayTaskList(sortedTaskList);
                        break;
                    case "2":
                        sortedTaskList = taskList.OrderByDescending(task => task.DueDate).ToList();
                        displayTaskList(sortedTaskList);
                        break;
                    case "3":
                        sortedTaskList = taskList.Where(task => task.Status == Status.Completed).ToList();
                        displayTaskList(sortedTaskList);
                        break;
                    case "4":
                        sortedTaskList = taskList.Where(task => task.Status == Status.Pending).ToList();
                        displayTaskList(sortedTaskList);
                        break;
                    default:
                        break;
                }
            }
        }

        public static List<Task> updateTask(List<Task> taskList)
        {
            displayTaskList(taskList);
            Console.WriteLine("Enter Task No to marked \"Completed\"; q to Quit:");
            string taskNoStr = Console.ReadLine();
            if (!taskNoStr.Equals("q"))
            {
                if (isInputNumber(taskNoStr))
                {
                    int taskNo = int.Parse(taskNoStr);
                    if(taskNo > 0 && taskNo <= taskList.Count)
                    {
                        int i = taskNo - 1;
                        Console.WriteLine("Task Updated: ");
                        taskList[i].Status = Status.Completed;
                        displayColor(taskList[i].Status,
                            taskList[i].Name + "\t" +
                            taskList[i].DueDate.ToString(dateFormat) + "\t" +
                            taskList[i].Status);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Task No");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Task No");
                }
            }
            return taskList;
        }

        public static List<Task> deleteTask(List<Task> taskList)
        {
            displayTaskList(taskList);
            Console.WriteLine("Enter Task No to delete; q to Quit:");
            string taskNoStr = Console.ReadLine();
            if (!taskNoStr.Equals("q"))
            {
                if (isInputNumber(taskNoStr))
                {
                    int taskNo = int.Parse(taskNoStr);
                    if (taskNo > 0 && taskNo <= taskList.Count)
                    {
                        int i = taskNo - 1;
                        Console.WriteLine("Task Removed: ");
                        displayColor(taskList[i].Status,
                            taskList[i].Name + "\t" +
                            taskList[i].DueDate.ToString(dateFormat) + "\t" +
                            taskList[i].Status);
                        taskList.RemoveAt(i);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Task No");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Task No");
                }
            }
            return taskList;
        }
    }
}
