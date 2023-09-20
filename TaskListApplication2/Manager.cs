using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListApplication2
{
    class Manager : Settings
    {
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

        //display list by for-loop
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
    }
}
