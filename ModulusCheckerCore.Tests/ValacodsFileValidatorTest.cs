using NUnit.Framework;
using System.Linq;

namespace ModulusCheckerCore.Tests
{
    public class ValacodsFileValidatorTest
    {
        [Test]
        public void EnsureFileIsNotNullOrEmpty()
        {
            var weightLoaderFile = Properties.Resources.valacdos;

            Assert.DoesNotThrow(() => 
                new Business.ModulusWeightTable(weightLoaderFile)
            );
        }

        [Test]
        public void EnsureModulusWeightFileProcessed()
        {
            var weightMappings = new Business.ModulusWeightTable(Properties.Resources.valacdos);
            Assert.IsNotNull(weightMappings.ModulusWeightItems);

            // The file contains 1073 elements
            Assert.AreEqual(weightMappings.ModulusWeightItems.Count, 1073, "Incorrect number of weight items in the table");

            // Check all of the weightings are loaded
            Assert.AreEqual(weightMappings.ModulusWeightItems.First().Weight.Count(), 14, "Incorrect number of digit positions");

            // Check the exceptions are loaded
            Assert.AreEqual(weightMappings.ModulusWeightItems.ElementAt(20).Exception, 12, "The exception was not parsed");
        }

        [Test]
        [TestCase("107999", "88837491")]
        public void CheckSortCodeMatch(string sortCode, string accountNumber)
        {
            var weightMappings = new Business.ModulusWeightTable(Properties.Resources.valacdos);

            var modulusWeight = weightMappings.GetModulusWeight(new Models.BankAccount(sortCode, accountNumber));

            Assert.IsNotNull(modulusWeight);
            Assert.AreEqual(modulusWeight.Count(), 1);
        }
    }
}
