using System;
using System.Collections.Generic;
using System.Text;

namespace MyJijoWalletData.Data
{
    public class Log
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Origin { get; set; }
        public string JsonRequest { get; set; }
        public bool Error { get; set; }
        public string JsonResponse { get; set; }
        public string JsonError { get; set; }
    }
}
