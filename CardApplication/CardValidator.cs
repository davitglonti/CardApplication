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
        public static bool IsCardNumberValid(string cardNumber)
        {
            string[] parts = cardNumber.Split("-");
            if(parts.Length !=4)
            {
                return false;
            } 
            else
            {
                return parts.All(part => part.All(char.IsDigit));
            }
        }


      
        public static bool IsExpirationDataValid(string expirationDate)
        {
            if (DateTime.TryParseExact(expirationDate, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
            {
                return expDate > DateTime.Now;
            }
            return false;
        }


        public static bool CheckPinCode(string storedPinCode)
        {
            Console.WriteLine("Please enter your PIN:");
            string enteredPin = Console.ReadLine();

            if (enteredPin == storedPinCode)
            {
                Console.WriteLine("Pin Valid");
                return true;
            } else
            {
                Console.WriteLine("Invalid Pin");
            }
            return true;

        }
    }
}
