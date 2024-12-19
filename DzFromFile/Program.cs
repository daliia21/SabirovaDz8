using DzFromFile.Models;


namespace DzFromFile
{
    internal class Program
    {

        static void Main()
        {
            List<Person> team = new List<Person>
            {
                new Person("Рамиля Гарифуллина", "Тимлид"),
                new Person("Гульчачаак Гараева", "Дизайнер"),
                new Person("Рамзия Шайхлисламова", "Бэкенд-разработчик"),
                new Person("Резеда Сабирова", "Фронтенд-разработчик"),
                new Person("Рамиль Сабиров", "Тестировщик"),
                new Person("Самира Абророва", "Аналитик"),
                new Person("Амальходжа Курбанов", "Менеджер проекта"),
                new Person("Марьям Хамзина", "DevOps инженер"),
                new Person("Алмаз Кашапов", "Копирайтер"),
                new Person("Алмаз Сабиров", "Архитектор системы")
            };

            Person teamLead = team[0];
            Person client = new Person("Далия Сабирова", "Заказчик");

            Project project = new Project("Разработка сайта продажи татарских сувениров", DateTime.Now.AddMonths(1), client, teamLead);
            Console.WriteLine($"Проект: {project.Description}, Тимлид: {teamLead}, Заказчик: {client}\n");

            Issue task1 = new Issue("Создать макет дизайна", DateTime.Now.AddDays(5), teamLead, team[1]);
            Issue task2 = new Issue("Настроить базу данных", DateTime.Now.AddDays(10), teamLead, team[2]);
            Issue task3 = new Issue("Написать документацию", DateTime.Now.AddDays(7), teamLead, team[5]);
            Issue task4 = new Issue("Подготовить сервер", DateTime.Now.AddDays(8), teamLead, team[7]);
            Issue task5 = new Issue("Создать контент для сайта", DateTime.Now.AddDays(12), teamLead, team[8]);

            project.AddTask(task1);
            project.AddTask(task2);
            project.AddTask(task3);
            project.AddTask(task4);
            project.AddTask(task5);

            project.StartExecution();

            task1.TakeInProgress();
            task2.Delegate(team[3]); 
            task2.TakeInProgress();
            task3.Reject(); 
            task3.Delegate(team[4]);
            task3.TakeInProgress();

            Report report1 = new Report("Макет дизайна создан", DateTime.Now, team[1]);
            task1.SendReport(report1);
            task1.ApproveReport();

            Report report2 = new Report("База данных настроена", DateTime.Now, team[3]);
            task2.SendReport(report2);
            task2.ApproveReport();

            Report report3 = new Report("Документация написана", DateTime.Now, team[4]);
            task3.SendReport(report3);
            task3.ApproveReport();

            Report report4 = new Report("Сервер подготовлен", DateTime.Now, team[7]);
            task4.SendReport(report4);
            task4.ApproveReport();

            Report report5 = new Report("Контент для сайта создан", DateTime.Now, team[8]);
            task5.SendReport(report5);
            task5.ApproveReport();

            project.CloseProject();
        }

    }
}
