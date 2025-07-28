using Authenticator.Models;
using System.Threading.Tasks;
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
            CREATE TABLE AuthenticatorAccounts___ (
                Id	TEXT NOT NULL,
                Issuer	TEXT NOT NULL,
                Secret	TEXT NOT NULL,
                Username	TEXT NOT NULL,
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

    public static void DestroyConnection()
    {
        SqliteConnection.ClearAllPools();
    }

    public static async Task InsertAuthenticatorAccount(AuthenticatorAccount account)
    {
        var connection = GetConnection();
        var command = connection.CreateCommand();

        command.CommandText =
        @"
            INSERT INTO AuthenticatorAccounts___
            VALUES (
                $Id, $Issue, $Srcret, $Username, $Period, $Digit, $Algorithm, $Type, $Counter, $Pinned
            )
        ";
        command.Parameters.AddWithValue("$Id", "Test");
        command.Parameters.AddWithValue("$Issue", account.Issuer);
        command.Parameters.AddWithValue("$Srcret", account.Secret);
        command.Parameters.AddWithValue("$Username", account.Username);
        command.Parameters.AddWithValue("$Period", account.Period);
        command.Parameters.AddWithValue("$Digit", account.Digit);
        command.Parameters.AddWithValue("$Algorithm", account.Algorithm);
        command.Parameters.AddWithValue("$Type", account.Type);
        command.Parameters.AddWithValue("$Counter", 0);
        command.Parameters.AddWithValue("$Pinned", 0);

        await command.ExecuteReaderAsync();
    }
}
