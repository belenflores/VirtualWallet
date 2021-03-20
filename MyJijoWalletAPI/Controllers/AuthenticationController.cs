using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyJijoWalletData.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJijoWalletAPI.Controllers
{
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJWTAuthenticationManager AuthenticationManager;

        public AuthenticationController(IJWTAuthenticationManager authenticationManager) 
        {
            this.AuthenticationManager = authenticationManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/authenticate/")]
        public ActionResult Authenticate([FromBody] Credentials credentials)
        {
            var token = this.AuthenticationManager.Authenticate(credentials);

            if (token != null)
                return Ok(token);
            else
                return Unauthorized();
        }

     
    }
}
