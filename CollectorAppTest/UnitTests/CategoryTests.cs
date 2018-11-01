using CollectorApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CollectorAppTest
{
    [TestClass]
    public class CategoryTests
    {
        // category file constants
        private const string DEFAULT_CATEGORY_RESOURCE_PATH = "./Resources/CategoryRecords.xml";
        private const string CATEGORY_XML_ELEMENT_NAME = "Category";
        private const string CATEGORY_XML_NAME_ATTRIBUTE_NAME = "Name";
        private const string CATEGORY_XML_DESCRIPTION_ELEMENT_NAME = "Description";
        private readonly XDocument testXml = XDocument.Load(DEFAULT_CATEGORY_RESOURCE_PATH);

        // test constants
        private const string NULL_CATEGORY_NAME = "Null Test Category";
        private const string DEFAULT_DESCRIPTION = "No description.";
        private const string TEST_CATEGORY_NAME = "Test Category";
        private const string TEST_CATEGORY_DESCRIPTION = "Test Description";
        private const string TEST_CATEGORY_DESCRIPTION_UPDATE = "Updated Test Description";
        private const string EXPLICIT_MUSIC_CATEGORY_NAME = "Music";
        private const string EXPLICIT_MUSIC_CATEGORY_DESCRIPTION
            = "Collections related to music";

        private Dictionary<string, string> _testCategories;

        [TestInitialize]
        public void Initialize()
        {
            Category.LoadDefaultCategories();
            _testCategories = new Dictionary<string, string>();
            foreach (var category in testXml.Descendants(CATEGORY_XML_ELEMENT_NAME))
            {
                _testCategories.Add(category.Attribute(CATEGORY_XML_NAME_ATTRIBUTE_NAME).Value.Trim(),
                    category.Element(CATEGORY_XML_DESCRIPTION_ELEMENT_NAME).Value.Trim());
            }
        }

        [TestMethod]
        public void TestXmlRead()
        {
            // quick test to ensure xml was parsed correctly - not a catch-all test - more of a sanity check
            Assert.AreEqual(_testCategories[EXPLICIT_MUSIC_CATEGORY_NAME], EXPLICIT_MUSIC_CATEGORY_DESCRIPTION);
        }

        [TestMethod]
        public void ExplicitCategoryTest()
        {
            var testCategory = Category.GetCategory(EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Name, EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Description, EXPLICIT_MUSIC_CATEGORY_DESCRIPTION);
        }

        [TestMethod]
        public void ExplicitNullCategoryTest()
        {
            var testCategory = Category.GetCategory(NULL_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Name, NULL_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Description, DEFAULT_DESCRIPTION);
        }

        [TestMethod]
        public void CreateNewCategoryTest()
        {
            Category.CreateCategory(TEST_CATEGORY_NAME, TEST_CATEGORY_DESCRIPTION);
            var testCategory = Category.GetCategory(TEST_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Name, TEST_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Description, TEST_CATEGORY_DESCRIPTION);
        }

        [TestMethod]
        public void UpdateCustomCategoryTest()
        {
            Category.CreateCategory(TEST_CATEGORY_NAME, TEST_CATEGORY_DESCRIPTION);
            Category.CreateCategory(TEST_CATEGORY_NAME, TEST_CATEGORY_DESCRIPTION_UPDATE);
            var testCategory = Category.GetCategory(TEST_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Name, TEST_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Description, TEST_CATEGORY_DESCRIPTION_UPDATE);
            Assert.AreNotEqual(testCategory.Description, TEST_CATEGORY_DESCRIPTION);
        }

        [TestMethod]
        public void UpdateDefaultCategoryTest()
        {
            Category.CreateCategory(EXPLICIT_MUSIC_CATEGORY_NAME, TEST_CATEGORY_DESCRIPTION_UPDATE);
            var testCategory = Category.GetCategory(EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Name, EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Description, EXPLICIT_MUSIC_CATEGORY_DESCRIPTION);
            Assert.AreNotEqual(testCategory.Description, TEST_CATEGORY_DESCRIPTION_UPDATE);
        }

        [TestMethod]
        public void RemoveCustomCategoryTest()
        {
            Category.CreateCategory(TEST_CATEGORY_NAME, TEST_CATEGORY_DESCRIPTION);
            Category.RemoveCategory(TEST_CATEGORY_NAME);
            var testCategory = Category.GetCategory(TEST_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Name, TEST_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Description, DEFAULT_DESCRIPTION);
            Assert.AreNotEqual(testCategory.Description, TEST_CATEGORY_DESCRIPTION);
        }

        [TestMethod]
        public void RemoveDefaultCategoryTest()
        {
            Category.RemoveCategory(EXPLICIT_MUSIC_CATEGORY_NAME);
            var testCategory = Category.GetCategory(EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Name, EXPLICIT_MUSIC_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Description, EXPLICIT_MUSIC_CATEGORY_DESCRIPTION);
            Assert.AreNotEqual(testCategory.Description, DEFAULT_DESCRIPTION);
        }

        [TestMethod]
        public void DefaultCategoryTest()
        {
            foreach (var kvp in _testCategories)
            {
                var testCategory = Category.GetCategory(kvp.Key);
                Assert.AreEqual(testCategory.Name, kvp.Key);
                Assert.AreEqual(testCategory.Description, kvp.Value);
            }
        }

        [TestMethod]
        public void LoadDefaultCategoriesTest()
        {
            Category.CreateCategory(TEST_CATEGORY_NAME, TEST_CATEGORY_DESCRIPTION);
            Category.LoadDefaultCategories();
            var testCategory = Category.GetCategory(TEST_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Name, TEST_CATEGORY_NAME);
            Assert.AreEqual(testCategory.Description, DEFAULT_DESCRIPTION);
            Assert.AreNotEqual(testCategory.Description, TEST_CATEGORY_DESCRIPTION);
        }

        [TestMethod]
        public void CategoryToStringTest()
        {
            foreach (var kvp in _testCategories)
            {
                var testCategory = Category.GetCategory(kvp.Key);
                Assert.AreEqual(testCategory.ToString(), kvp.Key);
            }
        }
    }
}
