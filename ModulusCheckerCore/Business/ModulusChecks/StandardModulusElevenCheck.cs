using ModulusCheckerCore.Business.Entities;
using ModulusCheckerCore.Models;
using System;
using System.Globalization;

namespace ModulusCheckerCore.Business.ModulusChecks
{
    public class StandardModulusElevenCheck : ModulusCheck
    {
        public override int Modulus => 11;

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

        /// <summary>
        /// Processes the calculation to determine if the provided account is valid or not
        /// </summary>
        /// <returns>
        /// The modulus result
        /// </returns>
        public override ModulusCheckResult Process()
        {
            var remainder = GetModulusSum();

            // Todo: add support for exceptions 4 and 7
            return remainder == 0 ? ModulusCheckResult.Pass : ModulusCheckResult.Fail; 
        }

        /// <summary>
        /// Gets the modulus sum.
        /// </summary>
        /// <param name="modulus">The modulus, generally this is 10 or 11</param>
        /// <returns></returns>
        public override int GetModulusSum()
        {
            var sum = 0;
            for (var i = 0; i < 14; i++)
            {
                sum += (int.Parse(BankAccount.ToString()[i].ToString(CultureInfo.InvariantCulture)) * ModulusWeightItem.Weight[i]);
            }
            return sum % Modulus;
        }
    }
}