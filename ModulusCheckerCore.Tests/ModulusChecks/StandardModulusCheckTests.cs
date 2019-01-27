using ModulusCheckerCore.Business;
using ModulusCheckerCore.Business.Entities;
using ModulusCheckerCore.Business.ModulusChecks;
using ModulusCheckerCore.Models;
using NUnit.Framework;
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
        public void ValidateModulus11(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

            var modulusWeight = ModulusWeightTable.GetModulusWeight(account)
                .FirstOrDefault();

            var mod11Calculator = new StandardModulusElevenCheck(account, modulusWeight);

            var modulsCheck = mod11Calculator.Process();

            Assert.AreEqual(modulsCheck, ModulusCheckResult.Pass);
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
            var account = new BankAccount(sortCode, accountNumber);

            var modulusWeight = ModulusWeightTable.GetModulusWeight(account)
                .FirstOrDefault();

            var mod11Calculator = new StandardModulusElevenCheck(account, modulusWeight);

            var modulsCheck = mod11Calculator.Process();

            Assert.AreEqual(modulsCheck, ModulusCheckResult.Fail);
        }
    }
}
