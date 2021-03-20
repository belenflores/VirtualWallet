using System;

namespace MyJijoWalletData.Data
{
    public class TransactionType
    {
        public Guid Id { get; set; }
        public string ExternalCode { get; set; }
        public String Name { get; set; }
        public bool IsDebit { get; set; }
    }
}
