using MyJijoWalletData.Data;
using MyJijoWalletData.POCO;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace MyJijoWalletData.DataAccess
{
    public static class TransactionAccess
    {
        public static TransactionResponse AddTransaction(TransactionRequest request)
        {
            Exception exception = null;
            TransactionResponse response = new TransactionResponse();            
            MyJijoWalletContext db = new MyJijoWalletContext();

            try
            {
                #region Validate
                //client exists
                if (!db.Clients.Where(c => c.Id == request.Client).Any())
                    throw new WalletValException("Client does not exist");

                //wallets exists and it belongs to client
                Wallet wallet = db.Wallets.Where(w => w.Id == request.Wallet && w.Client.Id == request.Client).FirstOrDefault();
                if (wallet == null)
                    throw new Exception("Wallet does not exist");

                //transaction type code exists
                TransactionType traType = db.TransactionTypes.Where(tt => tt.ExternalCode == request.TransactionCode).FirstOrDefault();
                if (traType == null)
                    throw new Exception("Transaction type code does not exist");
                #endregion Validate

                Transaction tra = new Transaction();
                tra.Amount = request.Amount;
                tra.Date = DateTime.Now;
                tra.Id = Guid.NewGuid();
                tra.TransactionType = traType;
                tra.Wallet = wallet;

                db.Transactions.Add(tra);
                response.Amount = tra.Amount;
            }
            catch (Exception ex)
            {
                if (ex is WalletValException)
                    response.ErrorCode = ErrorCode.Validation;
                else
                    response.ErrorCode = ErrorCode.Other;

                response.ErrorMessage = ex.Message;
                exception = ex;
            }
            finally
            {
                db.SaveChanges();
                LogAccess.LogTransaction(request, response,"AddTransaction", exception);
            }

            return response;
        }
    }

    [Serializable]
    internal class WalletValException : Exception
    {
        public WalletValException()
        {
        }

        public WalletValException(string message) : base(message)
        {
        }

        public WalletValException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WalletValException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
