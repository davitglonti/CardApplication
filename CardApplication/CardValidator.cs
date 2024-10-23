using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CardApplication
{
    internal class CardValidator
    {

        /// Validates the format of the card number.
        /// The expected format is four groups of four digits separated ("1234-5678-9012-3456").
        public static bool IsCardNumberValid(string cardNumber, UserData userData)
        {
            // Remove dashes from user input and stored card number
            string cleanedInput = cardNumber.Replace("-", "");
            string cleanedStoredCardNumber = userData.CardDetails.CardNumber.Replace("-", "");

            
            if (cleanedInput == cleanedStoredCardNumber)
            {
                return true; 
            }

            return false; 
        }



        /* Validates the expiration date format and checks if it is in the future.
         The expected format is "MM/yy". */
        public static bool IsExpirationDataValid(string expirationDate, UserData userData)
        {
            // Access the expiration date from userData's CardDetails
            if (expirationDate == userData.CardDetails.ExpirationDate)
            {
                Console.WriteLine("Valid expiration date.");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid expiration date.");
                return false;
            }
        }


        public static bool CheckPinCode(string storedPinCode)
        {
            Console.WriteLine("Please enter your PIN:");
            string enteredPin = Console.ReadLine();

            if (enteredPin == storedPinCode)
            {
                Console.WriteLine("Pin Valid");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Pin");
                return false; // Return false if the PIN is incorrect
            }
        }
    }
}
