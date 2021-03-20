using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using MyJijoWalletData.Data;

public class MyJijoWalletContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<TransactionType> TransactionTypes { get; set; }
    public DbSet<Transaction> Transactions{ get; set; }
    public DbSet<Log> Logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //TODO take from ConfigurationManager
        var connString = "Host = localhost; Database = MyJijoWallet; Username = wallet_user; Password = Pa$$w0rd";
                     
        options.UseNpgsql(connString);
    }

    



}