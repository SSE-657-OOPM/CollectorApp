using CollectorApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CollectorAppTest.UnitTests.TestDrivenDevelopmentTests
{
    [TestClass]
    public class UserTests
    {
        private const string TEST_USERNAME = "Test User";
        private const string TEST_COLLECTION_NAME = "Test Collection";
        private const string UPDATED_TEST_COLLECTION_NAME = "Updated Test Collection";
        private const string DEFAULT_COLLECTION_DESCRIPTION = "No description.";
        private const string TEST_COLLECTION_DESCRIPTION = "Test collection description.";
        private const string UPDATED_TEST_COLLECTION_DESCRIPTION = "Updated test collection description.";
        private const string MUSIC_CATEGORY_NAME = "Music";
        private const string UPDATED_CATEGORY_NAME = "Books";
        private User _testUser;

        [TestInitialize]
        public void Initialize()
        {
            Priority.LoadPriorityLevels();
            Category.LoadDefaultCategories();
            _testUser = new User
            {
                Name = TEST_USERNAME
            };
        }

        [TestMethod]
        public void CollectionConstructorAndPropertiesTest()
        {
            Assert.AreEqual(_testUser.Name, TEST_USERNAME);
            Assert.IsNotNull(_testUser.Collections);
        }

        [TestMethod]
        public void AddCollectionUserTest()
        {
            Assert.IsTrue(_testUser.Collections.Count == 0);
            var initialCollectionPriority = Priority.GetPriority(Priority.PriorityLevel.Critical);
            var initialCollectionCategory = Category.GetCategory(MUSIC_CATEGORY_NAME);
            _testUser.AddCollection(TEST_COLLECTION_NAME, string.Empty, initialCollectionPriority, initialCollectionCategory);
            Assert.IsTrue(_testUser.Collections.Count == 1);
            Assert.AreEqual(TEST_COLLECTION_NAME, _testUser.Collections.First().Name);
            Assert.AreEqual(DEFAULT_COLLECTION_DESCRIPTION, _testUser.Collections.First().Description);
            Assert.AreEqual(initialCollectionPriority, _testUser.Collections.First().Priority);
            Assert.AreEqual(initialCollectionCategory, _testUser.Collections.First().Category);
            var newCollectionPriority = Priority.GetPriority(Priority.PriorityLevel.Low);
            var newCollectionCategory = Category.GetCategory(UPDATED_CATEGORY_NAME);
            _testUser.AddCollection(TEST_COLLECTION_NAME, TEST_COLLECTION_DESCRIPTION, newCollectionPriority, newCollectionCategory);
            Assert.IsTrue(_testUser.Collections.Count == 1);
            Assert.AreEqual(TEST_COLLECTION_NAME, _testUser.Collections.First().Name);
            Assert.AreEqual(DEFAULT_COLLECTION_DESCRIPTION, _testUser.Collections.First().Description);
            Assert.AreEqual(initialCollectionPriority, _testUser.Collections.First().Priority);
            Assert.AreEqual(initialCollectionCategory, _testUser.Collections.First().Category);
            Assert.AreNotEqual(TEST_COLLECTION_DESCRIPTION, _testUser.Collections.First().Description);
            Assert.AreNotEqual(newCollectionPriority, _testUser.Collections.First().Priority);
            Assert.AreNotEqual(newCollectionCategory, _testUser.Collections.First().Category);
            _testUser.AddCollection(UPDATED_TEST_COLLECTION_NAME, TEST_COLLECTION_DESCRIPTION, initialCollectionPriority, initialCollectionCategory);
            Assert.IsTrue(_testUser.Collections.Count == 2);
            Assert.AreEqual(UPDATED_TEST_COLLECTION_NAME, _testUser.Collections.Last().Name);
            Assert.AreEqual(TEST_COLLECTION_DESCRIPTION, _testUser.Collections.Last().Description);
            Assert.AreEqual(initialCollectionPriority, _testUser.Collections.Last().Priority);
            Assert.AreEqual(initialCollectionCategory, _testUser.Collections.Last().Category);
            _testUser.AddCollection(UPDATED_TEST_COLLECTION_NAME, UPDATED_TEST_COLLECTION_DESCRIPTION, newCollectionPriority, newCollectionCategory);
            Assert.IsTrue(_testUser.Collections.Count == 2);
            Assert.AreEqual(UPDATED_TEST_COLLECTION_NAME, _testUser.Collections.Last().Name);
            Assert.AreEqual(TEST_COLLECTION_DESCRIPTION, _testUser.Collections.Last().Description);
            Assert.AreEqual(initialCollectionPriority, _testUser.Collections.Last().Priority);
            Assert.AreEqual(initialCollectionCategory, _testUser.Collections.Last().Category);
            Assert.AreNotEqual(UPDATED_TEST_COLLECTION_DESCRIPTION, _testUser.Collections.Last().Description);
            Assert.AreNotEqual(newCollectionPriority, _testUser.Collections.Last().Priority);
            Assert.AreNotEqual(newCollectionCategory, _testUser.Collections.Last().Category);
        }

        [TestMethod]
        public void DeleteCollectionUserTest()
        {
            Assert.IsTrue(_testUser.Collections.Count == 0);
            _testUser.AddCollection(TEST_COLLECTION_NAME, string.Empty, null, null);
            Assert.IsTrue(_testUser.Collections.Count == 1);
            _testUser.DeleteCollection(_testUser.Collections.First());
            Assert.IsTrue(_testUser.Collections.Count == 0);
        }

        [TestMethod]
        public void UpdateCollectionTest()
        {
            var initialCollectionPriority = Priority.GetPriority(Priority.PriorityLevel.Critical);
            var initialCollectionCategory = Category.GetCategory(MUSIC_CATEGORY_NAME);
            _testUser.UpdateCollection(_testUser.Collections.FirstOrDefault(),
                UPDATED_TEST_COLLECTION_NAME, UPDATED_TEST_COLLECTION_DESCRIPTION,
                initialCollectionPriority, initialCollectionCategory);
            Assert.IsTrue(_testUser.Collections.Count == 0);
            _testUser.AddCollection(TEST_COLLECTION_NAME, TEST_COLLECTION_DESCRIPTION,
                initialCollectionPriority, initialCollectionCategory);
            var newCollectionPriority = Priority.GetPriority(Priority.PriorityLevel.Low);
            var newCollectionCategory = Category.GetCategory(UPDATED_CATEGORY_NAME);
            _testUser.UpdateCollection(_testUser.Collections.FirstOrDefault(),
                UPDATED_TEST_COLLECTION_NAME, UPDATED_TEST_COLLECTION_DESCRIPTION,
                newCollectionPriority, newCollectionCategory);
            Assert.AreEqual(_testUser.Collections.First().Name, UPDATED_TEST_COLLECTION_NAME);
            Assert.AreEqual(_testUser.Collections.First().Description, UPDATED_TEST_COLLECTION_DESCRIPTION);
            Assert.AreEqual(_testUser.Collections.First().Priority, newCollectionPriority);
            Assert.AreEqual(_testUser.Collections.First().Category, newCollectionCategory);
            Assert.AreNotEqual(_testUser.Collections.First().Name, TEST_COLLECTION_NAME);
            Assert.AreNotEqual(_testUser.Collections.First().Description, TEST_COLLECTION_DESCRIPTION);
            Assert.AreNotEqual(_testUser.Collections.First().Priority, initialCollectionPriority);
            Assert.AreNotEqual(_testUser.Collections.First().Priority, initialCollectionCategory);
        }

        [TestMethod]
        public void SortCollectionsUserTest()
        {
            var testCollectionOneName = "Zebras";
            var testCollectionTwoName = "Ants";
            var testCollectionThreeName = "Cows";
            var testCollectionOnePriority = Priority.GetPriority(Priority.PriorityLevel.Normal);
            var testCollectionTwoPriority = Priority.GetPriority(Priority.PriorityLevel.Critical);
            var testCollectionThreePriority = Priority.GetPriority(Priority.PriorityLevel.Low);
            var testCollectionOne = new CollectionRecord(testCollectionOneName, testCollectionOnePriority);
            var testCollectionTwo = new CollectionRecord(testCollectionTwoName, testCollectionTwoPriority);
            var testCollectionThree = new CollectionRecord(testCollectionThreeName, testCollectionThreePriority);
            _testUser.AddCollection(testCollectionOneName, TEST_COLLECTION_DESCRIPTION, testCollectionOnePriority, null);
            _testUser.AddCollection(testCollectionTwoName, TEST_COLLECTION_DESCRIPTION, testCollectionTwoPriority, null);
            _testUser.AddCollection(testCollectionThreeName, TEST_COLLECTION_DESCRIPTION, testCollectionThreePriority, null);
            Assert.AreEqual(_testUser.Collections.ElementAt(0).Name, testCollectionOne.Name);
            Assert.AreEqual(_testUser.Collections.ElementAt(1).Name, testCollectionTwo.Name);
            Assert.AreEqual(_testUser.Collections.ElementAt(2).Name, testCollectionThree.Name);
            _testUser.SortCollections(Record.SortParameter.Priority); // by priority
            Assert.AreNotEqual(_testUser.Collections.ElementAt(0).Name, testCollectionOne.Name);
            Assert.AreNotEqual(_testUser.Collections.ElementAt(1).Name, testCollectionTwo.Name);
            Assert.AreEqual(_testUser.Collections.ElementAt(0).Name, testCollectionTwo.Name);
            Assert.AreEqual(_testUser.Collections.ElementAt(1).Name, testCollectionOne.Name);
            Assert.AreEqual(_testUser.Collections.ElementAt(2).Name, testCollectionThree.Name);
            _testUser.SortCollections(Record.SortParameter.Name); // by name
            Assert.AreNotEqual(_testUser.Collections.ElementAt(1).Name, testCollectionOne.Name);
            Assert.AreNotEqual(_testUser.Collections.ElementAt(2).Name, testCollectionThree.Name);
            Assert.AreEqual(_testUser.Collections.ElementAt(0).Name, testCollectionTwo.Name);
            Assert.AreEqual(_testUser.Collections.ElementAt(1).Name, testCollectionThree.Name);
            Assert.AreEqual(_testUser.Collections.ElementAt(2).Name, testCollectionOne.Name);
        }

        [TestMethod]
        public void SearchCollectionsUserTest()
        {
            var searchWord = "Tim";
            var testCollectionOneName = "Sometimes";
            var testCollectionTwoName = "Time";
            var testCollectionThreeName = "Week";
            var testCollectionPriority = Priority.GetPriority(Priority.PriorityLevel.Normal);
            _testUser.AddCollection(testCollectionOneName, string.Empty, null, null);
            _testUser.AddCollection(testCollectionTwoName, string.Empty, null, null);
            _testUser.AddCollection(testCollectionThreeName, string.Empty, null, null);
            var matchingCollections = _testUser.SearchCollections(searchWord);
            Assert.IsTrue(matchingCollections.Any(i => i.Name == testCollectionOneName));
            Assert.IsTrue(matchingCollections.Any(i => i.Name == testCollectionTwoName));
            Assert.IsFalse(matchingCollections.Any(i => i.Name == testCollectionThreeName));
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual(_testUser.ToString(), TEST_USERNAME);
        }
    }
}
