using CollectorApp.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CollectorAppTest
{
    [TestClass]
    public class DatabaseAdapterTests
    {
        private const string FIRST_ADDITION = "First Addition";
        private const string SECOND_ADDITION = "Second Addition";

        private IDatabaseAdapter _databaseAdapter;
        private List<string> _possibleData;

        [TestInitialize]
        public void Initialize()
        {
            _databaseAdapter = DatabaseAdapterFactory.Instance.GetDatabaseAdapter();
            _databaseAdapter.ClearData();
            _possibleData = new List<string> { FIRST_ADDITION, SECOND_ADDITION };
        }

        [TestMethod]
        public void AddGetDataTest()
        {
            _databaseAdapter.AddData(FIRST_ADDITION);
            var data = _databaseAdapter.GetData();
            for (int i = 0; i < data.Count; i++)
            {
                Assert.AreEqual(_possibleData[i], data[i], $"Iteration {i}");
            }
            _databaseAdapter.AddData(SECOND_ADDITION);
            data = _databaseAdapter.GetData();
            for (int i = 0; i < data.Count; i++)
            {
                Assert.AreEqual(_possibleData[i], data[i], $"Iteration {i}");
            }
        }

        // to test that clear data functions as desired
        [TestMethod]
        public void AddGetDataTestDuplicate()
        {
            _databaseAdapter.AddData(FIRST_ADDITION);
            var data = _databaseAdapter.GetData();
            for (int i = 0; i < data.Count; i++)
            {
                Assert.AreEqual(_possibleData[i], data[i], $"Iteration {i}");
            }
            _databaseAdapter.AddData(SECOND_ADDITION);
            data = _databaseAdapter.GetData();
            for (int i = 0; i < data.Count; i++)
            {
                Assert.AreEqual(_possibleData[i], data[i], $"Iteration {i}");
            }
        }
    }
}
