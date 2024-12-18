using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromTumakov.Models
{
    public class BankTransaction
    {
        public readonly DateTime TransactionDate;
        public readonly decimal Amount;

        public BankTransaction(decimal amount)
        {
            TransactionDate = DateTime.Now;  
            Amount = amount;                 
        }

        public string ToFileString()
        {
            return $"{TransactionDate:yyyy-MM-dd HH:mm:ss}: {Amount}";
        }
    }
}
