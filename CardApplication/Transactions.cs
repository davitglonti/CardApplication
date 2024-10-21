using System;
using System.Linq;

namespace CardApplication
{
    public static class TransactionHandler
    {
        public static void ViewBalance(UserData userData) // Corrected method name and signature
        {
            decimal totalUSD = userData.TransactionHistory[0].AmountUSD;
            decimal totalEUR = userData.TransactionHistory[0].AmountEUR;

            Console.WriteLine($"\nTotal Balance:");
            Console.WriteLine($"USD: {totalUSD:C}");
            Console.WriteLine($"EUR: {totalEUR:C}"); 
        }

        public static void ViewLastTransactions(UserData userData)
        {
            Console.WriteLine("Last Transactions:");

            if (userData.TransactionHistory.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }

           
            int lastTransactionIndex = userData.TransactionHistory.Count - 1;
            for (int i = 0; i < 5; i++)
            {
                if (lastTransactionIndex - i < 0) break; 

                var transaction = userData.TransactionHistory[lastTransactionIndex - i];
                Console.WriteLine($"Date: {transaction.TransactionDate}");
                Console.WriteLine($"Type: {transaction.TransactionType}");
                Console.WriteLine($"Usd: {transaction.AmountUSD}");
                Console.WriteLine($"Euro: {transaction.AmountEUR}");
                Console.WriteLine("-----");

               

            }
        }


    }
}