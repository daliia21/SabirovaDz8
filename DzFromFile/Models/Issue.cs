using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueStatus = DzFromFile.Enums.IssueStatus;

namespace DzFromFile.Models
{
    class Issue
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Person Initiator { get; set; }
        public Person Executor { get; set; }
        public IssueStatus Status { get; set; }
        public Report Report { get; set; }

        public Issue(string description, DateTime deadline, Person initiator, Person executor)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            Executor = executor;
            Status = IssueStatus.Assigned;
        }

        // взятие задачи в работу
        public void TakeInProgress()
        {
            Status = IssueStatus.InProgress;
            Console.WriteLine($"Задача \"{Description}\" принята в работу исполнителем {Executor}");
        }

        // делегирование задачи другому исполнителю
        public void Delegate(Person newExecutor)
        {
            Executor = newExecutor;
            Status = IssueStatus.Assigned;
            Console.WriteLine($"Задача \"{Description}\" передана исполнителю {Executor}");
        }

        // отклонение задачи
        public void Reject()
        {
            Executor = null;
            Status = IssueStatus.Assigned;
            Console.WriteLine($"Задача \"{Description}\" отклонена");
        }

        // отправка отчета по задаче
        public void SendReport(Report report)
        {
            Report = report;
            Status = IssueStatus.UnderReview;
            Console.WriteLine($"Отчет по задаче \"{Description}\" отправлен");
        }

        // утверждение отчета по задаче
        public void ApproveReport()
        {
            if (Status == IssueStatus.UnderReview)
            {
                Status = IssueStatus.Completed;
                Console.WriteLine($"Отчет по задаче \"{Description}\" утвержден");
            }
            else
            {
                Console.WriteLine($"Отчет по задаче \"{Description}\" не может быть утвержден в текущем статусе");
            }
        }
    }
}
