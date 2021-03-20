using Microsoft.IdentityModel.Tokens;
using MyJijoWalletData.POCO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyJijoWalletAPI.JWT
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        public readonly string Key;
        public JWTAuthenticationManager(string key) 
        {
            this.Key = key;
        }

        public string Authenticate(Credentials credentials)
        {
            //TODO connect to db y  validate pass
            if (credentials.UserName != "belen")
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(this.Key);

            //token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,credentials.UserName)
                    }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials =  new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
