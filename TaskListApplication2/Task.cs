using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListApplication2
{
    public enum Status { Pending, Completed }

    class Task
    {
        private string name;
        private DateTime dueDate;
        private Status status;

        //Constructor
        public Task(){
            this.status = Status.Pending;
        }
        public Task(string name, DateTime dueDate)
        {
            this.name = name;
            this.dueDate = dueDate;
            this.status = Status.Pending;
        }

        //Getter & Setter
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public Status Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
