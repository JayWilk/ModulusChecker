using NUnit.Framework;

namespace ModulusCheckerCore.ModulusChecks.Tests
{
    public class StandardModulusCheckTests
    {
        [Test]
        [TestCase(089999, 66374958)]
        public void ValidateModulus10(double sortcode, double accountNumber)
        {
            // Arrange
             
            // Act

            // Assert
        }

        [Test]
        [TestCase(107999, 88837491)]
        [TestCase(202959, 63748472)] // Pass modulus 11 and double alternate checks
        public void ValidateModulus11(double sortcode, double accountNumber)
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        [TestCase(089999, 66374959)]
        public void FailModulus10(double sortcode, double accountNumber)
        {

        }

        [Test]
        [TestCase(107999, 88837493)]
        public void FailModulus11(double sortCode, double accountNumber)
        {

        }

    }
}
