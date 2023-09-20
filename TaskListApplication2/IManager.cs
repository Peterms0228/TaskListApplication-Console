using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListApplication2
{
    interface IManager
    {
        public void addTaskCSV();
        public void viewTaskCSV();
        public void updateTaskCSV();
        public void deleteTaskCSV();
    }
}
