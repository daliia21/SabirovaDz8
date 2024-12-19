using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = DzFromFile.Enums.TaskStatus;

namespace DzFromFile.Models2
{
    class Task
    {
        public string description;
        private DateTime deadline;
        private string client;
        public string executor;
        public TaskStatus status;
        private Report report;

        public Task(string description, DateTime deadline, string client, string executor)
        {
            this.description = description;
            this.deadline = deadline;
            this.client = client;
            this.executor = executor;
            status = TaskStatus.Assigned;
        }

        // взятие задачи в работу
        public void TakeInProgress()
        {
            status = TaskStatus.InProgress;
        }

        // делегирование задачи другому исполнителю
        public void Delegate(string newExecutor)
        {
            executor = newExecutor;
            status = TaskStatus.Assigned;
        }

        // отклонение задачи
        public void Reject()
        {
            executor = null;
            status = TaskStatus.Assigned;
        }

        // отправка отчета по задаче
        public void SendReport(Report report)
        {
            this.report = report;
            status = TaskStatus.UnderReview;
        }

        // утверждение отчета по задаче
        public void ApproveReport()
        {
            if (status == TaskStatus.UnderReview)
            {
                status = TaskStatus.Completed;
            }
        }
    }
}
