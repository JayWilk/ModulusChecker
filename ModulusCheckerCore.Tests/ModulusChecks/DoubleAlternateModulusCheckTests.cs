using ModulusCheckerCore.Business;
using ModulusCheckerCore.Business.Entities;
using ModulusCheckerCore.Business.ModulusChecks;
using ModulusCheckerCore.Models;
using NUnit.Framework;

namespace ModulusCheckerCore.ModulusChecks.Tests
{
    public class DoubleAlternateModulusCheckTests
    {
        private ModulusWeightTable ModulusWeightTable;

        public DoubleAlternateModulusCheckTests()
        {
            var weightLoaderFile = Properties.Resources.valacdos;
            ModulusWeightTable = new ModulusWeightTable(weightLoaderFile);
        }

        [Test]
        [TestCase("202959", "63748472")] 
        public void ValidateDoubleAlternateModulusCheck(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

            // As exception 6 is not currently supported, the weight item
            // needs to be mocked so that the exception isn't included.

            var modulusWeight = new ModulusWeightItem
            {
                SortCodeStart = 202700,
                SortCodeEnd = 203239,
                ModulusCalculationType = ModulusCalculationType.DblAl,
                Weight = new int[] { 2,1,2,1,2,1,2,1,2,1,2,1,2,1}
            };

            var doubleAltCalculator = new DoubleAlternateModulusCheck(account, modulusWeight);

            var modulsCheck = doubleAltCalculator.Process();

            Assert.AreEqual(modulsCheck, ModulusCheckResult.Pass);
        }

        [Test]
        [TestCase("203099", "66831036")] 
        public void FailDoubleAlternateModulusCheck(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

            // As exception 6 is not currently supported, the weight item
            // needs to be mocked so that the exception isn't included.
            var modulusWeight = new ModulusWeightItem
            {
                SortCodeStart = 202700,
                SortCodeEnd = 203239,
                ModulusCalculationType = ModulusCalculationType.DblAl,
                Weight = new int[] { 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 }
            };

            var doubleAltCalculator = new DoubleAlternateModulusCheck(account, modulusWeight);

            var modulsCheck = doubleAltCalculator.Process();

            Assert.AreEqual(modulsCheck, ModulusCheckResult.Fail);
            
        }
    }
}
