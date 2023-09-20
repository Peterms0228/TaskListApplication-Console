using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Linq;

namespace TaskListApplication2
{
    class CSVManager : Manager
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
        public static bool displayTaskCSVList(string filePath)
        {
            List<Task> taskList = new List<Task>();
            try
            {
                taskList = LoadData<Task>(filePath);
            }
            catch (Exception ex) { }

            if (taskList.Count > 0)
            {
                Console.WriteLine("Task List:");
                for (int i = 0; i < taskList.Count; i++)
                {
                    int no = i + 1;
                    displayColor(taskList[i].Status,
                        no + ". " + "\t" +
                        taskList[i]);
                }
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
