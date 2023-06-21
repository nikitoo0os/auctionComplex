using auctionComplex.Classes;
using auctionComplex.Models;
using auctionComplex.Resources;
using auctionComplex.Utilities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.Schema;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;

namespace auctionComplex.Services
{
    internal static class UserService
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["AuctionComplexDatabase"].ConnectionString;

        internal static User GetUserById(int id)
        {
            using(var db = new AuctionComplexContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == id);
            }
        }
        internal static List<User> GetAllUsers()
        {
            using (var db = new AuctionComplexContext())
            {
                return db.Users.ToList();
            }
        }
        internal static List<User> GetFilterUserList(string filter)
        {   
            if (FilterUtils.IsDigits(filter))
            {
                using(var db = new AuctionComplexContext())
                {
                    return db.Users.Where(x => x.Id == Convert.ToInt32(filter)).ToList();
                }
            }
            else if (FilterUtils.IsSymbols(filter))
            {
                using (var db = new AuctionComplexContext())
                {
                    return db.Users
                        .Where(x => x.Username.Contains(filter) ||
                        x.Email.Contains(filter)).ToList();
                }
            }
            else if(filter.Contains(" "))
            {
                String[] parts = filter.Split(' ');
                int id = 0;
                string username = "";
                if (parts.Length > 1)
                {
                    if (FilterUtils.IsDigits(parts[0]))
                    {
                        id = Convert.ToInt32(parts[0]);
                        username = parts[1];
                    }
                    else
                    {
                        id = Convert.ToInt32(parts[1]);
                        username = parts[0];
                    }
                }
                return GetFilterUserListByUsernameAndId(id, username);
            }
            else
            {
                using (var db = new AuctionComplexContext())
                {
                    return db.Users.ToList();
                }
            }
        }

        public static List<User> GetFilterUserListByUsernameAndId(int id, string username)
        {
            using(var db = new AuctionComplexContext())
            {
                return db.Users.Where(x => x.Id == id && x.Username.ToLower().Contains(username.ToLower())).ToList();
            }
        }

        internal static void EditUser(User user)
        {
            //using(var db = new AuctionComplexContext())
            //{
            //    var user1 = db.Users.FirstOrDefault(x => x.Id == user.Id);
            //    if (user1 != null)
            //    {
            //        user1.FirstName = user.FirstName;
            //        user1.SecondName = user.SecondName;
            //        user1.Email = user.Email;
            //        user1.Password = user.Password;
            //        user1.Username = user.Username;
            //        user1.IsAdmin = user.IsAdmin;
            //        user1.IsVerify = user.IsVerify;
            //        db.SaveChanges();
            //    }
            //}
            string updateQuery = "UPDATE users SET first_name = @firstName, second_name = @secondName, username = @username, password = @password, is_verify = @isVerify, is_admin = @isAdmin WHERE id = @id";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", user.Id);
                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@firstName", user.FirstName);
                    command.Parameters.AddWithValue("@secondName", user.SecondName);
                    command.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@isVerify", user.IsVerify);

                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        try
                        {
                            DataRow row = dataTable.Rows[0];

                            row["username"] = user.Username;
                            row["first_name"] = user.Username;
                            row["second_name"] = user.Username;
                            row["password"] = user.Username;
                            row["is_valid"] = user.Username;
                            row["is_admin"] = user.Username;
                            dataTable.Rows.Add(row);

                            adapter.Update(dataTable);
                        }
                        catch { }

                    }
                }
            }
        }

        internal static void DeleteUserById(int id)
        {
            using(var db = new AuctionComplexContext())
            {
                User user = db.Users.FirstOrDefault(x => x.Id == id);
                db.Remove(user);
                db.SaveChanges();
            }
        }

        internal static void CreateUser(User user)
        {
            using (var db = new AuctionComplexContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }


            string selectQuery = "SELECT * FROM users";
            string insertQuery = "INSERT INTO users (first_name, username, email, password, second_name) VALUES (@firstName, @username, @email, @password, @secondName)";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter())
                {
                    adapter.SelectCommand = new NpgsqlCommand(selectQuery, connection);
                    adapter.InsertCommand = new NpgsqlCommand(insertQuery, connection);
                    adapter.InsertCommand.Parameters.Add("@firstName", NpgsqlDbType.Varchar, 100, "first_name");
                    adapter.InsertCommand.Parameters.Add("@username", NpgsqlDbType.Varchar, 100, "username");
                    adapter.InsertCommand.Parameters.Add("@email", NpgsqlDbType.Varchar, 100, "email");
                    adapter.InsertCommand.Parameters.Add("@password", NpgsqlDbType.Varchar, 100, "password");
                    adapter.InsertCommand.Parameters.Add("@secondName", NpgsqlDbType.Varchar, 100, "second_name");

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DataRow newRow = dataTable.NewRow();
                    newRow["first_name"] = user.FirstName;
                    newRow["second_name"] = user.SecondName;
                    newRow["email"] = user.Email;
                    newRow["password"] = user.Password;
                    newRow["username"] = user.Username;
    
                    dataTable.Rows.Add(newRow);

                    try
                    {
                        adapter.Update(dataTable);
                    }
                    catch{}
                }
            }

        }

        internal static List<RegistrationStatistics> GetRegistrationStatistics()
        {
            using (var db = new AuctionComplexContext())
            {
                var registrationStatistics = db.Users
                    .GroupBy(u => u.DateOfRegistration)
                    .Select(g => new RegistrationStatistics
                    {
                        DateOfRegistration = g.Key.Date,
                        RegistrationCount = g.Count()
                    })
                    .AsEnumerable() 
                    .OrderBy(s => s.DateOfRegistration)
                    .ToList();

                return registrationStatistics;
            }
        }
    }
}
