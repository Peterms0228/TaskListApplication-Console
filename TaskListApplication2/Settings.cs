using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListApplication2
{
    class Settings
    {
        public static string dateFormat = "dd/MM/yyyy";
        public static string filePath = "Task List.csv";
        public enum StatusTypes { Pending, Completed };
    }
}
