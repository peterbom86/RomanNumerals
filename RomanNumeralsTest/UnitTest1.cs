using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals;

namespace RomanNumeralsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Calculate1999()
        {
            var calculator = new RomanNumeralsCalculator();
            var expectedResult = "MCMXCIX";
            var result = calculator.Calculate(1999);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Calculate2444()
        {
            var calculator = new RomanNumeralsCalculator();
            var expectedResult = "MMCDXLIV";
            var result = calculator.Calculate(2444);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Calculate90()
        {
            var calculator = new RomanNumeralsCalculator();
            var expectedResult = "XC";
            var result = calculator.Calculate(90);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Calculate40()
        {
            var calculator = new RomanNumeralsCalculator();
            var expectedResult = "XL";
            var result = calculator.Calculate(40);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Calculate19()
        {
            var calculator = new RomanNumeralsCalculator();
            var expectedResult = "XIX";
            var result = calculator.Calculate(19);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Calculate1()
        {
            var calculator = new RomanNumeralsCalculator();
            var expectedResult = "I";
            var result = calculator.Calculate(1);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Calculate50()
        {
            var calculator = new RomanNumeralsCalculator();
            var expectedResult = "L";
            var result = calculator.Calculate(50);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Calculate999()
        {
            var calculator = new RomanNumeralsCalculator();
            var expectedResult = "CMXCIX";
            var result = calculator.Calculate(999);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
