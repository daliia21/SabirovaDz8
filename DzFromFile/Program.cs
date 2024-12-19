using DzFromFile.Models2;

namespace DzFromFile
{
    internal class Program
    {
        static void Main()
        {
            Task();
        }

        static void Task()
        {
            
            TaskManager manager = new TaskManager();

            // создание команды
            string [] teamNames = new[] { "Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Hannah", "Ian", "Jack" };
            foreach (string name in teamNames)
            {
                manager.AddTeamMember(name);
            }

            // создание проекта
            Project project = new Project("Разработка веб-приложения", new DateTime(2024, 12, 31), "Клиент", "Alice");

            // добавление задач
            for (int i = 0; i < manager.Team.Count; i++)
            {
                Models2.Task task = new Models2.Task($"Task {i + 1} description", new DateTime(2024, 12, 20), "Alice", manager.Team[i].Name);
                project.AddTask(task);
            }

            // перевод проекта в статус "Исполнение"
            project.StartExecution();

            // Исполнители работают над задачами
            foreach (Models2.Task task in project.Tasks)
            {
                task.TakeInProgress();
                var report = new Report($"Report for {task.Description}", DateTime.Now, task.Executor);
                task.SubmitReport(report);
                task.ApproveReport();
            }

            // закрытие проекта
            project.CloseProject();

            project.ShowStatus();
            
        }
    }
}
