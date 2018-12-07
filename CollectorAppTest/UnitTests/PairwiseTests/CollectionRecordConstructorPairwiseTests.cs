using CollectorApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CollectorAppTest.UnitTests.PairwiseTests
{
    [TestClass]
    public class CollectionRecordConstructorPairwiseTests
    {
        private const string TEST_SET_FILE = "collection_tests.csv";

        [TestInitialize]
        public void Initialize()
        {
            Priority.LoadPriorityLevels();
            Category.LoadDefaultCategories();
        }

        [DynamicData("TestInput")]
        [DataTestMethod]
        public void CollectionRecordTest(string name, string description,
            string priorityName, string categoryName)
        {
            var priority = GetTestPriority(priorityName);
            var category = GetTestCategory(categoryName);
            var descriptionNotDefault = description.ToLower() != "default";
            var collectionRecord = descriptionNotDefault
                ? new CollectionRecord(name, description, priority, category)
                : new CollectionRecord(name, priority, category);
            Assert.IsNotNull(collectionRecord);
            Assert.AreEqual(name, collectionRecord.Name);
            Assert.AreEqual(descriptionNotDefault
                ? description
                : "No description.",
                collectionRecord.Description);
            Assert.AreSame(priority ?? Priority.GetPriority(
                Priority.PriorityLevel.Normal),
                collectionRecord.Priority);
            Assert.AreSame(category, collectionRecord.Category);
        }

        Priority GetTestPriority(string priorityName)
        {
            Priority priority;
            switch (priorityName.ToLower())
            {
                case "low":
                    priority = Priority.GetPriority(
                        Priority.PriorityLevel.Low);
                    break;
                case "normal":
                    priority = Priority.GetPriority(
                        Priority.PriorityLevel.Normal);
                    break;
                case "important":
                    priority = Priority.GetPriority(
                        Priority.PriorityLevel.Important);
                    break;
                case "critical":
                    priority = Priority.GetPriority(
                        Priority.PriorityLevel.Critical);
                    break;
                case "null":
                    priority = null;
                    break;
                default:
                    throw new FileLoadException();
            }

            return priority;
        }

        Category GetTestCategory(string category)
        {
            return category.ToLower() != "null"
                ? Category.GetCategory(category)
                : null;
        }

        public static IEnumerable<object[]> TestInput
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                var testFile = $"CollectorAppTest.Resources.PairwiseTestSets.{TEST_SET_FILE}";
                var stream = assembly.GetManifestResourceStream(testFile);
                using (var reader = new StreamReader(stream))
                {
                    var parameterNames = reader.ReadLine().Split(',').ToList();
                    if (parameterNames.Count != 4) throw new FileLoadException();
                    IEnumerable<object[]> inputs = new List<object[]>();
                    while (!reader.EndOfStream)
                    {
                        var values = reader.ReadLine().Split(',');
                        var iters = parameterNames.Count == values.Length
                            ? values.Length : 0;

                        yield return values;
                    }
                }
            }
        }
    }
}
