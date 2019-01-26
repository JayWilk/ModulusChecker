using ModulusCheckerCore.Business.Entities;
using ModulusCheckerCore.Models;
using System;

namespace ModulusCheckerCore.Business.ModulusChecks
{
    public class StandardModulusCheck : ModulusCheckCalculator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StandardModulusCheck"/> class.
        /// </summary>
        /// <param name="weightItem">The weight item.</param>
        public StandardModulusCheck(BankAccount bankAccount, ModulusWeightItem weightItem) 
            : base(weightItem, bankAccount)
        {
            if(weightItem.ModulusCalculationType != ModulusCalculationType.Mod10)
            {
                throw new InvalidOperationException("Incorrect modulus calcuation type");
            }
        }

        public override ModulusCheckResult Process()
        {
            var sum = GetModulusSum();
            var remainder = sum % 10;

            // Todo: add support for exceptions 4 and 7

            return remainder == 0 ? ModulusCheckResult.Pass : ModulusCheckResult.Fail; 
        }
    }
}