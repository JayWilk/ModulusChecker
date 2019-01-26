using ModulusCheckerCore.Business.Entities;
using ModulusCheckerCore.Models;
using System;
using System.Globalization;

namespace ModulusCheckerCore.Business.ModulusChecks
{
    public abstract class ModulusCheck : IModulusCheckCalculator
    {
        protected ModulusWeightItem ModulusWeightItem { get; private set; }

        protected BankAccount BankAccount { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModulusCheck"/> class.
        /// </summary>
        /// <param name="weightItem">The weight item.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">weightItems - Weight items must be provided to perform a standard modulus check</exception>
        /// <exception cref="System.NotImplementedException">Only exceptions 7 and 4 are supported</exception>
        public ModulusCheck(ModulusWeightItem weightItem, BankAccount bankAccount)
        {
            if(bankAccount.ToString().Length != 14)
            {
                throw new ArgumentOutOfRangeException(nameof(bankAccount), "The sort code and account number should be a total of 14 characters in length");
            }

            if (weightItem == null)
            {
                throw new ArgumentOutOfRangeException(nameof(weightItem), "Weight items must be provided to perform a standard modulus check");
            }

            if (weightItem.Exception.HasValue && weightItem.Exception.Value != 7 && weightItem.Exception.Value != 4)
            {
                throw new NotImplementedException("Only exceptions 7 and 4 are supported");
            }

            ModulusWeightItem = weightItem;
            BankAccount = bankAccount;
        }

        /// <summary>
        /// Gets the modulus sum.
        /// </summary>
        /// <param name="modulus">The modulus, generally this is 10 or 11</param>
        /// <returns></returns>
        protected int GetModulusSum(int modulus)
        {
            var sum = 0;
            for (var i = 0; i < 14; i++)
            {
                sum += (int.Parse(BankAccount.ToString()[i].ToString(CultureInfo.InvariantCulture)) * ModulusWeightItem.Weight[i]);
            }
            return sum % modulus;
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        /// <returns>The modulus result</returns>
        public abstract ModulusCheckResult Process();
    }
}