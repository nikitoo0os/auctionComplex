using auctionComplex.Classes;
using auctionComplex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace auctionComplex.Services
{
    internal class TransactionService
    {
        public static List<Transaction> GetAllTransactions()
        {
            using (var db = new AuctionComplexContext())
            {
                return db.Transactions.ToList();
            }
        }
        public static List<Transaction> GetTransactionsByIdUser(int id)
        {
            using (var db = new AuctionComplexContext())
            {
                return db.Transactions
                    .Where(x => x.SenderWallet.Id == id || x.ReceiverWallet.Id == id)
                    .ToList();
            }
        }
        public static Transaction GetTransactionByIdTransaction(int id)
        {
            using(var db = new AuctionComplexContext())
            {
                return db.Transactions.FirstOrDefault(x => x.Id == id);
            }
        }

        public static List<Transaction> GetTransactionByDate(DateTime startDate, DateTime endDate)
        {
            using (var db = new AuctionComplexContext())
            {
                return db.Transactions.Where(x => x.Timestamp >= startDate && x.Timestamp <= endDate).ToList();
            }
        }
    }
}
