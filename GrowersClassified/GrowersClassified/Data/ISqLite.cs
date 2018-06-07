using SQLite;

namespace GrowersClassified.Data
{
    public interface ISqLite
    {
        SQLiteConnection GetConnection();
    }
}