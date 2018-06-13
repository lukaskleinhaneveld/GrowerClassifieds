using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using GrowersClassified.Data;
using GrowersClassified.iOS.Data;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_IOS))]

namespace GrowersClassified.iOS.Data
{
    public class SQLite_IOS : ISqLite
    {
        public SQLite_IOS() { }

        public SQLite.SQLiteConnection GetConnection()
        {
            var fileName = "Login.sqlite";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "library");
            var path = Path.Combine(libraryPath, fileName);
            var connection = new SQLite.SQLiteConnection(path);
            return connection;
        }
    }
}