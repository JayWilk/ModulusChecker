using ModulusCheckerCore.Models;
using System;
using System.Collections.Generic;

namespace ModulusCheckerCore.Business
{
    public class ModulusWeightTableInitialiser 
    {
        public IEnumerable<ModulusWeightItem> ModulusWeightItems { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModulusWeightTableInitialiser"/> class.
        /// </summary>
        /// <param name="modulusWeightTableFile">The modulus weight table file.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public ModulusWeightTableInitialiser(string modulusWeightTableFile)
        {
            if (string.IsNullOrEmpty(modulusWeightTableFile))
                throw new ArgumentNullException();

            // Todo: processing for ModulusWeightItems
        }
    }
}