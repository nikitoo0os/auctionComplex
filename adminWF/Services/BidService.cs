
using auctionComplex.Classes;
using auctionComplex.Resources;
using auctionComplex.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace auctionComplex.Services
{
    internal class BidService
    {
        public static List<Bid> GetAllBids()
        {
            using(var db = new AuctionComplexContext())
            {
                return db.Bids.ToList();
            }
        }
        public static List<Bid> GetBidsByAuctionId(int id)
        {
            using (var db = new AuctionComplexContext())
            {
                return db.Bids.Where(x => x.AuctionItem.Id == id).ToList();
            }
        }
        public static List<Bid> GetBidsByUserId(int id)
        {
            using(var db = new AuctionComplexContext())
            {
                return db.Bids.Where(x => x.User.Id == id).ToList();
            }
        }

        internal static List<Bid> GetFilterBidList(string filter)
        {
            using(var db = new AuctionComplexContext())
            {
                if (FilterUtils.IsDigits(filter))
                {
                    return db.Bids.Where(x => x.Id == Convert.ToInt32(filter)).ToList();
                }
                return null;
            }
        }
    }
}
