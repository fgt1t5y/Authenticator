using Microsoft.Data.Sqlite;

namespace Authenticator.Database;

class SQLiteConnection
{
    private static SqliteConnection? connection = null;

    public static SqliteConnection InitializeDatabase()
    {
        connection = new("Data Source=AuthenticatorData.db");
        connection.Open();

        return connection;
    }

    public static void InitializeTables()
    {
        var connection = GetConnection();
        var command = connection.CreateCommand();

        command.CommandText =
        @"
            CREATE TABLE AuthenticatorAccounts__ (
                Id	TEXT NOT NULL,
                Issuer	TEXT NOT NULL,
                Secret	TEXT NOT NULL,
                Period	INTEGER NOT NULL,
                Digit	INTEGER NOT NULL,
                Algorithm	INTEGER NOT NULL,
                Type	INTEGER NOT NULL,
                Counter	INTEGER NOT NULL DEFAULT 0,
                Pinned	INTEGER NOT NULL DEFAULT 0,
                PRIMARY KEY(Id)
            )
        ";
        command.ExecuteNonQuery();
    }

    public static SqliteConnection GetConnection()
    {
        if (connection == null)
        {
            return InitializeDatabase();
        }

        return connection;
    }
}
