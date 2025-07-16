using Microsoft.Data.Sqlite;

namespace Authenticator.Database;

class SQLiteConnection
{
    private static SqliteConnection? connection = null;

    public static SqliteConnection InitialDatabase()
    {
        connection = new("Data Source=AuthenticatorData.db");
        connection.Open();

        return connection;
    }

    public static SqliteConnection GetConnection()
    {
        if (connection == null)
        {
            return InitialDatabase();
        }

        return connection;
    }
}
