using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using GrowersClassified.Models;
using System;
using System.Data;

namespace GrowersClassified.Data
{
    public class UserDatabase
    {
        private readonly SQLiteConnection _conn;

        //Create
        public UserDatabase()
        {
            _conn = DependencyService.Get<ISqLite>().GetConnection();
            _conn.CreateTable<UserData>();
        }

        // Clear table
        public void Droptable()
        {
            _conn.Execute("delete from UserData");
        }

        //INSERT
        public string AddUser(Token token)
        {
            _conn.Insert(token);
            return "success";
        }
        
        //UPDATE
        public string UpdateUser(Token token)
        {
            _conn.Execute($"UPDATE UserData SET [AccessToken] = '{token.AccessToken}', [Email] = '{token.Email}', [Id] = '{token.WP_Id}' WHERE [WP_Id] = '{token.Id}'");
            return "success";
        }

        //DELETE
        public string DeleteUser(int WP_Id)
        {
            _conn.Delete<UserData>(WP_Id);
            return "success";
        }

        // Logs the user out by clearing the local database AKA the only user in that table
        public string LogoutUser()
        {
            _conn.Execute("delete from UserData");
            return "success";
        }

        // Get all users
        public List<UserData> GetAllUsers()
        {
            return _conn.Query<UserData>("SELECT * FROM UserData");
        }
    }
}