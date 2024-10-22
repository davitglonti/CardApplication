using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardApplication
{
    internal class UserMenu
    {
        public static void UserDisplay(UserData userData, bool loggedIn)
        {
            if(loggedIn)
            {
                Console.WriteLine("\nSelect an action:");
                Console.WriteLine("1. View Balance");
                Console.WriteLine("2. Withdraw Money");
                Console.WriteLine("3. Deposit Money");
                Console.WriteLine("4. Last 5 Transactions");
                Console.WriteLine("5. Change PIN");
                Console.WriteLine("6. Currency Conversion");
                Console.WriteLine("7. Exit");

                string choice = Console.ReadLine();

                // Handle user choice
                switch (choice)
                {
                    case "1":
                        TransactionHandler.ViewBalance(userData);
                        break;
                    case "2":
                        TransactionHandler.WithdrawMoney(userData);
                        break;
                    case "3":
                        TransactionHandler.DepositMoney(userData);
                        break;
                    case "4":
                        TransactionHandler.ViewLastTransactions(userData);
                        break;
                    case "5":
                        TransactionHandler.ChangePinCode(userData);
                        break;
                    case "6":
                        TransactionHandler.CurrencyConversion(userData);
                        break;
                    case "7":
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White; // Change text color for better contrast
                        Console.WriteLine("Exiting the application. Thank you for using the service!");
                        Console.ResetColor(); // Reset colors back to defaults
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

            }
        }
       
    }
}
