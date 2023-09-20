using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListApplication2
{
    public enum Status { Pending, Completed }

    class Task : CSVManager
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

        public override string ToString()
        {
            return this.name + "\t" +
                this.dueDate.ToString(dateFormat) + "\t" +
                this.status;
        }
        /*
        public void SaveData(List<Task> data, string filePath)
        {
            SaveData<Task>(data, filePath);
        }
        public List<Task> LoadData(string filePath)
        {
            return LoadData<Task>(filePath);
        }*/
    }
}
