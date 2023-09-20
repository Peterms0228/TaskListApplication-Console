﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskListApplication2
{
    class TaskManager : General, IManager
    {
        //test only
        public void loadTestData()
        {
            List<Task> taskList = new List<Task>();
            for (int i = 1; i <= 10; i++)
            {
                taskList.Add(new Task("Task " + i, DateTime.Now.AddDays(i)));

                SaveData(taskList, Task.filePath);
            }
        }
        //test only

        public void addTaskCSV()
        {
            List<Task> taskList = new List<Task>();
            try
            {
                taskList = LoadData<Task>(Task.filePath);
            }
            catch (Exception ex) { }

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
            displayColor(task.Status, task.ToString());

            SaveData<Task>(taskList, Task.filePath);
        }
        public void viewTaskCSV()
        {
            if (displayTaskListByPath(Task.filePath))
            {
                List<Task> taskList = LoadData<Task>(Task.filePath);
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
                            sortedTaskList = taskList.OrderBy(task => task.DueDate).ToList();
                            displayTaskList(sortedTaskList);
                            break;
                        case "2":
                            sortedTaskList = taskList.OrderByDescending(task => task.DueDate).ToList();
                            displayTaskList(sortedTaskList);
                            break;
                        case "3":
                            sortedTaskList = taskList.Where(task => task.Status == StatusTypes.Completed).ToList();
                            displayTaskList(sortedTaskList);
                            break;
                        case "4":
                            sortedTaskList = taskList.Where(task => task.Status == StatusTypes.Pending).ToList();
                            displayTaskList(sortedTaskList);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No Records");
            }
        }
        public void updateTaskCSV()
        {
            if (displayTaskListByPath(Task.filePath))
            {
                List<Task> taskList = LoadData<Task>(Task.filePath);
                string taskNoStr = "";
                do
                {
                    Console.WriteLine("Enter Task No to marked \"Completed\"; q to Quit:");
                    taskNoStr = Console.ReadLine();
                    if (isInputNumber(taskNoStr))
                    {
                        int taskNo = int.Parse(taskNoStr);
                        if (taskNo > 0 && taskNo <= taskList.Count)
                        {
                            int i = taskNo - 1;
                            Console.WriteLine("Task Updated: ");
                            taskList[i].Status = StatusTypes.Completed;
                            displayColor(taskList[i].Status, taskList[i].ToString());
                            SaveData<Task>(taskList, Task.filePath);
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
                } while (!taskNoStr.Equals("q"));
            }
            else
            {
                Console.WriteLine("No Records");
            }
        }
        public void deleteTaskCSV()
        {
            if (displayTaskListByPath(Task.filePath))
            {
                List<Task> taskList = LoadData<Task>(Task.filePath);
                string taskNoStr = "";
                do
                {
                    Console.WriteLine("Enter Task No to delete; q to Quit:");
                    taskNoStr = Console.ReadLine();

                    if (isInputNumber(taskNoStr))
                    {
                        int taskNo = int.Parse(taskNoStr);
                        if (taskNo > 0 && taskNo <= taskList.Count)
                        {
                            int i = taskNo - 1;
                            Console.WriteLine("Task Removed: ");
                            displayColor(taskList[i].Status, taskList[i].ToString());
                            taskList.RemoveAt(i);
                            SaveData<Task>(taskList, Task.filePath);
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
                } while (!taskNoStr.Equals("q"));
            }
            else
            {
                Console.WriteLine("No Records");
            }
        }
    }
}
