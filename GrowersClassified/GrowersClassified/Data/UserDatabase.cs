using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using GrowersClassified.Models;

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

        //DELETE
        public string DeleteUser(int id)
        {
            _conn.Delete<UserData>(id);
            return "success";
        }

        // Logs the user out by clearing the local database AKA the only user in that table
        public string LogoutUser()
        {
            _conn.DropTable<UserData>();
            return "success";
        }

        // Get all users
        public List<UserData> GetAllUsers()
        {
            return _conn.Query<UserData>("SELECT * FROM UserData");
        }
    }
}