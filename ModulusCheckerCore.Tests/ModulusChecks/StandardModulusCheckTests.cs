using ModulusCheckerCore.Business;
using ModulusCheckerCore.Business.Entities;
using ModulusCheckerCore.Business.ModulusChecks;
using ModulusCheckerCore.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace ModulusCheckerCore.ModulusChecks.Tests
{
    public class StandardModulusCheckTests
    {
        private ModulusWeightTable ModulusWeightTable;

        public StandardModulusCheckTests()
        {
            var weightLoaderFile = Properties.Resources.valacdos;
            ModulusWeightTable = new ModulusWeightTable(weightLoaderFile);
        }

        [Test]
        [TestCase("871427", "46238510")]
        public void InvalidExceptionsShouldErrorModulus10(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

            var modulusWeight = ModulusWeightTable.GetModulusWeight(account)
                .FirstOrDefault();

            Assert.Throws<NotImplementedException>(
                () => new StandardModulusTenCheck(account, modulusWeight)
            );
        }

        [Test]
        [TestCase("820000", "73688637")] // Exception 3
        public void InvalidExceptionsShouldErrorModulus11(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

            var modulusWeight = ModulusWeightTable.GetModulusWeight(account)
                .FirstOrDefault();
        }

        [Test]
        [TestCase("820000", "1")] // Invalid account number 
        public void InvalidBankAccountShouldError(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

            var modulusWeight = ModulusWeightTable.GetModulusWeight(account)
                .FirstOrDefault();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new StandardModulusTenCheck(account, modulusWeight)
            );
        }


        [Test]
        [TestCase("089999", "66374958")]
        public void ValidateModulus10(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

            var modulusWeight = ModulusWeightTable.GetModulusWeight(account)
                .FirstOrDefault();

            var mod10Calculator = new StandardModulusTenCheck(account, modulusWeight);

            var modulsCheck = mod10Calculator.Process();

            Assert.AreEqual(modulsCheck, ModulusCheckResult.Pass);
        }

        [Test]
        [TestCase("107999", "88837491")]
        [TestCase("202959", "63748472")] // Pass modulus 11 and double alternate checks
        public void ValidateModulus11(string sortcode, string accountNumber)
        {

        }

        [Test]
        [TestCase("089999", "66374959")]
        public void FailModulus10(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

            var modulusWeight = ModulusWeightTable.GetModulusWeight(account)
                .FirstOrDefault();

            var mod10Calculator = new StandardModulusTenCheck(account, modulusWeight);

            var modulsCheck = mod10Calculator.Process();

            Assert.AreEqual(modulsCheck, ModulusCheckResult.Fail);
        }

        [Test]
        [TestCase("107999", "88837493")]
        public void FailModulus11(string sortCode, string accountNumber)
        {

        }
    }
}
