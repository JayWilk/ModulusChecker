using ModulusCheckerCore.Business;
using ModulusCheckerCore.Business.Entities;
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
        [TestCase("134020", "63849203")]
        public void ValidateExceptionFour(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

            var modulusWeight = ModulusWeightTable.GetModulusWeight(account)
                .FirstOrDefault();

            var mod11Calculator = new StandardModulusElevenCheck(account, modulusWeight);

            var modulsCheck = mod11Calculator.Process();

            Assert.AreEqual(modulsCheck, ModulusCheckResult.Pass);
        }

        [Test]
        [TestCase("772798", "99345694")]
        public void ValidateExceptionSeven(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

            var modulusWeight = ModulusWeightTable.GetModulusWeight(account)
                .FirstOrDefault();

            var mod11Calculator = new StandardModulusElevenCheck(account, modulusWeight);

            var modulsCheck = mod11Calculator.Process();

            Assert.AreEqual(modulsCheck, ModulusCheckResult.Pass);
        }

        [Test]
        [TestCase("118765", "64371389")] // Exception 1
        [TestCase("309070", "02355688")] // Exception 2
        [TestCase("938611", "07806039")] // Exception 5
        [TestCase("200915", "41011166")] // Exception 6
        [TestCase("086090", "06774744")] // Exception 8
        [TestCase("871427", "46238510")] // Exception 10 
        [TestCase("074456", "11104102")] // Exception 12/13
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
