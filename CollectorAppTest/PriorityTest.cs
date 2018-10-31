using CollectorApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CollectorAppTest
{
    [TestClass]
    public class PriorityTest
    {
        [TestInitialize]
        public void Initialize()
        {
            // anything needed before each test (common code among all tests)
        }

        [TestCleanup]
        public void Cleanup()
        {
            // anything needed after each test (common code among all tests)
        }

        [TestMethod]
        public void TestPriorityLevelZero()
        {
            var testPriorityLevel = 0;
            var testPriority = new Priority(testPriorityLevel);
            Assert.AreEqual((Priority.PriorityLevel)testPriorityLevel, testPriority.Level);
            Assert.AreEqual(Priority.PriorityLevel.Low, testPriority.Level);
        }

        [TestMethod]
        public void TestPriorityLevelOne()
        {
            var testPriorityLevel = 1;
            var testPriority = new Priority(testPriorityLevel);
            Assert.AreEqual((Priority.PriorityLevel)testPriorityLevel, testPriority.Level);
            Assert.AreEqual(Priority.PriorityLevel.Normal, testPriority.Level);
        }

        [TestMethod]
        public void TestPriorityLevelTwo()
        {
            var testPriorityLevel = 2;
            var testPriority = new Priority(testPriorityLevel);
            Assert.AreEqual((Priority.PriorityLevel)testPriorityLevel, testPriority.Level);
            Assert.AreEqual(Priority.PriorityLevel.Important, testPriority.Level);
        }

        [TestMethod]
        public void TestPriorityLevelThree()
        {
            var testPriorityLevel = 3;
            var testPriority = new Priority(testPriorityLevel);
            Assert.AreEqual((Priority.PriorityLevel)testPriorityLevel, testPriority.Level);
            Assert.AreEqual(Priority.PriorityLevel.Critical, testPriority.Level);
        }
    }
}
