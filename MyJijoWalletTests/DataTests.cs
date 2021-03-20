using MyJijoWalletData.DataAccess;
using MyJijoWalletData.POCO;
using NUnit.Framework;
using System;

namespace MyJijoTests
{
    public class Tests
    {
        MyJijoWalletContext dbConn;       

        [SetUp]
        public void Setup()
        {
            dbConn = new MyJijoWalletContext();
        }

        [Test]
        public void DBConnect()
        {           
            Assert.IsTrue(dbConn.Database.CanConnect());
        }

        [Test]
        public void AddTransactionShouldFail()
        {
            TransactionRequest request;
            request = new TransactionRequest();
            request.Client = new Guid(); 
            request.Amount = (new Random()).Next(0, 1000000);
            request.TransactionCode = "ATMDEB";
            request.Wallet = new Guid();

            TransactionResponse response = TransactionAccess.AddTransaction(request);
            Assert.IsFalse(response.ErrorCode == 0);
        }

        [Test]
        public void AddTransactionShouldSucceed()
        {
            TransactionRequest request;
            request = new TransactionRequest();
            request.Amount = (new Random()).Next(0, 1000000);
            request.Client = Guid.Parse("8920d0ff-4d19-4a3f-8d11-63c0ceb39923");
            request.TransactionCode = "ATMDEB";
            request.Wallet = Guid.Parse("8920d0ff-4d19-4a3f-8d11-63c0ceb39922");

            TransactionResponse response = TransactionAccess.AddTransaction(request);
            Assert.IsTrue(response.ErrorCode == 0);
        }

        [Test]
        public void GetDebitAvgShouldSucceed()
        {
            var wallet = "8920d0ff-4d19-4a3f-8d11-63c0ceb39922";

            WalletAvgResponse response = WalletAccess.GetDebitAvg(Guid.Parse(wallet));
            Assert.IsTrue(response.ErrorCode == 0);
        }
    }
}