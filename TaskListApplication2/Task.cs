using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListApplication2
{
    public enum Status { Pending, Completed }
    class Task
    {
        public string name;
        public DateTime dueDate;
        public Status status;
    }
}
