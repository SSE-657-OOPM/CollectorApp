using CollectorApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using System.Linq;

namespace CollectorAppTest
{
    [TestClass]
    public class CollectionRecordTests
    {
        private const string TEST_COLLECTION_NAME = "Test Collection";
        private const string UPDATED_TEST_COLLECTION_NAME = "Updated Test Collection";
        private const string DEFAULT_COLLECTION_DESCRIPTION = "No description.";
        private const string TEST_COLLECTION_DESCRIPTION = "Test collection description.";
        private const string UPDATED_TEST_COLLECTION_DESCRIPTION = "Updated test collection description.";
        private const string TEST_ITEM_NAME = "Test Item";
        private const string UPDATED_TEST_ITEM_NAME = "Updated Test Item";
        private const string MUSIC_CATEGORY_NAME = "Music";
        private const string UPDATED_CATEGORY_NAME = "Books";
        private Priority _testCollectionPriority;
        private Category _testCollectionCategory;
        private CollectionRecord _testCollection;

        [TestInitialize]
        public void Initialize()
        {
            Priority.LoadPriorityLevels();
            Category.LoadDefaultCategories();
            _testCollectionPriority = Priority.GetPriority(Priority.PriorityLevel.Normal);
            _testCollectionCategory = Category.GetCategory(MUSIC_CATEGORY_NAME);
            _testCollection = new CollectionRecord(TEST_COLLECTION_NAME,
                TEST_COLLECTION_DESCRIPTION, _testCollectionPriority,
                _testCollectionCategory);
        }

        [TestMethod]
        public void CollectionPropertiesTest()
        {
            Assert.AreEqual(_testCollection.Name, TEST_COLLECTION_NAME);
            Assert.AreEqual(_testCollection.Description, TEST_COLLECTION_DESCRIPTION);
            Assert.AreEqual(_testCollection.Priority, _testCollectionPriority);
            Assert.AreEqual(_testCollection.Category, _testCollectionCategory);
        }

        [TestMethod]
        public void CollectionConstructorTest()
        {
            var testCollection = new CollectionRecord(TEST_COLLECTION_NAME, _testCollectionPriority);
            Assert.AreEqual(testCollection.Name, TEST_COLLECTION_NAME);
            Assert.AreEqual(testCollection.Description, DEFAULT_COLLECTION_DESCRIPTION);
            Assert.AreEqual(testCollection.Priority, _testCollectionPriority);
            Assert.IsNull(testCollection.Category);
            testCollection = new CollectionRecord(TEST_COLLECTION_NAME, _testCollectionPriority, _testCollectionCategory);
            Assert.AreEqual(testCollection.Name, TEST_COLLECTION_NAME);
            Assert.AreEqual(testCollection.Description, DEFAULT_COLLECTION_DESCRIPTION);
            Assert.AreEqual(testCollection.Priority, _testCollectionPriority);
            Assert.AreEqual(testCollection.Priority, _testCollectionPriority);
            testCollection = new CollectionRecord(TEST_COLLECTION_NAME, TEST_COLLECTION_DESCRIPTION, _testCollectionPriority);
            Assert.AreEqual(testCollection.Name, TEST_COLLECTION_NAME);
            Assert.AreEqual(testCollection.Description, TEST_COLLECTION_DESCRIPTION);
            Assert.AreEqual(testCollection.Priority, _testCollectionPriority);
            Assert.IsNull(testCollection.Category);
            testCollection = new CollectionRecord(TEST_COLLECTION_NAME, TEST_COLLECTION_DESCRIPTION, _testCollectionPriority, _testCollectionCategory);
            Assert.AreEqual(testCollection.Name, TEST_COLLECTION_NAME);
            Assert.AreEqual(testCollection.Description, TEST_COLLECTION_DESCRIPTION);
            Assert.AreEqual(testCollection.Priority, _testCollectionPriority);
            Assert.AreEqual(testCollection.Priority, _testCollectionPriority);
        }

        [TestMethod]
        public void CollectionUpdateTest()
        {
            var newPriority = Priority.GetPriority(Priority.PriorityLevel.Important);
            var newCategory = Category.GetCategory(UPDATED_CATEGORY_NAME);
            _testCollection.Update(UPDATED_TEST_COLLECTION_NAME,
                UPDATED_TEST_COLLECTION_DESCRIPTION, newPriority,
                newCategory);
            Assert.AreNotEqual(_testCollection.Name, TEST_COLLECTION_NAME);
            Assert.AreNotEqual(_testCollection.Description, TEST_COLLECTION_DESCRIPTION);
            Assert.AreNotEqual(_testCollection.Priority, _testCollectionPriority);
            Assert.AreNotEqual(_testCollection.Category, _testCollectionCategory);
            Assert.AreEqual(_testCollection.Name, UPDATED_TEST_COLLECTION_NAME);
            Assert.AreEqual(_testCollection.Description, UPDATED_TEST_COLLECTION_DESCRIPTION);
            Assert.AreEqual(_testCollection.Priority, newPriority);
            Assert.AreEqual(_testCollection.Category, newCategory);
        }

        [TestMethod]
        public void CollectionItemsTest()
        {
            Assert.IsNotNull(_testCollection.Items);
            Assert.IsInstanceOfType(_testCollection.Items, typeof(ObservableCollection<ItemRecord>));
        }

