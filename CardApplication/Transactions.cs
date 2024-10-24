﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace CardApplication
{
    public static class TransactionHandler
    {
        public static void ViewBalance(UserData userData) // Corrected method name and signature
        {
            var lastTransaction = userData.TransactionHistory[userData.TransactionHistory.Count - 1]; // Using index

            if (lastTransaction != null)
            {
                decimal totalGEL = lastTransaction.Amount;
                decimal totalUSD = lastTransaction.AmountUSD;
                decimal totalEUR = lastTransaction.AmountEUR;

                Console.WriteLine($"\nTotal Balance:");
                Console.WriteLine($"GEL: {totalGEL:C}");
                Console.WriteLine($"USD: {totalUSD:C}");
                Console.WriteLine($"EUR: {totalEUR:C}");
            }
            else
            {
                Console.WriteLine("No transactions found.");
            }
        }


        // This method processes transactions (either deposit or withdrawal) based on the type and amount.
        public static void ProcessTransaction(UserData userData, string transactionType, decimal amount)
        {
            var lastTransaction = userData.TransactionHistory.LastOrDefault();
            decimal currentBalance = lastTransaction?.AmountUSD ?? 0;  // Get current balance in USD.

            // If it's a withdrawal and the amount exceeds the balance, stop the process.
            if (transactionType == "Withdraw" && amount > currentBalance)
            {
                Console.WriteLine("Insufficient funds for this withdrawal.");
                return;
            }

            // Update the balance depending on whether it's a withdrawal or deposit.
            decimal newBalance = transactionType == "Withdraw" ? currentBalance - amount : currentBalance + amount;

            // Create a new transaction object with the updated balance and transaction type.
            var newTransaction = new Transaction
            {
                TransactionDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"),  // Save current date and time.
                TransactionType = transactionType,  // Save transaction type (Deposit/Withdraw).
                AmountUSD = newBalance,  // Updated USD balance.
                AmountEUR = lastTransaction?.AmountEUR ?? 0  // Keep EUR balance from the last transaction.
            };

            // Add the new transaction to the transaction history.
            userData.TransactionHistory.Add(newTransaction);

            // Convert the updated user data to JSON and save it to a file.
            string updatedData = JsonConvert.SerializeObject(userData, Formatting.Indented);
            try
            {
                File.WriteAllText(@"C:\Users\davit\source\repos\CardApplication\CardApplication\CardData.json", updatedData);
                Console.WriteLine($"{transactionType} successful! Your new balance is: ${newBalance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }


        public static void WithdrawMoney(UserData userData)
        {
            Console.WriteLine("Enter the amount you wish to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amountToWithdraw) && amountToWithdraw > 0)
            {
                ProcessTransaction(userData, "Withdraw", amountToWithdraw);  // Process withdrawal.
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }


        public static void DepositMoney(UserData userData)
        {
            Console.WriteLine("Enter the amount you wish to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amountToDeposit) && amountToDeposit > 0)
            {
                ProcessTransaction(userData, "Deposit", amountToDeposit);  // Process deposit.
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
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
                Console.WriteLine($"Gel: {transaction.Amount}");
                Console.WriteLine($"Usd: {transaction.AmountUSD}");
                Console.WriteLine($"Euro: {transaction.AmountEUR}");
                Console.WriteLine("-----");

            }
        }


        


        public static void ChangePinCode(UserData userData)
        {

            var lastTransaction = userData.TransactionHistory[userData.TransactionHistory.Count - 1]; // Using index

            // Prompt user to enter current PIN
            Console.WriteLine("Please enter your currentt PIN:");
            string enteredPin = Console.ReadLine();

            // Verify the entered PIN
            if (enteredPin != userData.PinCode)
            {
                Console.WriteLine("Invalid current PIN. Please try again.");
                return;
            }

            // Prompt for new PIN
            Console.WriteLine("Please enter your new PIN:");
            string newPin = Console.ReadLine();

            // Validate new PIN
            if (string.IsNullOrWhiteSpace(newPin) || newPin.Length != 4 || !newPin.All(char.IsDigit))
            {
                Console.WriteLine("Invalid new PIN. Please ensure it's a 4-digit number.");
                return;
            }

            // Update the PIN in the UserData object
            userData.PinCode = newPin;

            // Create a new transaction record for the PIN change
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                TransactionType = "ChangePin",
                Amount = lastTransaction.Amount, 
                AmountUSD = lastTransaction.AmountUSD,
                AmountEUR = lastTransaction.AmountEUR
            };

            // Add the new transaction to the transaction history
            userData.TransactionHistory.Add(transaction);

            // Update the JSON file with the new PIN and transaction history
            string updatedData = JsonConvert.SerializeObject(userData, Formatting.Indented);

            // Ensure you have permissions and the file path is correct
            try
            {
                File.WriteAllText(@"C:\Users\davit\source\repos\CardApplication\CardApplication\CardData.json", updatedData);
                Console.WriteLine("PIN changed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        private const decimal USDToGELRate = 3.0m; 
        private const decimal EURToGELRate = 3.5m; 
        private const decimal GELToUSDRate = 1 / USDToGELRate; 
        private const decimal GELToEURRate = 1 / EURToGELRate; 
        private const decimal USDtoEURRate = 0.85m; 
        private const decimal EURToUSDRate = 1 / USDtoEURRate; 
        public static void CurrencyConversion(UserData userData)
        {
            var lastTransaction = userData.TransactionHistory[userData.TransactionHistory.Count - 1];

            Console.WriteLine("Enter the amount to convert:");
            string input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal amount) && amount > 0)
            {
                Console.WriteLine("Select the conversion type:");
                Console.WriteLine("1. GEL to USD");
                Console.WriteLine("2. GEL to EUR");
                Console.WriteLine("3. USD to GEL");
                Console.WriteLine("4. EUR to GEL");
                Console.WriteLine("5. USD to EUR");
                Console.WriteLine("6. EUR to USD");

                string choice = Console.ReadLine();
                decimal convertedAmount = 0;
                string transactionType = "";

                switch (choice)
                {
                    case "1":
                        convertedAmount = amount * GELToUSDRate;
                        transactionType = "GEL to USD";
                        Console.WriteLine($"{amount} GEL is approximately {convertedAmount:F2} USD");
                        break;
                    case "2":
                        convertedAmount = amount * GELToEURRate;
                        transactionType = "GEL to EUR";
                        Console.WriteLine($"{amount} GEL is approximately {convertedAmount:F2} EUR");
                        break;
                    case "3":
                        convertedAmount = amount * USDToGELRate;
                        transactionType = "USD to GEL";
                        Console.WriteLine($"{amount} USD is approximately {convertedAmount:F2} GEL");
                        break;
                    case "4":
                        convertedAmount = amount * EURToGELRate;
                        transactionType = "EUR to GEL";
                        Console.WriteLine($"{amount} EUR is approximately {convertedAmount:F2} GEL");
                        break;
                    case "5":
                        convertedAmount = amount * USDtoEURRate;
                        transactionType = "USD to EUR";
                        Console.WriteLine($"{amount} USD is approximately {convertedAmount:F2} EUR");
                        break;
                    case "6":
                        convertedAmount = amount * EURToUSDRate;
                        transactionType = "EUR to USD";
                        Console.WriteLine($"{amount} EUR is approximately {convertedAmount:F2} USD");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid conversion option.");
                        return; // Exit if invalid choice
                }

                // Save the transaction in the transaction history
                var newTransaction = new Transaction
                {
                    TransactionDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    TransactionType = $"Currency Conversion ({transactionType})",
                    Amount = amount,
                    AmountUSD = lastTransaction?.AmountUSD ?? 0,
                    AmountEUR = lastTransaction?.AmountEUR ?? 0
                };

                 userData.TransactionHistory.Add(newTransaction);

                // Update the JSON file with the new transaction
                string updatedData = JsonConvert.SerializeObject(userData, Formatting.Indented);
                File.WriteAllText(@"C:\Users\davit\source\repos\CardApplication\CardApplication\CardData.json", updatedData);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }

    }
}







    
