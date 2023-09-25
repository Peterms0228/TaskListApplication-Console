using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListApplication2
{
    class TaskPending : Task
    {
        public override void displayBgColor(string contents)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(contents);
            Console.ResetColor();
        }
    }
}
