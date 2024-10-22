using System;
using System.IO;
using Newtonsoft.Json;

namespace CardApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonData = File.ReadAllText(@"C:\Users\davit\source\repos\CardApplication\CardApplication\CardData.json");
            bool LoggedIn = false;

            // Deserialize the JSON data to UserData object
            UserData userData = JsonConvert.DeserializeObject<UserData>(jsonData);

            // Prompt user for card number
            Console.WriteLine("Please enter your card number (format: 1234-5678-9012-3456):");
            string userCardNumber = Console.ReadLine();

            // Validate card number
            if (!CardValidator.IsCardNumberValid(userCardNumber))
            {
                Console.WriteLine("Invalid card number format or does not match stored data.");
                return;
            }
            else
            {
                Console.WriteLine("Valid number");
            }

            // Prompt user for expiration date
            Console.WriteLine("Please enter your expiration date (format: MM/yy):");
            string userExpirationDate = Console.ReadLine();

            // Validate expiration date
            if (!CardValidator.IsExpirationDataValid(userExpirationDate))
            {
                Console.WriteLine("Invalid expiration date.");
                return; // Exit if expiration date check fails
            }

            // Check PIN code only if card number and expiration date are valid
            if (!CardValidator.CheckPinCode(userData.PinCode))
            {
                Console.WriteLine("Invalid PIN. Exiting...");
                return; // Exit if PIN code check fails
            }

            // If all checks are correct, log the user in
            LoggedIn = true; // Successfully logged in
            Console.WriteLine("Logged in successfully!");

            // Show user menu
            if (LoggedIn)
            {
                UserMenu.UserDisplay(userData, LoggedIn);
            }
        }
    }
}