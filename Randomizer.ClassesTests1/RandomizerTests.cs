using Randomizer.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Randomizer.Classes.Tests
{
    [TestClass()]
    public class RandomizerTests
    {
        [TestMethod()]
        public void GetRandomDateTest()
        {
            DateTime owo = Randomizer.GetRandomDate();
            Console.Write(owo);
            Assert.IsNotNull(owo);
        }

        [TestMethod()]
        public void GetRandomDateWithStartTest()
        {
            DateTime owo = Randomizer.GetRandomDate(new DateTime(2000, 10, 4));
            Console.Write(owo);
            Assert.IsNotNull(owo);
        }

        [TestMethod()]
        public void GetRandomDateWithStartAndEndTest()
        {
            DateTime owo = Randomizer.GetRandomDate(new DateTime(2000, 10, 4), new DateTime(2010, 9, 2));
            Console.Write(owo);
            Assert.IsNotNull(owo);
        }

        [TestMethod()]
        public void GetRandomIntTest()
        {
            int owo = Randomizer.GetRandomInt(false);
            Assert.IsNotNull(owo);
        }

        [TestMethod()]
        public void getRandomNegativeTest()
        {
            int owo = Randomizer.GetRandomInt(true);
            Assert.IsTrue(owo < 0);
        }

        public void GetRandomDiceRollsTest()
        {
            List<int> owo = Randomizer.RandomDice(10);
            Console.Write(owo);
            Assert.AreEqual(10, owo.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void GetRandomDiceRollsTestException()
        {
            Randomizer.RandomDice(0);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void GetRandomDiceRollsTestException2()
        {
            Randomizer.RandomDice(10001);

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetRandomFirstNamesTest()
        {
            Randomizer.GetRandomFirstNames(true, true, -1);
        }

        [TestMethod]
        public void GetRandomFirstNamesTest1()
        {
            var result = Randomizer.GetRandomFirstNames(true, true, 5);
            Assert.AreEqual(5, result.Count);
        }
    }
}