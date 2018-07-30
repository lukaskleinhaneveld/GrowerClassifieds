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
            var users = GetAllUsers();
            Console.WriteLine(users[0]);
            _conn.Execute($"UPDATE UserData SET [AccessToken] = '{token.AccessToken}', [Username] = '{token.Username}', [Password] = '{token.Password}', [Email] = '{token.Email}', [Id] = '{token.UserApp_Id}' WHERE [UserApp_Id] = '{token.Id}'");
            return "success";
        }

        //DELETE
        public string DeleteUser(int id)
        {
            _conn.Delete<UserData>(id);
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