using auctionComplex.Classes;
using auctionComplex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auctionComplex.Services
{
    internal class ChatMessageService
    {
        internal static List<ChatMessage> GetAllChatMessages()
        {
            using(var db = new AuctionComplexContext())
            {
                return db.ChatMessages.ToList();
            }
        }

        internal static List<ChatMessage> GetChatMessagesByAuctionChatId(int id)
        {
            using (var db = new AuctionComplexContext())
            {
                try {
                    return db.ChatMessages.Where(x => x.Id == id).ToList();
                }
                catch(NullReferenceException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                    return null;
                }
            }
        }
    }
}
