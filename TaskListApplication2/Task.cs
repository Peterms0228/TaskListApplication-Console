using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListApplication2
{
    class Task : General
    {
        private string name;
        private DateTime dueDate;
        private StatusTypes status;

        //Constructor
        public Task(){
            this.status = StatusTypes.Pending;
        }
        public Task(string name, DateTime dueDate)
        {
            this.name = name;
            this.dueDate = dueDate;
            this.status = StatusTypes.Pending;
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

        public StatusTypes Status
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
        public void SaveData(List<Task> data, string filePath)
        {
            SaveData<Task>(data, filePath);
        }
        public List<Task> LoadData(string filePath)
        {
            return LoadData<Task>(filePath);
        }
    }
}
