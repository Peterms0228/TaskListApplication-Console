using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Linq;

namespace TaskListApplication2
{
    class General
    {
        //save data to CSV file
        public static void SaveData<T>(List<T> data, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(data);
            }
        }

        //load data from CSV file
        public static List<T> LoadData<T>(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                //If no found, create new one
                return new List<T>();
            }
        }

        //check is the string null?
        public static bool isStringNull(string str)
        {
            if (str.Length <= 0 || str == null || str.Equals(""))
            {
                return true;
            }
            return false;
        }
        //check is input the number?
        public static bool isInputNumber(string input)
        {
            return int.TryParse(input, out _);
        }

        //color the task row
        public static void displayColor(Status s, String str)
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

        public static void displayTaskList(List<Task> list)
        {
            Console.WriteLine("Task List:");
            for (int i = 0; i < list.Count; i++)
            {
                int no = i + 1;
                displayColor(list[i].Status,
                    no + ". " + "\t" +
                    list[i]);
            }
        }

        public static bool displayTaskListByPath(string filePath)
        {
            List<Task> taskList = new List<Task>();
            try
            {
                taskList = LoadData<Task>(filePath);
            }
            catch (Exception ex) { }

            if (taskList.Count > 0)
            {
                displayTaskList(taskList);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
