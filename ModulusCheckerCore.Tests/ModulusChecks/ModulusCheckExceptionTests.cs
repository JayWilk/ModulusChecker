using NUnit.Framework;

namespace ModulusCheckerCore.ModulusChecks.Tests
{
    public class ModulusCheckExceptionTests
    {
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
    }
}
