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
    }
}
