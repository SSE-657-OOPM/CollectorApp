using CollectorApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectorAppTest.UnitTests.WhiteBoxTests.ControlFlow
{
    [TestClass]
    public class AddCollectionControlFlowTests
    {
        private const string TEST_NAME = "Test Name";
        private const string TEST_DESCRIPTION = "Test description.";
        private const string TEST_CATEGORY_NAME = "Music";
        private Priority _testPriority;
        private Category _testCategory;
        private User _testUser;

        [TestInitialize]
        public void Initialize()
        {
            _testUser = new User();
            Priority.LoadPriorityLevels();
            Category.LoadDefaultCategories();
            _testPriority = Priority.GetPriority(Priority.PriorityLevel.Normal);
            _testCategory = Category.GetCategory(TEST_CATEGORY_NAME);
        }

        [TestMethod]
        public void TestCase1()
        {
            Assert.IsTrue(_testUser.Collections.Count == 0);
            _testUser.AddCollection(TEST_NAME, string.Empty,
                _testPriority, _testCategory);
            Assert.IsTrue(_testUser.Collections.Count == 1);

            var collection = _testUser.Collections[0];
            Assert.AreEqual(TEST_NAME, collection.Name);
            Assert.AreNotEqual(string.Empty, collection.Description);
            Assert.AreSame(
                Priority.GetPriority(Priority.PriorityLevel.Normal),
                collection.Priority);
            Assert.AreSame(
                Category.GetCategory(TEST_CATEGORY_NAME),
                collection.Category);
        }

        [TestMethod]
        public void TestCase2()
        {
            Assert.IsTrue(_testUser.Collections.Count == 0);
            _testUser.AddCollection(TEST_NAME, TEST_DESCRIPTION,
                _testPriority, _testCategory);
            Assert.IsTrue(_testUser.Collections.Count == 1);

            var collection = _testUser.Collections[0];
            Assert.AreEqual(TEST_NAME, collection.Name);
            Assert.AreEqual(TEST_DESCRIPTION, collection.Description);
            Assert.AreSame(
                Priority.GetPriority(Priority.PriorityLevel.Normal),
                collection.Priority);
            Assert.AreSame(
                Category.GetCategory(TEST_CATEGORY_NAME),
                collection.Category);
        }

        [TestMethod]
        public void TestCase3()
        {
            Assert.IsTrue(_testUser.Collections.Count == 0);
            _testUser.AddCollection(TEST_NAME, TEST_DESCRIPTION,
                _testPriority, _testCategory);
            Assert.IsTrue(_testUser.Collections.Count == 1);
            _testUser.AddCollection(TEST_NAME, string.Empty,
                _testPriority, _testCategory);
            Assert.IsTrue(_testUser.Collections.Count == 1);

            var collection = _testUser.Collections[0];
            Assert.AreEqual(TEST_NAME, collection.Name);
            Assert.AreEqual(TEST_DESCRIPTION, collection.Description);
            Assert.AreSame(
                Priority.GetPriority(Priority.PriorityLevel.Normal),
                collection.Priority);
            Assert.AreSame(
                Category.GetCategory(TEST_CATEGORY_NAME),
                collection.Category);
        }
    }
}
