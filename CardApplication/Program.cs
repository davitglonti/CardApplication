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

             // Deserialize the JSON data to UserData object
             UserData userData = JsonConvert.DeserializeObject<UserData>(jsonData);

            // Prompt user for card number
            Console.WriteLine("Please enter your card number (format: 1234-5678-9012-3456):");
            string userCardNumber = Console.ReadLine();


            //va;idate card number/ date
               //Validation does not work fully  -error
            if (!CardValidator.IsCardNumberValid(userCardNumber))
            {
                Console.WriteLine("Invalid card number format.");
                return;
            } else
            {
                Console.WriteLine("Valid number");
            }


            // Prompt user for expiration date
            Console.WriteLine("Please enter your expiration date (format: MM/yy):");
            string userExpirationDate = Console.ReadLine();

            if (!CardValidator.IsExpirationDataValid(userExpirationDate))
            {
                 Console.WriteLine("Invalid expiration Date.");
            }

            Console.WriteLine($"Welcome {userData.FirstName} {userData.LastName}");
            Console.WriteLine($"Card Number: {userData.CardDetails.CardNumber}");
            Console.WriteLine($"Expiration Date: {userData.CardDetails.ExpirationDate}");




        }
    }
}
