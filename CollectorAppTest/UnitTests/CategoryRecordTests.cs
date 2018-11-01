using CollectorApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CollectorAppTest
{
    [TestClass]
    public class CategoryRecordTests
    {
        // category file constants
        private const string DEFAULT_CATEGORY_RESOURCE_PATH = "./Resources/CategoryRecords.xml";
        private const string CATEGORY_RECORD_XML_ELEMENT_NAME = "CategoryRecord";
        private const string CATEGORY_RECORD_XML_NAME_ATTRIBUTE_NAME = "Name";
        private const string CATEGORY_RECORD_XML_DESCRIPTION_ELEMENT_NAME = "Description";
        private readonly XDocument testXml = XDocument.Load(DEFAULT_CATEGORY_RESOURCE_PATH);

        // test constants
        private const string NULL_CATEGORY_RECORD_NAME = "Null Test Category";
        private const string DEFAULT_DESCRIPTION = "No description.";
        private const string TEST_CATEGORY_RECORD_NAME = "Test Category";
        private const string TEST_CATEGORY_RECORD_DESCRIPTION = "Test Description";
        private const string TEST_CATEGORY_RECORD_DESCRIPTION_UPDATE = "Updated Test Description";
        private const string EXPLICIT_MUSIC_CATEGORY_NAME = "Music";
        private const string EXPLICIT_MUSIC_CATEGORY_DESCRIPTION
            = "Collections related to music";

        private Dictionary<string, string> _testCategoryRecords;

        [TestInitialize]
        public void Initialize()
        {
            CategoryRecord.LoadDefaultCategoryRecords();
            _testCategoryRecords = new Dictionary<string, string>();
            foreach (var category in testXml.Descendants(CATEGORY_RECORD_XML_ELEMENT_NAME))
            {
                _testCategoryRecords.Add(category.Attribute(CATEGORY_RECORD_XML_NAME_ATTRIBUTE_NAME).Value.Trim(),
                    category.Element(CATEGORY_RECORD_XML_DESCRIPTION_ELEMENT_NAME).Value.Trim());
            }
        }

        [TestMethod]
        public void TestXmlRead()
        {
            // quick test to ensure xml was parsed correctly - not a catch-all test - more of a sanity check
            Assert.AreEqual(_testCategoryRecords[EXPLICIT_MUSIC_CATEGORY_NAME], EXPLICIT_MUSIC_CATEGORY_DESCRIPTION);
        }

        [TestMethod]
        public void ExplicitCategoryRecordTest()
        {
            var testCategoryRecord = CategoryRecord.GetCategoryRecord(EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategoryRecord.Name, EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategoryRecord.Description, EXPLICIT_MUSIC_CATEGORY_DESCRIPTION);
        }

        [TestMethod]
        public void ExplicitNullCategoryRecordTest()
        {
            var testCategoryRecord = CategoryRecord.GetCategoryRecord(NULL_CATEGORY_RECORD_NAME);
            Assert.AreEqual(testCategoryRecord.Name, NULL_CATEGORY_RECORD_NAME);
            Assert.AreEqual(testCategoryRecord.Description, DEFAULT_DESCRIPTION);
        }

        [TestMethod]
        public void CreateNewCategoryTest()
        {
            CategoryRecord.CreateCategoryRecord(TEST_CATEGORY_RECORD_NAME, TEST_CATEGORY_RECORD_DESCRIPTION);
            var testCategoryRecord = CategoryRecord.GetCategoryRecord(TEST_CATEGORY_RECORD_NAME);
            Assert.AreEqual(testCategoryRecord.Name, TEST_CATEGORY_RECORD_NAME);
            Assert.AreEqual(testCategoryRecord.Description, TEST_CATEGORY_RECORD_DESCRIPTION);
        }

        [TestMethod]
        public void UpdateCustomCategoryTest()
        {
            CategoryRecord.CreateCategoryRecord(TEST_CATEGORY_RECORD_NAME, TEST_CATEGORY_RECORD_DESCRIPTION);
            CategoryRecord.CreateCategoryRecord(TEST_CATEGORY_RECORD_NAME, TEST_CATEGORY_RECORD_DESCRIPTION_UPDATE);
            var testCategoryRecord = CategoryRecord.GetCategoryRecord(TEST_CATEGORY_RECORD_NAME);
            Assert.AreEqual(testCategoryRecord.Name, TEST_CATEGORY_RECORD_NAME);
            Assert.AreEqual(testCategoryRecord.Description, TEST_CATEGORY_RECORD_DESCRIPTION_UPDATE);
            Assert.AreNotEqual(testCategoryRecord.Description, TEST_CATEGORY_RECORD_DESCRIPTION);
        }

        [TestMethod]
        public void UpdateDefaultCategoryTest()
        {
            CategoryRecord.CreateCategoryRecord(EXPLICIT_MUSIC_CATEGORY_NAME, TEST_CATEGORY_RECORD_DESCRIPTION_UPDATE);
            var testCategoryRecord = CategoryRecord.GetCategoryRecord(EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategoryRecord.Name, EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategoryRecord.Description, EXPLICIT_MUSIC_CATEGORY_DESCRIPTION);
            Assert.AreNotEqual(testCategoryRecord.Description, TEST_CATEGORY_RECORD_DESCRIPTION_UPDATE);
        }

        [TestMethod]
        public void RemoveCustomCategoryTest()
        {
            CategoryRecord.CreateCategoryRecord(TEST_CATEGORY_RECORD_NAME, TEST_CATEGORY_RECORD_DESCRIPTION);
            CategoryRecord.RemoveCategoryRecord(TEST_CATEGORY_RECORD_NAME);
            var testCategoryRecord = CategoryRecord.GetCategoryRecord(TEST_CATEGORY_RECORD_NAME);
            Assert.AreEqual(testCategoryRecord.Name, TEST_CATEGORY_RECORD_NAME);
            Assert.AreEqual(testCategoryRecord.Description, DEFAULT_DESCRIPTION);
            Assert.AreNotEqual(testCategoryRecord.Description, TEST_CATEGORY_RECORD_DESCRIPTION);
        }

        [TestMethod]
        public void RemoveDefaultCategoryTest()
        {
            CategoryRecord.RemoveCategoryRecord(EXPLICIT_MUSIC_CATEGORY_NAME);
            var testCategoryRecord = CategoryRecord.GetCategoryRecord(EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategoryRecord.Name, EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategoryRecord.Description, EXPLICIT_MUSIC_CATEGORY_DESCRIPTION);
            Assert.AreNotEqual(testCategoryRecord.Description, DEFAULT_DESCRIPTION);
        }

        [TestMethod]
        public void DefaultCategoryTest()
        {
            foreach (var kvp in _testCategoryRecords)
            {
                var testCategoryRecord = CategoryRecord.GetCategoryRecord(kvp.Key);
                Assert.AreEqual(testCategoryRecord.Name, kvp.Key);
                Assert.AreEqual(testCategoryRecord.Description, kvp.Value);
            }
        }

        [TestMethod]
        public void LoadDefaultCategoriesTest()
        {
            CategoryRecord.CreateCategoryRecord(TEST_CATEGORY_RECORD_NAME, TEST_CATEGORY_RECORD_DESCRIPTION);
            CategoryRecord.LoadDefaultCategoryRecords();
            var testCategoryRecord = CategoryRecord.GetCategoryRecord(TEST_CATEGORY_RECORD_NAME);
            Assert.AreEqual(testCategoryRecord.Name, TEST_CATEGORY_RECORD_NAME);
            Assert.AreEqual(testCategoryRecord.Description, DEFAULT_DESCRIPTION);
            Assert.AreNotEqual(testCategoryRecord.Description, TEST_CATEGORY_RECORD_DESCRIPTION);
        }

        [TestMethod]
        public void CategoryRecordToStringTest()
        {
            foreach (var kvp in _testCategoryRecords)
            {
                var testCategoryRecord = CategoryRecord.GetCategoryRecord(kvp.Key);
                Assert.AreEqual(testCategoryRecord.ToString(), kvp.Key);
            }
        }
    }
}
