using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GrowersClassified.Data
{
    public interface ISqLite
    {
        // Creates connection with local database on users device
        SQLiteConnection GetConnection();
    }
}