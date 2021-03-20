using System;
using System.Collections.Generic;
using System.Text;

namespace MyJijoWalletData.POCO
{
    public abstract class Response
    {
        public Response() 
        {
            this.ErrorCode = ErrorCode.NoError;
        }
        public Guid IdReference { get; set; }
        public string ErrorMessage { get; set; }       
        public ErrorCode ErrorCode { get; set; }
    }

    public class TransactionResponse : Response
    {
        public decimal Amount { get; set; }
    }

    public class WalletAvgResponse:Response
    {
        public decimal DebitsAvg { get; set; }
    }
}

namespace MyJijoWalletData
{
    public enum ErrorCode
    {
        NoError= 0,
        Validation = 100,
        Other = 101
    }
}