using CollectorApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectorAppTest
{
    [TestClass]
    public class ItemRecordTests
    {
        private const string TEST_ITEM_NAME = "Test Item";
        private const string UPDATED_TEST_ITEM_NAME = "Updated Test Item";
        private Priority _testItemPriority;
        private ItemRecord _testItem;

        [TestInitialize]
        public void Initialize()
        {
            Priority.LoadPriorityLevels();
            _testItemPriority = Priority.GetPriority(Priority.PriorityLevel.Normal);
            _testItem = new ItemRecord(TEST_ITEM_NAME, _testItemPriority);
        }

        [TestMethod]
        public void ItemPropertiesTest()
        {
            Assert.AreEqual(_testItem.Name, TEST_ITEM_NAME);
            Assert.AreEqual(_testItem.Priority, _testItemPriority);
            Assert.IsFalse(_testItem.IsCollected);
        }

        [TestMethod]
        public void UpdateItemTest()
        {
            var updatedTestItemPriority = Priority.GetPriority(Priority.PriorityLevel.Critical);
            _testItem.Update(UPDATED_TEST_ITEM_NAME, updatedTestItemPriority);
            Assert.AreEqual(_testItem.Name, UPDATED_TEST_ITEM_NAME);
            Assert.AreEqual(_testItem.Priority, updatedTestItemPriority);
            Assert.IsFalse(_testItem.IsCollected);
        }

        [TestMethod]
        public void ItemToStringTest()
        {
            Assert.AreEqual(_testItem.ToString(), TEST_ITEM_NAME);
        }
    }
}
