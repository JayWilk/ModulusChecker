using System;

namespace ModulusCheckerCore.Business
{
    public class ModulusWeightTableInitialiser
    {
        private string ModulusWeightTableResource;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModulusWeightTableInitialiser"/> class.
        /// </summary>
        /// <param name="modulusWeightTableFile">The modulus weight table file.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public ModulusWeightTableInitialiser(string modulusWeightTableFile)
        {
            if (string.IsNullOrEmpty(modulusWeightTableFile))
                throw new ArgumentNullException();

            ModulusWeightTableResource = modulusWeightTableFile;
        }

    }
}