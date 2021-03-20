using System;
using System.Collections.Generic;
using System.Text;

namespace MyJijoWalletData.Data
{
    public class Wallet
    {
        public Guid Id{ get; set; }
        public Client Client { get; set; }
        public string Name{ get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
