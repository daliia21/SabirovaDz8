using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromFile.Models2
{
    class Report
    {
        public string Text { get; set; } // Текст отчета
        public DateTime Date { get; set; } // Дата выполнения отчета
        public string Executor { get; set; } // Исполнитель отчета

        public Report(string text, DateTime date, string executor)
        {
            Text = text;
            Date = date;
            Executor = executor;
        }
    }

}
