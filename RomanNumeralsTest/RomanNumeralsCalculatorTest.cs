using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals;

namespace RomanNumeralsTest
{
    [TestClass]
    public class RomanNumeralsCalculatorTest
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

        /// <summary>
        /// Testing to make sure that 50 is not found as the first numeral and then adding multiple prefixes
        /// </summary>
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

        /// <summary>
        /// A single numeral
        /// </summary>
        [TestMethod]
        public void Calculate50()
        {
            var calculator = new RomanNumeralsCalculator();
            var expectedResult = "L";
            var result = calculator.Calculate(50);

            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Combination of 2 numerals
        /// </summary>
        [TestMethod]
        public void Calculate150()
        {
            var calculator = new RomanNumeralsCalculator();
            var expectedResult = "CL";
            var result = calculator.Calculate(150);

            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Testing to see if the correct numerals can be prefixed - ie. that it does not return "IM" (1000 - 1)
        /// </summary>
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
