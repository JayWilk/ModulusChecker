﻿using NUnit.Framework;
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
            var weightInitialiser = new Business.ModulusWeightTable(Properties.Resources.valacdos);
            Assert.IsNotNull(weightInitialiser.ModulusWeightItems);

            // The file contains 1073 elements
            Assert.AreEqual(weightInitialiser.ModulusWeightItems.Count, 1073, "Incorrect number of weight items in the table");

            // Check all of the weightings are loaded
            Assert.AreEqual(weightInitialiser.ModulusWeightItems.First().Weight.Count(), 14, "Incorrect number of digit positions");

            // Check the exceptions are loaded
            Assert.AreEqual(weightInitialiser.ModulusWeightItems.ElementAt(20).Exception, 12, "The exception was not parsed");
        }
    }
}
