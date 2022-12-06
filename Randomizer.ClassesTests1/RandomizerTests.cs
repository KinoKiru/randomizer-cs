using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    }
}