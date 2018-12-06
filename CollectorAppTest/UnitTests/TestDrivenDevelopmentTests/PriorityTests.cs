using CollectorApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CollectorAppTest.UnitTests.TestDrivenDevelopmentTests
{
    [TestClass]
    public class PriorityTests
    {
        private Priority _testPriorityLow;
        private Priority _testPriorityNormal;
        private Priority _testPriorityImportant;
        private Priority _testPriorityCritical;

        private const string LOW_NAME = "Low";
        private const string NORMAL_NAME = "Normal";
        private const string IMPORTANT_NAME = "Important";
        private const string CRITICAL_NAME = "Critical";

        private const int NULL_PRIOIRTY_LEVEL = -1;

        [TestInitialize]
        public void Initialize()
        {
            Priority.LoadPriorityLevels();
            _testPriorityLow = Priority.GetPriority(Priority.PriorityLevel.Low);
            _testPriorityNormal = Priority.GetPriority(Priority.PriorityLevel.Normal);
            _testPriorityImportant = Priority.GetPriority(Priority.PriorityLevel.Important);
            _testPriorityCritical = Priority.GetPriority(Priority.PriorityLevel.Critical);
        }

        [TestMethod]
        public void PriorityLevelTest()
        {
            Assert.AreEqual(Enum.GetValues(typeof(Priority.PriorityLevel)).Length, 4);
            Assert.AreEqual(Priority.PriorityLevel.Low.ToString(), LOW_NAME);
            Assert.AreEqual(Priority.PriorityLevel.Normal.ToString(), NORMAL_NAME);
            Assert.AreEqual(Priority.PriorityLevel.Important.ToString(), IMPORTANT_NAME);
            Assert.AreEqual(Priority.PriorityLevel.Critical.ToString(), CRITICAL_NAME);
        }

        [TestMethod]
        public void GetPriorityEnumTest()
        {
            Assert.AreEqual(_testPriorityLow.Level, Priority.PriorityLevel.Low);
            Assert.AreEqual(_testPriorityNormal.Level, Priority.PriorityLevel.Normal);
            Assert.AreEqual(_testPriorityImportant.Level, Priority.PriorityLevel.Important);
            Assert.AreEqual(_testPriorityCritical.Level, Priority.PriorityLevel.Critical);
        }

        [TestMethod]
        public void GetPriorityIntTest()
        {
            Assert.AreEqual(_testPriorityLow.Level, Priority.PriorityLevel.Low);
            Assert.AreEqual(_testPriorityNormal.Level, Priority.PriorityLevel.Normal);
            Assert.AreEqual(_testPriorityImportant.Level, Priority.PriorityLevel.Important);
            Assert.AreEqual(_testPriorityCritical.Level, Priority.PriorityLevel.Critical);
        }

        [TestMethod]
        public void PriorityEqualsComparisonTest()
        {
            Assert.AreEqual(_testPriorityLow, Priority.GetPriority(Priority.PriorityLevel.Low));
            Assert.AreEqual(_testPriorityNormal, Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.AreEqual(_testPriorityImportant, Priority.GetPriority(Priority.PriorityLevel.Important));
            Assert.AreEqual(_testPriorityCritical, Priority.GetPriority(Priority.PriorityLevel.Critical));
            Assert.IsTrue(_testPriorityLow == Priority.GetPriority(Priority.PriorityLevel.Low));
            Assert.IsTrue(_testPriorityNormal == Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.IsTrue(_testPriorityImportant == Priority.GetPriority(Priority.PriorityLevel.Important));
            Assert.IsTrue(_testPriorityCritical == Priority.GetPriority(Priority.PriorityLevel.Critical));
            Assert.IsFalse(_testPriorityLow != Priority.GetPriority(Priority.PriorityLevel.Low));
            Assert.IsFalse(_testPriorityNormal != Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.IsFalse(_testPriorityImportant != Priority.GetPriority(Priority.PriorityLevel.Important));
            Assert.IsFalse(_testPriorityCritical != Priority.GetPriority(Priority.PriorityLevel.Critical));
            Assert.AreNotEqual(_testPriorityLow, Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.AreNotEqual(_testPriorityNormal, Priority.GetPriority(Priority.PriorityLevel.Important));
            Assert.AreNotEqual(_testPriorityImportant, Priority.GetPriority(Priority.PriorityLevel.Critical));
            Assert.AreNotEqual(_testPriorityCritical, Priority.GetPriority(Priority.PriorityLevel.Low));
            Assert.IsFalse(_testPriorityLow == Priority.GetPriority(Priority.PriorityLevel.Critical));
            Assert.IsFalse(_testPriorityNormal == Priority.GetPriority(Priority.PriorityLevel.Important));
            Assert.IsFalse(_testPriorityImportant == Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.IsFalse(_testPriorityCritical == Priority.GetPriority(Priority.PriorityLevel.Low));
            Assert.IsTrue(_testPriorityLow != Priority.GetPriority(Priority.PriorityLevel.Important));
            Assert.IsTrue(_testPriorityNormal != Priority.GetPriority(Priority.PriorityLevel.Critical));
            Assert.IsTrue(_testPriorityImportant != Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.IsTrue(_testPriorityCritical != Priority.GetPriority(Priority.PriorityLevel.Low));
        }

        [TestMethod]
        public void PriorityGreaterThanLessThanComparisonTest()
        {
            Assert.IsFalse(_testPriorityLow < Priority.GetPriority(Priority.PriorityLevel.Low));
            Assert.IsFalse(_testPriorityNormal > Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.IsFalse(_testPriorityImportant < Priority.GetPriority(Priority.PriorityLevel.Important));
            Assert.IsFalse(_testPriorityCritical > Priority.GetPriority(Priority.PriorityLevel.Critical));
            Assert.IsFalse(_testPriorityLow > Priority.GetPriority(Priority.PriorityLevel.Low));
            Assert.IsFalse(_testPriorityNormal < Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.IsFalse(_testPriorityImportant > Priority.GetPriority(Priority.PriorityLevel.Important));
            Assert.IsFalse(_testPriorityCritical < Priority.GetPriority(Priority.PriorityLevel.Critical));
            Assert.IsTrue(_testPriorityLow < Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.IsTrue(_testPriorityNormal < Priority.GetPriority(Priority.PriorityLevel.Important));
            Assert.IsTrue(_testPriorityImportant < Priority.GetPriority(Priority.PriorityLevel.Critical));
            Assert.IsTrue(_testPriorityCritical > Priority.GetPriority(Priority.PriorityLevel.Low));
            Assert.IsFalse(_testPriorityLow > Priority.GetPriority(Priority.PriorityLevel.Critical));
            Assert.IsFalse(_testPriorityNormal > Priority.GetPriority(Priority.PriorityLevel.Important));
            Assert.IsFalse(_testPriorityImportant < Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.IsFalse(_testPriorityCritical < Priority.GetPriority(Priority.PriorityLevel.Low));
            Assert.IsFalse(_testPriorityLow > Priority.GetPriority(Priority.PriorityLevel.Important));
            Assert.IsFalse(_testPriorityNormal > Priority.GetPriority(Priority.PriorityLevel.Critical));
            Assert.IsFalse(_testPriorityImportant < Priority.GetPriority(Priority.PriorityLevel.Normal));
            Assert.IsFalse(_testPriorityCritical < Priority.GetPriority(Priority.PriorityLevel.Low));
        }

        [TestMethod]
        public void PriorityToStringTest()
        {
            Assert.AreEqual(_testPriorityLow.ToString(), LOW_NAME);
            Assert.AreEqual(_testPriorityNormal.ToString(), NORMAL_NAME);
            Assert.AreEqual(_testPriorityImportant.ToString(), IMPORTANT_NAME);
            Assert.AreEqual(_testPriorityCritical.ToString(), CRITICAL_NAME);
            Assert.AreEqual(_testPriorityLow.ToString(), Priority.PriorityLevel.Low.ToString());
            Assert.AreEqual(_testPriorityNormal.ToString(), Priority.PriorityLevel.Normal.ToString());
            Assert.AreEqual(_testPriorityImportant.ToString(), Priority.PriorityLevel.Important.ToString());
            Assert.AreEqual(_testPriorityCritical.ToString(), Priority.PriorityLevel.Critical.ToString());
        }

        [TestMethod]
        public void PriorityHashCodeTest()
        {
            Assert.AreEqual(_testPriorityLow.GetHashCode(), Priority.PriorityLevel.Low.ToString()[0]);
            Assert.AreEqual(_testPriorityNormal.GetHashCode(), Priority.PriorityLevel.Normal.ToString()[0]);
            Assert.AreEqual(_testPriorityImportant.GetHashCode(), Priority.PriorityLevel.Important.ToString()[0]);
            Assert.AreEqual(_testPriorityCritical.GetHashCode(), Priority.PriorityLevel.Critical.ToString()[0]);
        }

        [TestMethod]
        public void PriorityNotNullTest()
        {
            Assert.IsNotNull(_testPriorityLow);
            Assert.IsNotNull(_testPriorityNormal);
            Assert.IsNotNull(_testPriorityImportant);
            Assert.IsNotNull(_testPriorityCritical);
            Assert.IsNotNull(Priority.GetPriority(0));
            Assert.IsNotNull(Priority.GetPriority(1));
            Assert.IsNotNull(Priority.GetPriority(2));
            Assert.IsNotNull(Priority.GetPriority(3));
        }

        [TestMethod]
        public void PriorityNullTest()
        {
            Assert.IsNull(Priority.GetPriority(NULL_PRIOIRTY_LEVEL));
        }
    }
}
