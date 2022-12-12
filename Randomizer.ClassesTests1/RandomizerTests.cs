using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Randomizer.Classes.Tests
{
    [TestClass]
    public class RandomizerTests
    {
        [TestMethod]
        public void GetRandomDateTest()
        {
            DateTime owo = Randomizer.GetRandomDate();
            Console.Write(owo);
            Assert.IsNotNull(owo);
        }

        [TestMethod]
        public void GetRandomDateWithStartTest()
        {
            DateTime owo = Randomizer.GetRandomDate(new DateTime(2000, 10, 4));
            Console.Write(owo);
            Assert.IsNotNull(owo);
        }

        [TestMethod]
        public void GetRandomDateWithStartAndEndTest()
        {
            DateTime owo = Randomizer.GetRandomDate(new DateTime(2000, 10, 4), new DateTime(2010, 9, 2));
            Console.Write(owo);
            Assert.IsNotNull(owo);
        }

        [TestMethod]
        public void GetRandomIntTest()
        {
            int owo = Randomizer.GetRandomInt(false);
            Assert.IsTrue(owo > 0);
        }

        [TestMethod]
        public void getRandomNegativeTest()
        {
            int owo = Randomizer.GetRandomInt(true);
            while (owo > 0)
            {
                owo = Randomizer.GetRandomInt(true);
            }
            Assert.IsTrue(owo < 0);
        }

        [TestMethod]
        public void GetRandomDiceRollsTest()
        {
            List<int> owo = Randomizer.RandomDice(10);
            Console.Write(owo);
            Assert.AreEqual(10, owo.Count);
        }

        [TestMethod]
        public void GetRandomDiceRollsTest2()
        {
            List<int> owo = Randomizer.RandomDice(10000);
            int i = 0;
            if (owo.Contains(1)) { i = i + 1; }
            if (owo.Contains(2)) { i = i + 1; }
            if (owo.Contains(3)) { i = i + 1; }
            if (owo.Contains(4)) { i = i + 1; }
            if (owo.Contains(5)) { i = i + 1; }
            if (owo.Contains(6)) { i = i + 1; }
            Assert.AreEqual(i, 6);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetRandomDiceRollsTestException()
        {
            Randomizer.RandomDice(0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetRandomDiceRollsTestException2()
        {
            Randomizer.RandomDice(10001);

        }

        [TestMethod]
        public void GetRandomFirstNamesTestInvalidAmount()
        {
            var ex =
                Assert.ThrowsException<ArgumentException>(() => Randomizer.GetRandomFirstNames(true, false, -2));
            Assert.AreEqual("The number of given names must be at least 1.", ex.Message);
        }

        [TestMethod]
        public void GetRandomFirstNamesTestInvalidBoolOptions()
        {
            var ex =
                Assert.ThrowsException<ArgumentException>(() => Randomizer.GetRandomFirstNames(false, false, 3));
            Assert.AreEqual("At least one of the boy/girl booleans must be true.", ex.Message);
        }

        [TestMethod]
        public void GetRandomFirstNamesTestValid()
        {
            Assert.AreEqual(5, Randomizer.GetRandomFirstNames(true, true, 5).Count);
            Assert.IsInstanceOfType(Randomizer.GetRandomNames("SP", 5), typeof(List<string>));
        }

        [TestMethod]
        public void GetRandomNamesInvalidCountry()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => Randomizer.GetRandomNames("Netherlands", 5));
            Assert.AreEqual("The given country is not supported, please use country codes like SP, IT, GE, etc.", ex.Message);
        }

        [TestMethod]
        public void GetRandomNamesValid()
        {
            Assert.AreEqual(5, Randomizer.GetRandomNames("SP", 5).Count);
            Assert.IsInstanceOfType(Randomizer.GetRandomNames("SP", 5), typeof(List<string>));
        }
    }
}