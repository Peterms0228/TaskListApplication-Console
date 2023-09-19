using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Linq;

namespace TaskListApplication2
{
    class CSVData
    {
        //save data to CSV file
        public void SaveData<T>(List<T> data, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(data);
            }
        }

        //load data from CSV file
        public List<T> LoadData<T>(string filePath)
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
                // Handle exceptions or propagate them as needed
                Console.WriteLine($"Error loading data from CSV: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