        [TestMethod]
        public void AddItemCollectionTest()
        {
            Assert.IsTrue(_testCollection.Items.Count == 0);
            var initialItemPriority = Priority.GetPriority(Priority.PriorityLevel.Critical);
            _testCollection.AddItem(TEST_ITEM_NAME, initialItemPriority);
            Assert.IsTrue(_testCollection.Items.Count == 1);
            Assert.AreEqual(TEST_ITEM_NAME, _testCollection.Items.First().Name);
            Assert.AreEqual(initialItemPriority, _testCollection.Items.First().Priority);
            var newItemPriority = Priority.GetPriority(Priority.PriorityLevel.Low);
            _testCollection.AddItem(TEST_ITEM_NAME, newItemPriority);
            Assert.IsTrue(_testCollection.Items.Count == 1);
            Assert.AreEqual(TEST_ITEM_NAME, _testCollection.Items.First().Name);
            Assert.AreEqual(initialItemPriority, _testCollection.Items.First().Priority);
            Assert.AreNotEqual(newItemPriority, _testCollection.Items.First().Priority);
        }

        [TestMethod]
        public void DeleteItemCollectionTest()
        {
            Assert.IsTrue(_testCollection.Items.Count == 0);
            _testCollection.AddItem(TEST_ITEM_NAME, Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.IsTrue(_testCollection.Items.Count == 1);
            _testCollection.DeleteItem(_testCollection.Items.First());
            Assert.IsTrue(_testCollection.Items.Count == 0);
        }

        [TestMethod]
        public void UpdateItemCollectionTest()
        {
            var initialItemPriority = Priority.GetPriority(Priority.PriorityLevel.Critical);
            _testCollection.UpdateItem(_testCollection.Items.FirstOrDefault(), UPDATED_TEST_ITEM_NAME, initialItemPriority);
            Assert.IsTrue(_testCollection.Items.Count == 0);
            _testCollection.AddItem(TEST_ITEM_NAME, initialItemPriority);
            var newItemPriority = Priority.GetPriority(Priority.PriorityLevel.Low);
            _testCollection.UpdateItem(_testCollection.Items.First(), UPDATED_TEST_ITEM_NAME, newItemPriority);
            Assert.AreEqual(_testCollection.Items.First().Name, UPDATED_TEST_ITEM_NAME);
            Assert.AreEqual(_testCollection.Items.First().Priority, newItemPriority);
            Assert.AreNotEqual(_testCollection.Items.First().Name, TEST_ITEM_NAME);
            Assert.AreNotEqual(_testCollection.Items.First().Priority, initialItemPriority);
        }

        [TestMethod]
        public void SortItemsCollectionTest()
        {
            var testItemOneName = "Zebra";
            var testItemTwoName = "Ant";
            var testItemThreeName = "Cow";
            var testItemOnePriority = Priority.GetPriority(Priority.PriorityLevel.Normal);
            var testItemTwoPriority = Priority.GetPriority(Priority.PriorityLevel.Critical);
            var testItemThreePriority = Priority.GetPriority(Priority.PriorityLevel.Low);
            var testItemOne = new ItemRecord(testItemOneName, testItemOnePriority);
            var testItemTwo = new ItemRecord(testItemTwoName, testItemTwoPriority);
            var testItemThree = new ItemRecord(testItemThreeName, testItemThreePriority);
            _testCollection.AddItem(testItemOneName, testItemOnePriority);
            _testCollection.AddItem(testItemTwoName, testItemTwoPriority);
            _testCollection.AddItem(testItemThreeName, testItemThreePriority);
            Assert.AreEqual(_testCollection.Items.ElementAt(0).Name, testItemOne.Name);
            Assert.AreEqual(_testCollection.Items.ElementAt(1).Name, testItemTwo.Name);
            Assert.AreEqual(_testCollection.Items.ElementAt(2).Name, testItemThree.Name);
            _testCollection.SortItems(Record.SortParameter.Priority); // by priority
            Assert.AreNotEqual(_testCollection.Items.ElementAt(0).Name, testItemOne.Name);
            Assert.AreNotEqual(_testCollection.Items.ElementAt(1).Name, testItemTwo.Name);
            Assert.AreEqual(_testCollection.Items.ElementAt(0).Name, testItemTwo.Name);
            Assert.AreEqual(_testCollection.Items.ElementAt(1).Name, testItemOne.Name);
            Assert.AreEqual(_testCollection.Items.ElementAt(2).Name, testItemThree.Name);
            _testCollection.SortItems(Record.SortParameter.Name); // by name
            Assert.AreNotEqual(_testCollection.Items.ElementAt(1).Name, testItemOne.Name);
            Assert.AreNotEqual(_testCollection.Items.ElementAt(2).Name, testItemThree.Name);
            Assert.AreEqual(_testCollection.Items.ElementAt(0).Name, testItemTwo.Name);
            Assert.AreEqual(_testCollection.Items.ElementAt(1).Name, testItemThree.Name);
            Assert.AreEqual(_testCollection.Items.ElementAt(2).Name, testItemOne.Name);
        }

        [TestMethod]
        public void SearchItemsCollectionTest()
        {
            var searchWord = "Tim";
            var testItemOneName = "Sometimes";
            var testItemTwoName = "Time";
            var testItemThreeName = "Week";
            var testItemPriority = Priority.GetPriority(Priority.PriorityLevel.Normal);
            _testCollection.AddItem(testItemOneName, testItemPriority);
            _testCollection.AddItem(testItemTwoName, testItemPriority);
            _testCollection.AddItem(testItemThreeName, testItemPriority);
            var matchingItems = _testCollection.SearchItems(searchWord);
            Assert.IsTrue(matchingItems.Any(i => i.Name == testItemOneName));
            Assert.IsTrue(matchingItems.Any(i => i.Name == testItemTwoName));
            Assert.IsFalse(matchingItems.Any(i => i.Name == testItemThreeName));
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual(_testCollection.ToString(), TEST_COLLECTION_NAME);
        }
    }
}
