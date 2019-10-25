using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Tests
{
    [TestClass()]
    public class CalculatriceTests
    {
        [TestMethod()]
        public void AdditionTest_2et5_retourne7()
        {
            int fstOp = 2;
            int sndOp = 5;
            int additionMethod;
            int sum;

            additionMethod = Calculatrice.Addition(fstOp, sndOp);
            sum = fstOp + sndOp;

            Assert.AreEqual(sum, additionMethod);
            
        }
    }
}