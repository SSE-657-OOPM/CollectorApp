using CollectorApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectorAppTest.UnitTests.DecisionTableTests
{
    [TestClass]
    public class UserAddCollectionTests
    {
        private User _testUser;
        private Priority _normalPriority;
        private const string COLLECTION_NAME = "Test Collection";
        private const string COLLECTION_DESCRIPTION = "Test Description";
        private const string DEFAULT_DESCRIPTION = "No description.";
        private const string TEST_CATEGORY_NAME = "Music";
   
        [TestInitialize]
        public void Initialize()
        {
            _testUser = new User();
            Priority.LoadPriorityLevels();
            Category.LoadDefaultCategories();
            _normalPriority = Priority.GetPriority(Priority.PriorityLevel.Normal);
        }

        [TestMethod]
        public void TestCase1()
        {
            Assert.AreEqual(0, _testUser.Collections.Count);
            _testUser.AddCollection(COLLECTION_NAME, string.Empty, null, null);
            Assert.AreEqual(1, _testUser.Collections.Count);

            var testCollection = _testUser.Collections[0];
            Assert.AreEqual(DEFAULT_DESCRIPTION, testCollection.Description);
            Assert.AreNotEqual(string.Empty, testCollection.Description);
            Assert.AreSame(_normalPriority, testCollection.Priority);
            Assert.IsNull(testCollection.Category);
        }

        [TestMethod]
        public void TestCase2()
        {
            Assert.AreEqual(0, _testUser.Collections.Count);
            _testUser.AddCollection(COLLECTION_NAME, string.Empty, null,
                Category.GetCategory(TEST_CATEGORY_NAME));
            Assert.AreEqual(1, _testUser.Collections.Count);

            var testCollection = _testUser.Collections[0];
            Assert.AreEqual(DEFAULT_DESCRIPTION, testCollection.Description);
            Assert.AreNotEqual(string.Empty, testCollection.Description);
            Assert.AreSame(_normalPriority, testCollection.Priority);
            Assert.IsNotNull(testCollection.Category);
            Assert.AreSame(Category.GetCategory(TEST_CATEGORY_NAME),
                testCollection.Category);
        }

        [TestMethod]
        public void TestCase3()
        {
            Assert.AreEqual(0, _testUser.Collections.Count);
            _testUser.AddCollection(COLLECTION_NAME, string.Empty,
                Priority.GetPriority(Priority.PriorityLevel.Critical), null);
            Assert.AreEqual(1, _testUser.Collections.Count);

            var testCollection = _testUser.Collections[0];
            Assert.AreEqual(DEFAULT_DESCRIPTION, testCollection.Description);
            Assert.AreNotEqual(string.Empty, testCollection.Description);
            Assert.AreNotSame(_normalPriority, testCollection.Priority);
            Assert.IsNull(testCollection.Category);
        }

        [TestMethod]
        public void TestCase4()
        {
            Assert.AreEqual(0, _testUser.Collections.Count);
            _testUser.AddCollection(COLLECTION_NAME, string.Empty,
                Priority.GetPriority(Priority.PriorityLevel.Critical),
                Category.GetCategory(TEST_CATEGORY_NAME));
            Assert.AreEqual(1, _testUser.Collections.Count);

            var testCollection = _testUser.Collections[0];
            Assert.AreEqual(DEFAULT_DESCRIPTION, testCollection.Description);
            Assert.AreNotEqual(string.Empty, testCollection.Description);
            Assert.AreNotSame(_normalPriority, testCollection.Priority);
            Assert.IsNotNull(testCollection.Category);
            Assert.AreSame(Category.GetCategory(TEST_CATEGORY_NAME),
                testCollection.Category);
        }

        [TestMethod]
        public void TestCase5()
        {
            Assert.AreEqual(0, _testUser.Collections.Count);
            _testUser.AddCollection(COLLECTION_NAME,
                COLLECTION_DESCRIPTION, null, null);
            Assert.AreEqual(1, _testUser.Collections.Count);

            var testCollection = _testUser.Collections[0];
            Assert.AreNotEqual(DEFAULT_DESCRIPTION, testCollection.Description);
            Assert.AreEqual(COLLECTION_DESCRIPTION, testCollection.Description);
            Assert.AreSame(_normalPriority, testCollection.Priority);
            Assert.IsNull(testCollection.Category);
        }

        [TestMethod]
        public void TestCase6()
        {
            Assert.AreEqual(0, _testUser.Collections.Count);
            _testUser.AddCollection(COLLECTION_NAME, COLLECTION_DESCRIPTION,
                null, Category.GetCategory(TEST_CATEGORY_NAME));
            Assert.AreEqual(1, _testUser.Collections.Count);

            var testCollection = _testUser.Collections[0];
            Assert.AreNotEqual(DEFAULT_DESCRIPTION, testCollection.Description);
            Assert.AreEqual(COLLECTION_DESCRIPTION, testCollection.Description);
            Assert.AreSame(_normalPriority, testCollection.Priority);
            Assert.IsNotNull(testCollection.Category);
            Assert.AreSame(Category.GetCategory(TEST_CATEGORY_NAME),
                testCollection.Category);
        }

        [TestMethod]
        public void TestCase7()
        {
            Assert.AreEqual(0, _testUser.Collections.Count);
            _testUser.AddCollection(COLLECTION_NAME, COLLECTION_DESCRIPTION,
                Priority.GetPriority(Priority.PriorityLevel.Critical), null);
            Assert.AreEqual(1, _testUser.Collections.Count);

            var testCollection = _testUser.Collections[0];
            Assert.AreNotEqual(DEFAULT_DESCRIPTION, testCollection.Description);
            Assert.AreEqual(COLLECTION_DESCRIPTION, testCollection.Description);
            Assert.AreNotSame(_normalPriority, testCollection.Priority);
            Assert.IsNull(testCollection.Category);
        }

        [TestMethod]
        public void TestCase8()
        {
            Assert.AreEqual(0, _testUser.Collections.Count);
            _testUser.AddCollection(COLLECTION_NAME, COLLECTION_DESCRIPTION,
                Priority.GetPriority(Priority.PriorityLevel.Critical),
                Category.GetCategory(TEST_CATEGORY_NAME));
            Assert.AreEqual(1, _testUser.Collections.Count);

            var testCollection = _testUser.Collections[0];
            Assert.AreNotEqual(DEFAULT_DESCRIPTION, testCollection.Description);
            Assert.AreEqual(COLLECTION_DESCRIPTION, testCollection.Description);
            Assert.AreNotSame(_normalPriority, testCollection.Priority);
            Assert.IsNotNull(testCollection.Category);
            Assert.AreSame(Category.GetCategory(TEST_CATEGORY_NAME),
                testCollection.Category);
        }

        [TestMethod]
        public void TestCase9()
        {
            Assert.AreEqual(0, _testUser.Collections.Count);
            _testUser.AddCollection(COLLECTION_NAME, string.Empty, null, null);
            Assert.AreEqual(1, _testUser.Collections.Count);
            _testUser.AddCollection(COLLECTION_NAME, COLLECTION_DESCRIPTION,
                Priority.GetPriority(Priority.PriorityLevel.Critical),
                Category.GetCategory(TEST_CATEGORY_NAME));
            Assert.AreEqual(1, _testUser.Collections.Count);

            var testCollection = _testUser.Collections[0];
            Assert.AreEqual(DEFAULT_DESCRIPTION, testCollection.Description);
            Assert.AreNotEqual(COLLECTION_DESCRIPTION, testCollection.Description);
            Assert.AreSame(_normalPriority, testCollection.Priority);
            Assert.IsNull(testCollection.Category);
        }
    }
}
