using NUnit.Framework;
using System;

namespace ModulusCheckerCore.Tests
{

    public class ValacodsFileValidatorTest
    {
        [Test]
        public void EnsureFileIsNotNullOrEmpty()
        {
            var weightLoaderFile = Properties.Resources.valacdos;

            Assert.DoesNotThrow(() => 
                new Business.ModulusWeightTableInitialiser(weightLoaderFile)
            );
        }

        [Test]
        public void EnsureModulusWeightFileProcessed()
        {
            var weightInitialiser = new Business.ModulusWeightTableInitialiser(Properties.Resources.valacdos);
            Assert.IsNotNull(weightInitialiser.ModulusWeightItems);
        }
    }
}
