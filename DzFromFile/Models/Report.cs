using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromFile.Models
{
    class Report
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Person Executor { get; set; }

        public Report(string text, DateTime date, Person executor)
        {
            Text = text;
            Date = date;
            Executor = executor;
        }

        public void ShowReport()
        {
            Console.WriteLine($"Отчет: {Text}, Дата: {Date}, Исполнитель: {Executor}");
        }
    }

}
