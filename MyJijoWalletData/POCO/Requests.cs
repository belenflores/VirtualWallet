using System;
using System.Collections.Generic;
using System.Text;

namespace MyJijoWalletData.POCO
{
    public class TransactionRequest
    {
        public Guid Wallet { get; set; }
        public Guid Client { get; set; }
        public string TransactionCode { get; set; }
        public decimal Amount { get; set; }
    }
}
