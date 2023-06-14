using auctionComplex.Classes;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using auctionComplex.Services.AuctionItems;
using Npgsql;

namespace auctionComplex.Services
{
    internal class AuctionChatService
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["AuctionComplexDatabase"].ConnectionString;
        public static List<AuctionChat> GetAllAuctionChats()
        {
            string query = "SELECT * FROM auction_chats";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                List<AuctionChat> auctionChats = new List<AuctionChat>();

                foreach (DataRow row in dataTable.Rows)
                {
                    AuctionChat auctionChat = new AuctionChat
                    {
                        Id = (int)row["id"],
                        AuctionItemId = (int)row["AuctionItemId"] 
                    };

                    auctionChats.Add(auctionChat);
                }

                return auctionChats;
            }
        }

        public static AuctionChat GetAuctionChatById(int auctionChatId)
        {
            string query = "SELECT * FROM auction_chats WHERE id = @AuctionChatId";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@AuctionChatId", auctionChatId);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    AuctionChat auctionChat = new AuctionChat
                    {
                        Id = (int)row["id"],
                        AuctionItemId = (int)row["AuctionItemId"]
                    };

                    return auctionChat;
                }

                return null;
            }
        }

        public void DeleteAuctionChatById(int auctionChatId)
        {
            string query = "DELETE FROM auction_chats WHERE id = @AuctionChatId";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@AuctionChatId", auctionChatId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
