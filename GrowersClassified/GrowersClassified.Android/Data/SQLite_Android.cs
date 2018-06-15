using System.IO;
using GrowersClassified.Data;
using GrowersClassified.Droid.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteAndroid))]
namespace GrowersClassified.Droid.Data
{
    public class SqLiteAndroid : ISqLite

    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "UserData.sqlite";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}