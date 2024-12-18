using DzFromTumakov.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromTumakov.Models
{
    class BankAccount 
    {
        private static int currentId = 1;

        private int accountNumber;
        private decimal balance;
        private BankAccountType bankAccountType;
        private Queue transactionQueue;    


        // переопределение конструктора по умолчанию
        public BankAccount()
        {
            accountNumber = GenerateAccountNumber();

            balance = 0;
            bankAccountType = BankAccountType.Accumulation;
            transactionQueue = new Queue();
            ShowMessage("Создан новый счет с настройками по умолчанию.");
        }

        // конструктор для заполнения баланса
        public BankAccount(decimal balance)
        {
            accountNumber = GenerateAccountNumber();

            this.balance = balance;
            bankAccountType = BankAccountType.Accumulation;
            transactionQueue = new Queue();
            ShowMessage($"Создан новый счет с балансом: {balance}");
        }

        // конструктор для заполнения поля тип банковского счета

        public BankAccount(BankAccountType bankAccountType)
        {
            accountNumber = GenerateAccountNumber();

            balance = 0;
            this.bankAccountType = bankAccountType;
            transactionQueue = new Queue();
            ShowMessage($"Создан новый счет с типом: {bankAccountType}");
        }

        //конструктор для заполнения баланса и типа банковского счета
        public BankAccount(decimal balance, BankAccountType bankAccountType)
        {
            accountNumber = GenerateAccountNumber();
            this.balance = balance;
            this.bankAccountType = bankAccountType;
            transactionQueue = new Queue();
            ShowMessage($"Создан новый счет с балансом: {balance} и типом: {bankAccountType}");
        }
        private int GenerateAccountNumber()
        {
            return currentId++;
        }

        // вывод информации о счете
        public void ShowInfo()
        {
            ShowMessage($"Номер счета: {accountNumber}, Баланс: {balance}, Тип счета: {bankAccountType}");
        }

        private void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        // снятие
        public void Input(int amountOfMoney)
        {
            if (amountOfMoney > balance)
            {
                ShowMessage("На счёте недостаточно средств");
            }
            else
            {
                balance -= amountOfMoney;
                BankTransaction transaction = new BankTransaction(-amountOfMoney);
                transactionQueue.Enqueue(transaction);
                ShowMessage("Деньги успешно сняты!");
            }
        }

        // пополнение
        public void Output(int amountOfMoney)
        {
            balance += amountOfMoney;
            BankTransaction transaction = new BankTransaction(amountOfMoney);
            transactionQueue.Enqueue(transaction);
            ShowMessage("Счет успешно пополнен!");
        }

        // спросить у камиля
        public void Transfer(BankAccount otherAccount, decimal amount)
        {
            if (otherAccount == null)
            {
                ShowMessage("Счет для перевода не существует");
                return;
            }

            if (amount <= 0)
            {
                ShowMessage("Сумма перевода должна быть больше нуля");
                return;
            }

            if (otherAccount.balance < amount)
            {
                ShowMessage("На счёте, с которого совершается перевод, недостаточно средств");
                return;
            }

            otherAccount.balance -= amount; 
            this.balance += amount;
            BankTransaction transactionFrom = new BankTransaction(-amount);
            BankTransaction transactionTo = new BankTransaction(amount);
            transactionQueue.Enqueue(transactionFrom);
            otherAccount.transactionQueue.Enqueue(transactionTo);

            ShowMessage($"Переведено {amount} со счета {otherAccount.accountNumber} на счет {this.accountNumber}");
        }

        public void ShowTransactionHistory()
        {
            Console.WriteLine($"История транзакций для счета {accountNumber}:");
            foreach (BankTransaction transaction in transactionQueue)
            {
                Console.WriteLine($"Дата: {transaction.TransactionDate}, сумма: {transaction.Amount}");
            }
        }

        public void Dispose()
        {
            string outputFileName = "transaction.txt";
            using (StreamWriter writer = new StreamWriter(outputFileName, append: true))
            {
                foreach (BankTransaction transaction in transactionQueue)
                {
                    writer.WriteLine(transaction.ToFileString());
                }
            }

            GC.SuppressFinalize(this);

            Console.WriteLine("Данные о транзакциях записаны в файл.");
        }
    }
}
