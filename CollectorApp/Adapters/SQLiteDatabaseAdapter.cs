using DataAccessLibrary;
using System.Collections.Generic;

namespace CollectorApp.Adapters
{
    /// <summary>
    /// Class for accessing SQLite database.
    /// </summary>
    /// <seealso cref="CollectorApp.Adapters.IDatabaseAdapter" />
    public sealed class SQLiteDatabaseAdapter : IDatabaseAdapter
    {
        public void AddData(string input)
        {
            SQLiteDataAccess.AddData(input);
        }

        public List<string> GetData()
        {
            return SQLiteDataAccess.GetData();
        }

        public void InitializeDatabase()
        {
            SQLiteDataAccess.InitializeDatabase(); 
        }
    }
}
