using DzFromFile.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromFile.Models
{
    class Project
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Person Client { get; set; }
        public Person TeamLead { get; set; }
        public List<Issue> Tasks { get; set; }
        public ProjectStatus Status { get; set; }

        public Project(string description, DateTime deadline, Person client, Person teamLead)
        {
            Description = description;
            Deadline = deadline;
            Client = client;
            TeamLead = teamLead;
            Tasks = new List<Issue>();
            Status = ProjectStatus.Project;
        }

        public void AddTask(Issue task)
        {
            if (Status == ProjectStatus.Project)
            {
                Tasks.Add(task);
                Console.WriteLine($"Задача \"{task.Description}\" успешно добавлена в проект");
            }
            else
            {
                Console.WriteLine("Задачи можно добавлять только в статусе проекта \"Проект\"");
            }
        }

        public void StartExecution()
        {
            if (Tasks.TrueForAll(task => task.Status == IssueStatus.Assigned))
            {
                Status = ProjectStatus.InProgress;
                Console.WriteLine("Проект переведен в статус \"Исполнение\"");
            }
            else
            {
                Console.WriteLine("Не все задачи назначены");
            }
        }

        public void CloseProject()
        {
            if (Tasks.TrueForAll(task => task.Status == IssueStatus.Completed))
            {
                Status = ProjectStatus.Closed;
                Console.WriteLine("Проект закрыт");
            }
            else
            {
                Console.WriteLine("Все задачи должны быть выполнены перед закрытием проекта");
            }
        }
    }
}
