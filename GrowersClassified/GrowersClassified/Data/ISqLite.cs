using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GrowersClassified.Data
{
    public interface ISqLite
    {
        SQLiteConnection GetConnection();
    }
}