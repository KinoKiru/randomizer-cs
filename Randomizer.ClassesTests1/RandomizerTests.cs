﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using static Randomizer.Classes.Randomizer;

namespace Randomizer.Classes.Tests
{
    [TestClass]
    public class RandomizerTests
    {

        private static readonly Random rng = new();

        [TestMethod]
        public void GetRandomDateTest()
        {
            DateTime owo = GetRandomDate();
            Console.Write(owo);
            Assert.IsNotNull(owo);
        }

        [TestMethod]
        public void GetRandomDateWithStartTest()
        {
            DateTime owo = GetRandomDate(new DateTime(2000, 10, 4));
            Console.Write(owo);
            Assert.IsNotNull(owo);
        }

        [TestMethod]
        public void GetRandomDateWithStartAndEndTest()
        {
            DateTime owo = GetRandomDate(new DateTime(2000, 10, 4), new DateTime(2010, 9, 2));
            Console.Write(owo);
            Assert.IsNotNull(owo);
        }


        [TestMethod()]
        public void GetRandomIntTest()
        {
            int owo = GetRandomInt(false);
            Assert.IsTrue(owo > 0);
        }

        [TestMethod]
        public void getRandomNegativeTest()
        {
            int owo = GetRandomInt(true);
            while (owo > 0)
            {
                owo = GetRandomInt(true);
            }
            Assert.IsTrue(owo < 0);
        }

        [TestMethod]
        public void GetRandomDiceRollsTest()
        {
            List<int> owo = RandomDice(10);
            Console.Write(owo);
            Assert.AreEqual(10, owo.Count);
        }

        [TestMethod]
        public void GetRandomDiceRollsTest2()
        {
            List<int> owo = RandomDice(10000);
            int i = 0;
            if (owo.Contains(1)) { i++; }
            if (owo.Contains(2)) { i++; }
            if (owo.Contains(3)) { i++; }
            if (owo.Contains(4)) { i++; }
            if (owo.Contains(5)) { i++; }
            if (owo.Contains(6)) { i++; }
            Assert.AreEqual(i, 6);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetRandomDiceRollsTestException()
        {
            RandomDice(0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetRandomDiceRollsTestException2()
        {
            RandomDice(10001);

        }

        [TestMethod]
        public void GetRandomFirstNamesTestInvalidAmount()
        {
            var ex =
                Assert.ThrowsException<ArgumentException>(() => GetRandomFirstNames(true, false, -2));
            Assert.AreEqual("The number of given names must be at least 1.", ex.Message);
        }

        [TestMethod]
        public void GetRandomFirstNamesTestInvalidBoolOptions()
        {
            var ex =
                Assert.ThrowsException<ArgumentException>(() => GetRandomFirstNames(false, false, 3));
            Assert.AreEqual("At least one of the boy/girl booleans must be true.", ex.Message);
        }

        [TestMethod]
        public void GetRandomFirstNamesTestValid()
        {
            Assert.AreEqual(5, GetRandomFirstNames(true, true, 5).Count);
            Assert.IsInstanceOfType(GetRandomNames("SP", 5), typeof(List<string>));
        }

        [TestMethod]
        public void GetRandomNamesInvalidCountry()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => GetRandomNames("Netherlands", 5));
            Assert.AreEqual("The given country is not supported, please use country codes like SP, IT, GE, etc.", ex.Message);
        }

        [TestMethod]
        public void GetRandomNamesNoCountrySelected()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => GetRandomNames("Selecteer een land", 5));
            Assert.AreEqual("No country was selected.", ex.Message);
        }

        [TestMethod]
        public void GetRandomNamesValid()
        {
            var result = GetRandomNames("SP", 5);
            Assert.AreEqual(5, result.Count);
            Assert.IsInstanceOfType(result, typeof(List<string>));
            foreach (string name in result)
            {
                Assert.IsInstanceOfType(name, typeof(string));
            }
        }

        [TestMethod]
        public void TestGetRandomLocation()
        {
            var uwu = Randomizer.GetRandomLocation();

            var qwq = uwu.GetType().GetProperty("Latitude");
            var pwp = uwu.GetType().GetProperty("Longitude");

            var owo = (double)qwq.GetValue(uwu, null);
            var cwc = (double)pwp.GetValue(uwu, null);

            Assert.IsTrue(owo is >= -90 and <= 90);
            Assert.IsTrue(cwc is >= -180 and <= 180);
        }

        /// <summary>Generate a random season 10 times and test if the random season is of the same enum type.</summary>
        [TestMethod]
        public void TestGetRandomSeasonReturnsEnum()
        {
            for (int i = 0; i < 10; i++)
            {
                Assert.IsInstanceOfType(GetRandomSeason(), typeof(Seasons));
            }
        }

        [TestMethod]
        public void TestGetRandomTimeValid()
        {
            var result = GetRandomTime();
            Assert.IsNotNull(result.Hours & result.Minutes & result.Minutes);
            Assert.IsInstanceOfType(result, typeof(Time));
        }

        [TestMethod]
        public void GetRandomColorTest()
        {
            var owo = RandomColor(false);
            Regex uwu = new Regex("^#(?:[0-9a-fA-F]{3}){1,2}$");
            Assert.IsTrue(uwu.IsMatch(owo));

        }

        [TestMethod]
        public void GetRandomKnownColorTest()
        {
            var owo = RandomColor(true);

            Assert.IsTrue(Color.FromName(owo).IsKnownColor);
        }

        [TestMethod]
        public void GetRandomTekstTest()
        {
            var owo = GenerateRandomText(1, false, false);

            Assert.IsTrue(owo is string);
        }
        [TestMethod()]
        public void generatePasswordTest()
        {
            var result = Randomizer.generatePassword(2, 4, 1, 0);
            var uwu = new Regex("^(?=.*[a-zA-Z])(?=.*[0-9])");
            Assert.IsTrue(uwu.IsMatch(result));
        }

        [TestMethod]
        public void GetRandomTekstTest2()
        {
            var owo = GenerateRandomText(1, false, true);

            Assert.IsTrue(owo.Contains("<p>"));
        }
    }
}