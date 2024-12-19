using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromFile.Models2
{
    class Report
    {
        private string text;
        private DateTime date;
        private string executor;

        public Report(string text, DateTime date, string executor)
        {
            this.text = text;
            this.date = date;
            this.executor = executor;
        }
    }

}
