using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyJijoWalletData.DataAccess;
using MyJijoWalletData.POCO;
using System;


namespace MyJijoWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        [HttpPost]
        [Route("api/WalletTransaction/")]
        public IActionResult PostWalletTransaction(TransactionRequest request)
        {
            TransactionResponse response = new TransactionResponse();

            try
            {
                response = TransactionAccess.AddTransaction(request);

                if(response.ErrorCode == MyJijoWalletData.ErrorCode.NoError)
                    return Ok(response);
                if (response.ErrorCode == MyJijoWalletData.ErrorCode.Validation)
                    return BadRequest(response);
                else
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception ex) 
            {
                response.ErrorCode = MyJijoWalletData.ErrorCode.Other;
                response.ErrorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet]
        [Route("api/GetWalletAvg/{walletId}")]
        public IActionResult GetWalletAvg(string walletId)
        {
            WalletAvgResponse response = new WalletAvgResponse();

            try
            {  
                response = WalletAccess.GetDebitAvg(Guid.Parse(walletId)) ; 

                if (response.ErrorCode == MyJijoWalletData.ErrorCode.NoError)
                    return Ok(response.DebitsAvg);
                if (response.ErrorCode == MyJijoWalletData.ErrorCode.Validation)
                    return BadRequest(response);
                else
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                response.ErrorCode = MyJijoWalletData.ErrorCode.Other;
                response.ErrorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
