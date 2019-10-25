using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Tests
{
    [TestClass()]
    public class FizzBuzzClassTests
    {
        [TestMethod()]
        public void GetFizzBuzzTest_3Modulo3_RetourneFizz()
        {
            String fizzReturned;
            int nbStart = 3;

            fizzReturned = FizzBuzzClass.GetFizzBuzz(nbStart);

            Assert.AreEqual("Fizz", fizzReturned);
        }

        [TestMethod()]
        public void GetFizzBuzzTest_10Modulo5_RetourneBuzz()
        {
            String fizzReturned;
            int nbStart = 10;

            fizzReturned = FizzBuzzClass.GetFizzBuzz(nbStart);

            Assert.AreEqual("Buzz", fizzReturned);
        }

        [TestMethod()]
        public void GetFizzBuzzTest_15Modulo3Et5_RetourneFizzBuzz()
        {
            String fizzReturned;
            int nbStart = 15;

            fizzReturned = FizzBuzzClass.GetFizzBuzz(nbStart);

            Assert.AreEqual("FizzBuzz", fizzReturned);
        }

        [TestMethod()]
        public void GetFizzBuzzTest_NonDivisiblePar3Ou5_RetourneLeNb()
        {
            String fizzReturned;
            int nbStart = 4;

            fizzReturned = FizzBuzzClass.GetFizzBuzz(nbStart);

            Assert.AreEqual("4", fizzReturned);
        }
    }
}