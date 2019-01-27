using System;
using NUnit.Framework;
using ModulusCheckerCore.Models;
using ModulusCheckerCore.Business;
using System.Linq;
using ModulusCheckerCore.Business.ModulusChecks;

namespace ModulusCheckerCore.Tests
{
    public class BankAccountTests
    {
        [Test]
        [TestCase("820000", "1")] // Invalid account number length
        public void InvalidBankAccountShouldError(string sortCode, string accountNumber)
        {
            var modulusWeightTable = new ModulusWeightTable(Properties.Resources.valacdos);

            var account = new BankAccount(sortCode, accountNumber);

            var modulusWeight = modulusWeightTable.GetModulusWeight(account)
                .FirstOrDefault();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new StandardModulusTenCheck(account, modulusWeight)
            );
        }
    }
}
