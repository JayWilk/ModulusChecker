using ModulusCheckerCore.Business;
using ModulusCheckerCore.Business.ModulusChecks;
using ModulusCheckerCore.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace ModulusCheckerCore.ModulusChecks.Tests
{
    public class ModulusCheckExceptionTests
    {
        private ModulusWeightTable ModulusWeightTable;

        public ModulusCheckExceptionTests()
        {
            var weightLoaderFile = Properties.Resources.valacdos;
            ModulusWeightTable = new ModulusWeightTable(weightLoaderFile);
        }

        [Test]
        [TestCase(134020, 63849203)]
        public void ValidateExceptionFour(double sortCode, double accountNumber)
        {
        }

        [Test]
        [TestCase(772798, 99345694)]
        public void ValidateExceptionSeven(double sortCode, double accountNumber)
        {

        }

        [Test]
        [TestCase("871427", "46238510")] // Exception 10 - not supported
        public void InvalidExceptionsShouldError(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

            var modulusWeight = ModulusWeightTable.GetModulusWeight(account)
                .FirstOrDefault();

            Assert.Throws<NotImplementedException>(
                () => new StandardModulusTenCheck(account, modulusWeight)
            );
        }
    }
}
