using Microsoft.Data.Sqlite;
using System.IO;

namespace LibraryManagement.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(string connectionString)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var createScript = File.ReadAllText("Scripts/CreateDatabase.sql");
            var insertScript = File.ReadAllText("Scripts/InsertSampleData.sql");

            using (var command = new SqliteCommand(createScript, connection))
            {
                command.ExecuteNonQuery();
            }

            using (var command = new SqliteCommand(insertScript, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
