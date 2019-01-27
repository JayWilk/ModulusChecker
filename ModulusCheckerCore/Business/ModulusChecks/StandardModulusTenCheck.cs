using ModulusCheckerCore.Business.Entities;
using ModulusCheckerCore.Models;
using System;
using System.Globalization;

namespace ModulusCheckerCore.Business.ModulusChecks
{
    public class StandardModulusTenCheck : ModulusCheck
    {
        public override int Modulus => 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardModulusTenCheck"/> class.
        /// </summary>
        /// <param name="weightItem">The weight item.</param>
        public StandardModulusTenCheck(BankAccount bankAccount, ModulusWeightItem weightItem) 
            : base(weightItem, bankAccount)
        {
            if(weightItem.ModulusCalculationType != ModulusCalculationType.Mod10)
            {
                throw new InvalidOperationException("Incorrect modulus calcuation type");
            }
        }

        /// <summary>
        /// Gets the modulus sum.
        /// </summary>
        /// <param name="weightItem"></param>
        /// <returns></returns>
        public override int GetModulusSum(ModulusWeightItem weightItem)
        {
            var sum = 0;
            for (var i = 0; i < 14; i++)
            {
                sum += (int.Parse(BankAccount.ToString()[i].ToString(CultureInfo.InvariantCulture)) * weightItem.Weight[i]);
            }
            return sum % Modulus;
        }
    }
}