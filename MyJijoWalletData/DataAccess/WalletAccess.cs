using MyJijoWalletData.Data;
using MyJijoWalletData.POCO;
using System;
using System.Linq;

namespace MyJijoWalletData.DataAccess
{
    public static class WalletAccess
    {
        public static WalletAvgResponse GetDebitAvg(Guid walletId)
        {
            Exception exception = null;
            WalletAvgResponse response = new WalletAvgResponse();
            MyJijoWalletContext db = new MyJijoWalletContext();

            try
            {
                #region Validate
                //wallets exists                 
                if (!db.Wallets.Where(w => w.Id == walletId).Any())
                    throw new WalletValException("Wallet does not exist");
                #endregion Validate

                response.DebitsAvg = db.Transactions.Where(t => t.Wallet.Id == walletId && t.TransactionType.IsDebit).Average(a => a.Amount);
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
                LogAccess.LogTransaction(walletId, response, "GetDebitAvg",exception);
            }

            return response;
        }
    }
}
