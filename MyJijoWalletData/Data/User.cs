using System;
using System.Collections.Generic;
using System.Text;

namespace MyJijoWalletData.Data
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
