using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromFile.Models2
{
    class Task
    {
        // Возможные статусы задачи
        public const string STATUS_ASSIGNED = "Назначена";
        public const string STATUS_IN_PROGRESS = "В работе";
        public const string STATUS_UNDER_REVIEW = "На проверке";
        public const string STATUS_COMPLETED = "Выполнена";

        private string description;
        private DateTime deadline;
        private string initiator;
        private string executor;
        public string status;
        private Report report;

        public Task(string description, DateTime deadline, string initiator, string executor)
        {
            this.description = description;
            this.deadline = deadline;
            this.initiator = initiator;
            this.executor = executor;
            status = STATUS_ASSIGNED;
        }

        // Взять задачу в работу
        public void TakeInProgress()
        {
            status = STATUS_IN_PROGRESS;
        }

        // Делегировать задачу другому исполнителю
        public void Delegate(string newExecutor)
        {
            executor = newExecutor;
            status = STATUS_ASSIGNED;
        }

        // Отклонить задачу
        public void Reject()
        {
            executor = null;
            status = STATUS_ASSIGNED;
        }

        // Отправить отчет по задаче
        public void SubmitReport(Report report)
        {
            this.report = report;
            status = STATUS_UNDER_REVIEW;
        }

        // Утвердить отчет по задаче
        public void ApproveReport()
        {
            if (status == STATUS_UNDER_REVIEW)
            {
                status = STATUS_COMPLETED;
            }
        }
    }
}
