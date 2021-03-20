using System;

namespace MyJijoWalletData.Data
{
    public class Transaction
    {
        public Guid Id{ get; set; }
        public Wallet Wallet { get; set; }
        public DateTime Date { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
    }

        
}
