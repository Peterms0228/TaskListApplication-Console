using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListApplication2
{
    class TaskCompleted : Task
    {
        public override void displayBgColor(string contents)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(contents);
            Console.ResetColor();
        }
    }
}
