using Amazon.Runtime.Internal.Auth;
using auctionComplex.Classes;
using auctionComplex.Resources;
using auctionComplex.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auctionComplex.Services
{
    internal class WalletService
    {
        public static List<Wallet> GetAllWalletsList()
        {
            using(var db = new AuctionComplexContext())
            {
                return db.Wallets.ToList();
            }
        }

        public static List<Wallet> GetWalletsByIdUser(int id)
        {
            using (var db = new AuctionComplexContext())
            {
                return db.Wallets.Where(x => x.UserId == id).ToList();
            }
        }

        public static Wallet GetWalletById(int id)
        {
            using (var db = new AuctionComplexContext())
            {
                return db.Wallets.FirstOrDefault(x => x.Id == id);
            }
        }

        public static List<Wallet> GetFilterWalletList(string filter, int? idUser = null)
        {
            using(var db = new AuctionComplexContext())
            {
                if(filter != null)
                {
                    if (FilterUtils.IsDigits(filter))
                    {
                        if(idUser != null)
                        {
                            return db.Wallets
                                .Where(x => x.Id == Convert.ToInt32(filter) && x.UserId == idUser)
                                .ToList();
                        }
                        else
                        {
                            return db.Wallets.Where(x => x.Id == Convert.ToInt32(filter)).ToList();
                        }
                       
                    }
                    else if (FilterUtils.IsSymbols(filter))
                    {
                        if (idUser != null)
                        {
                            return db.Wallets
                                .Where(x => x.Address.Contains(filter) && x.UserId == idUser)
                                .ToList();
                        }
                        else
                        {
                            return db.Wallets.Where(x => x.Address.Contains(filter)).ToList();
                        }
                    }
                }
                else
                {
                    if(idUser != null)
                    {
                        return db.Wallets.Where(x => x.UserId == idUser).ToList();
                    }
                }
            }
            return null;
        } 
    }
}
