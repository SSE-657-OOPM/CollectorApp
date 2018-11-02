using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace DataAccessLibrary
{
    /// <summary>
    /// Class for SQLite Database Access.
    /// </summary>
    public static class SQLiteDataAccess
    {
        private static readonly string DATABASE_FILENAME = "Filename=collections.db";

        /// <summary>
        /// Initializes the database.
        /// </summary>
        public static void InitializeDatabase()
        {
            using (SqliteConnection db
                = new SqliteConnection(DATABASE_FILENAME))
            {
                db.Open();
                var collectionTableCommand = "CREATE TABLE IF NOT EXISTS " +
                    "Collections (Primary_Key INTEGER PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(2048) NULL)";
                var createCollectionTable = new SqliteCommand(collectionTableCommand, db);
                createCollectionTable.ExecuteReader();
            }
        }

        /// <summary>
        /// Adds the data.
        /// </summary>
        /// <param name="input">The input.</param>
        public static void AddData(string input)
        {
            using (SqliteConnection db
                = new SqliteConnection(DATABASE_FILENAME))
            {
                db.Open();
                var insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO Collections VALUES (NULL, @Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", input);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        /// <summary>
        /// Clears the data from the database.
        /// </summary>
        public static void ClearData()
        {
            using (SqliteConnection db
                = new SqliteConnection(DATABASE_FILENAME))
            {
                db.Open();
                var insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "DELETE FROM Collections";
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetData()
        {
            var entries = new List<string>();
            using (SqliteConnection db
                = new SqliteConnection(DATABASE_FILENAME))
            {
                db.Open();
                var selectCommand = new SqliteCommand("SELECT Text_Entry from Collections", db);
                var query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }

            return entries;
        }
    }
}
