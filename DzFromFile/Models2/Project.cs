using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromFile.Models2
{
    class Project
    {
        public const string STATUS_PROJECT = "Проект";
        public const string STATUS_IN_PROGRESS = "Исполнение";
        public const string STATUS_CLOSED = "Закрыт";

        private string description;
        private DateTime deadline;
        private string client;
        private string teamLead;
        public List<Task> Tasks;
        private string Status;

        public Project(string description, DateTime deadline, string client, string teamLead)
        {
            this.description = description;
            this.deadline = deadline;
            this.client = client;
            this.teamLead = teamLead;
            Tasks = new List<Task>();
            Status = STATUS_PROJECT;
        }

        public void AddTask(Task task)
        {
            if (Status == STATUS_PROJECT)
            {
                Tasks.Add(task);
            }
            else
            {
                throw new Exception("Не удается добавить задачи в проект, который не имеет статуса \"Проект\".");
            }
        }

        public void StartExecution()
        {
            if (Tasks.TrueForAll(task => task.status == Task.STATUS_ASSIGNED))
            {
                Status = STATUS_IN_PROGRESS;
            }
            else
            {
                throw new Exception("Все задачи должны быть назначены перед началом выполнения.");
            }
        }

        public void CloseProject()
        {
            if (Tasks.TrueForAll(task => task.status == Task.STATUS_COMPLETED))
            {
                Status = STATUS_CLOSED;
            }
            else
            {
                throw new Exception("Все задачи должны быть выполнены до закрытия проекта.");
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Project status: {Status}");
        }
    }
}
