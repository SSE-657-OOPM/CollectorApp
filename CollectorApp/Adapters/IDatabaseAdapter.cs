using System.Collections.Generic;

namespace CollectorApp.Adapters
{
    /// <summary>
    /// Database adapter.
    /// </summary>
    public interface IDatabaseAdapter
    {
        /// <summary>
        /// Initializes the database.
        /// </summary>
        void InitializeDatabase();

        /// <summary>
        /// Adds the data to the database.
        /// </summary>
        /// <param name="input">The input.</param>
        void AddData(string input);

        /// <summary>
        /// Clears the data from the database.
        /// </summary>
        void ClearData();

        /// <summary>
        /// Gets the data from the database.
        /// </summary>
        /// <returns></returns>
        List<string> GetData();
    }
}
