using ALG.TimeCycle;
using NUnit.Framework;
using UnityEngine;

namespace ALG.Tests.PlayMode
{
    public class DayCycleTests
    {
        private TimeDataSO timeDataSO;

        [SetUp]
        public void SetUp()
        {
            // Assuming TimeDataSO has a constructor that takes no parameters
            timeDataSO = ScriptableObject.CreateInstance<TimeDataSO>();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the ScriptableObject after each test
            Object.DestroyImmediate(timeDataSO);
        }

        [Test]
        public void Test_Initialization()
        {
            // Test that the initial values are as expected
            Assert.AreEqual(0, timeDataSO.Day);
            Assert.AreEqual(0, timeDataSO.Hours);
            Assert.AreEqual(0, timeDataSO.Minutes);
            Assert.AreEqual(0, timeDataSO.Seconds);
        }

        [Test]
        public void Test_TickSecond()
        {
            // Call TickSecond and assert the seconds increased
            timeDataSO.TickSecond();
            Assert.AreEqual(1, timeDataSO.Seconds);
        }

        [Test]
        public void Test_TickMinute()
        {
            // Call TickMinute and assert the minutes increased
            timeDataSO.TickMinute();
            Assert.AreEqual(1, timeDataSO.Minutes);
        }

        [Test]
        public void Test_TickHour()
        {
            // Call TickHour and assert the hours increased
            timeDataSO.TickHour();
            Assert.AreEqual(1, timeDataSO.Hours);
        }

        [Test]
        public void Test_TickDay()
        {
            // Call TickDay and assert the days increased
            timeDataSO.TickDay();
            Assert.AreEqual(1, timeDataSO.Day);
        }

        [Test]
        public void Test_SetTime()
        {
            // Call SetTime and assert the time is set correctly
            timeDataSO.SetTime(30, 12, 1);
            Assert.AreEqual(30, timeDataSO.Minutes);
            Assert.AreEqual(12, timeDataSO.Hours);
            Assert.AreEqual(1, timeDataSO.Day);
        }
    }
}