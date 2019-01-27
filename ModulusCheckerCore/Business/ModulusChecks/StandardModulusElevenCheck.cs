using ModulusCheckerCore.Business.Entities;
using ModulusCheckerCore.Models;
using System;

namespace ModulusCheckerCore.Business.ModulusChecks
{
    public class StandardModulusElevenCheck : ModulusCheck
    {
        private int Modulus = 11;

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardModulusElevenCheck"/> class.
        /// </summary>
        /// <param name="weightItem">The weight item.</param>
        public StandardModulusElevenCheck(BankAccount bankAccount, ModulusWeightItem weightItem) 
            : base(weightItem, bankAccount)
        {
            if(weightItem.ModulusCalculationType != ModulusCalculationType.Mod11)
            {
                throw new InvalidOperationException("Incorrect modulus calcuation type");
            }
        }

        public override ModulusCheckResult Process()
        {
            var remainder = GetModulusSum(Modulus);

            // Todo: add support for exceptions 4 and 7
            return remainder == 0 ? ModulusCheckResult.Pass : ModulusCheckResult.Fail; 
        }
    }
}