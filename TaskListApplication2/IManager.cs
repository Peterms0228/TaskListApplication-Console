using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListApplication2
{
    interface IManager
    {
        public void addTask();
        public void viewTask();
        public void updateTask();
        public void deleteTask();
    }
}
