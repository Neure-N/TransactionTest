using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TransactionTest1
{
    internal class Program
    {
        private static readonly List<Transaction> _transactions = new List<Transaction>();

        static void Main(string[] args)
        {
            Execute();
        }

        static void Execute()
        {
            Console.Write("Введите команду:");
            var command = Console.ReadLine();

            switch (command)
            {
                case "add":
                    Add();
                    break;

                case "get":
                    Get();
                    break;

                case "exit":
                    Application.Exit();
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }

            Execute();
        }

        static void Add()
        {
            var transaction = new Transaction();

            Console.Write("Введите Id:");
            transaction.Id = int.Parse(Console.ReadLine());

            Console.Write("Введите дату:");
            transaction.TransactionDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите сумму:");
            transaction.Amount = decimal.Parse(Console.ReadLine());

            _transactions.Add(transaction);
            Console.WriteLine("OK");
        }

        static void Get()
        {
            Console.Write("Введите Id:");
            var id = int.Parse(Console.ReadLine());

            var transaction = _transactions.FirstOrDefault(n => n.Id == id);

            Console.WriteLine(JsonConvert.SerializeObject(transaction));
            Console.WriteLine("OK");
        }

        public class Transaction
        {
            public int Id { get; set; }
            public DateTime TransactionDate { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
