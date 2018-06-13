using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrowersClassified.Data;
using GrowersClassified.Droid.Data;
using Xamarin.Forms;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Dependency(typeof(SQLite_Android))]
namespace GrowersClassified.Droid.Data
{
    class SQLite_Android : ISqLite
    {
        public SQLite_Android() { }
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

