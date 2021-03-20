using MyJijoWalletData.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJijoWalletAPI
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(Credentials credentials);
    }
}
