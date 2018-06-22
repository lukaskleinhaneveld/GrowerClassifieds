using System.Linq;
using GrowersClassified.Models;
using SQLite;

using Xamarin.Forms;

namespace GrowersClassified.Data
{
    public class TokenDbController
    {
        private static readonly object Locker = new object();
        private readonly SQLiteConnection _database;

        public TokenDbController()
        {
            _database = DependencyService.Get<ISqLite>().GetConnection();
            _database.CreateTable<Token>();
        }
        // All the locks below prevent other processes to use the same thread as the one used for the processes within the 'lock' block

        public Token GetToken()
        {
            lock (Locker)
            {
                if (!_database.Table<Token>().Any())
                {
                    return null;
                }
                else
                {
                    return _database.Table<Token>().First();
                }
            }
        }

        public int SaveToken(Token token)
        {
            lock (Locker)
            {
                if (token.Id != 0)
                {
                    _database.Update(token);
                    return token.Id;
                }

                else
                {
                    return _database.Insert(token);
                }
            }
        }

        public int DeleteToken(int id)
        {
            lock (Locker)
            {
                return _database.Delete<Token>(id);
            }
        }
    }
}