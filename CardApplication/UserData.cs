using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardApplication
{
    // Class to store details about each transaction
    public class Transaction
    {
        public string TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal AmountUSD { get; set; }
        public decimal AmountEUR { get; set; }
    }

    // Class to store card details
    public class CardDetails
    {
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVC { get; set; }
    }


    // Main class that holds user data
    public class UserData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CardDetails CardDetails { get; set; }
        public string PinCode { get; set; }
        public List<Transaction> TransactionHistory { get; set; }
    }
}
