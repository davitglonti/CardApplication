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
                        Console.WriteLine("withdraw monew now");
                        break;
                    case "3":
                        Console.WriteLine("deposite money");
                        break;
                    case "4":
                        TransactionHandler.ViewLastTransactions(userData);
                        break;
                    case "5":
                        Console.WriteLine("change Pin now");
                        break;
                    case "6":
                        Console.WriteLine("currency conversion now");
                        break;
                    case "7":
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

            }
        }
       
    }
}
