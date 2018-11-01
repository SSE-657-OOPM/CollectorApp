using System;

namespace CollectorApp.Adapters
{
    /// <summary>
    /// Singleton Database Adapter Factory class.
    /// </summary>
    public sealed class DatabaseAdapterFactory
    {
        private IDatabaseAdapter _databaseAdapter;

        /// <summary>
        /// Prevents a default instance of the <see cref="DatabaseAdapterFactory"/> class from being created.
        /// </summary>
        private DatabaseAdapterFactory() { }

        /// <summary>
        /// The instance of this adapter factory.
        /// </summary>
        private static readonly Lazy<DatabaseAdapterFactory> _instance
            = new Lazy<DatabaseAdapterFactory>(() => new DatabaseAdapterFactory());

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance of this factory.
        /// </value>
        public static DatabaseAdapterFactory Instance => _instance.Value;

        /// <summary>
        /// Gets the database adapter.
        /// </summary>
        /// <returns></returns>
        public IDatabaseAdapter GetDatabaseAdapter()
        {
            if (_databaseAdapter == null)
            {
                _databaseAdapter = new SQLiteDatabaseAdapter();
                _databaseAdapter.InitializeDatabase();
            }
            return _databaseAdapter;
        }
    }
}
