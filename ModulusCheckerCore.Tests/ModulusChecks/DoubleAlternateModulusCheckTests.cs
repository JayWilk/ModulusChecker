using ModulusCheckerCore.Models;
using NUnit.Framework;

namespace ModulusCheckerCore.ModulusChecks.Tests
{
    public class DoubleAlternateModulusCheckTests
    {
        [Test]
        [TestCase("202959", "63748472")] // Pass modulus 11 and double alternate checks
        [TestCase("203099", "58716970")] // Fail Modulus 11 check and pass double alternate check
        public void ValidateDoubleAlternateModulusCheck(string sortCode, string accountNumber)
        {
            // Arrange
             
            // Act

            // Assert
        }

        [Test]
        [TestCase("203099", "6683106")] // Pass Modulus 11 check and fail double alternate check
        public void FailDoubleAlternateModulusCheck(string sortCode, string accountNumber)
        {
            var account = new BankAccount(sortCode, accountNumber);

        }
    }
}
