using auctionComplex.Classes;
using auctionComplex.Resources;
using auctionComplex.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace auctionComplex.Services.AuctionItems
{
    internal static class AuctionItemService
    {
        public static AuctionItem GetAuctionItemById(int id)
        {
            using (var db = new AuctionComplexContext())
            {
                return db.AuctionItems
                    .FirstOrDefault(x => x.Id == id);
            }
        }
        public static List<AuctionItem> GetRequiredAuctionItems()
        {
            using (var db = new AuctionComplexContext())
            {
                return db.AuctionItems
                    .Where(x => x.IsValid == "verification").ToList();
            }
        }
        public static List<AuctionItem> GetAllAuctionItems()
        {
            using (var db = new AuctionComplexContext())
            {
                return db.AuctionItems.ToList();
            }
        }

        public static void PutAuctionItem(AuctionItem auctionItem)
        {
            if (auctionItem != null) {
                using(var db = new AuctionComplexContext())
                {
                    AuctionItem oldAuctionItem = db.AuctionItems.FirstOrDefault(x => x.Id == auctionItem.Id);
                    oldAuctionItem.Auctioneer = auctionItem.Auctioneer;
                    oldAuctionItem.Description = auctionItem.Description;
                    oldAuctionItem.EndDate = auctionItem.EndDate;
                    oldAuctionItem.StartDate = auctionItem.StartDate;
                    oldAuctionItem.Title = auctionItem.Title;
                    oldAuctionItem.Winner = auctionItem.Winner;
                    oldAuctionItem.Category = auctionItem.Category;
                    oldAuctionItem.IsValid = auctionItem.IsValid;

                    db.SaveChanges();
                }
            }
        }
        internal static List<AuctionItem> GetFilterAuctionItemsList(string filter, bool isActive, string status)
        {
            DateTime currentTime = DateTime.Now;

            if (FilterUtils.IsDigits(filter))
            {
                using (var db = new AuctionComplexContext())
                {
                    if (isActive)
                    {
                        return db.AuctionItems
                            .Where(x => x.Id == Convert.ToInt32(filter)
                                && x.StartDate < currentTime
                                && x.EndDate > currentTime
                                && x.IsValid.Contains(status))
                            .ToList();
                    }
                    else
                    {
                        return db.AuctionItems
                            .Where(x => x.Id == Convert.ToInt32(filter)
                                && x.IsValid.Contains(status))
                            .ToList();
                    }

                }
            }
            else if (FilterUtils.IsSymbols(filter))
            {
                using (var db = new AuctionComplexContext())
                {
                    if (isActive)
                    {
                        return db.AuctionItems
                            .Where(x => x.Title.Contains(filter)
                                && x.StartDate < currentTime
                                && x.EndDate > currentTime
                                && x.IsValid.Contains(status))
                            .ToList();
                    }
                    else
                    {
                        return db.AuctionItems
                            .Where(x => x.Title.Contains(filter)
                                && x.IsValid.Contains(status))
                            .ToList();
                    }

                }
            }
            else
            {
                using (var db = new AuctionComplexContext())
                {
                    return db.AuctionItems.ToList();
                }
            }
        }

        internal static List<AuctionItem> GetAuctionItemByIdAuctioneer(int id)
        {
            using (var db = new AuctionComplexContext())
            {
                return db.AuctionItems.Where(x => x.AuctioneerId == id).ToList();
            }
        }
    }
}
