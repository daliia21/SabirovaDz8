using DzFromFile.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromFile.Models2
{
    class Project
    {    
        private string description;
        private DateTime deadline;
        private string client;
        private string teamLead;
        public List<Task> Tasks;
        private ProjectStatus status;

        public Project(string description, DateTime deadline, string client, string teamLead)
        {
            this.description = description;
            this.deadline = deadline;
            this.client = client;
            this.teamLead = teamLead;
            Tasks = new List<Task>();
            status = ProjectStatus.Project;
        }

        public void AddTask(Task task)
        {
            if (status == ProjectStatus.Project)
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
            if (Tasks.TrueForAll(task => task.status == Enums.TaskStatus.Assigned))
            {
                status = ProjectStatus.InProgress;
            }
            else
            {
                throw new Exception("Все задачи должны быть назначены перед началом выполнения.");
            }
        }

        public void CloseProject()
        {
            if (Tasks.TrueForAll(task => task.status == Enums.TaskStatus.Completed))
            {
                status = ProjectStatus.Closed;
            }
            else
            {
                throw new Exception("Все задачи должны быть выполнены до закрытия проекта.");
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Project status: {status}");
        }
    }
}
