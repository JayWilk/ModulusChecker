using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModulusCheckerCore.Tests
{
    [TestClass]
    public class ValacodsFileValidatorTest
    {

        public ValacodsFileValidatorTest()
        {
            
        }

        [TestMethod]
        public void EnsureFileIsNotNullOrEmpty()
        {
            // Arrange
            var weightLoaderFile = Properties.Resources.valacdos;

            // Act
            var modulusWeightTableInitialiser = new Business.ModulusWeightTableInitialiser(weightLoaderFile);

            // Asset
            Assert.AreNotEqual(null, weightLoaderFile);
         
        }

        [TestMethod]
        public void EnsureFileIsValid()
        {
            // Arrrange

            // Act
            
            // Assert

        }

    }
}
