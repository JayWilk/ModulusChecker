using ModulusCheckerCore.Business.Entities;
using ModulusCheckerCore.Models;
using System;
using System.Linq;

namespace ModulusCheckerCore.Business.ModulusChecks
{
    public abstract class ModulusCheck : IModulusCheck
    {
        public abstract int Modulus { get; }

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
                throw new ArgumentOutOfRangeException(nameof(bankAccount), "The sort code and account number should be a total of 14 characters in length");

            if (weightItem == null)
                throw new ArgumentOutOfRangeException(nameof(weightItem), "Weight items must be provided to perform a standard modulus check");

            if (weightItem.Exception.HasValue && weightItem.Exception.Value != 7 && weightItem.Exception.Value != 4)
                throw new NotImplementedException("Only exceptions 7 and 4 are supported");

            ModulusWeightItem = weightItem;
            BankAccount = bankAccount;
        }

        /// <summary>
        /// Gets the get exception four sum
        /// </summary>
        /// <remarks>
        /// Exception 4 compares the remainder to the value of gh in the notation table (index 6 and 7 in the account number string)
        /// </remarks>
        public int GetExceptionFourSum
        {
            get
            {
                return int.Parse(string.Format("{0}{1}", BankAccount.AccountNumber[6], BankAccount.AccountNumber[7]));
            }
        }

        /// <summary>
        /// Gets a slightly modified version of the weight item, which takes into consideration exception 7.
        /// </summary>
        /// <param name="weightItem">The weight item.</param>
        /// <remarks>Notations U to B are zeroised for exception 7</remarks>
        public ModulusWeightItem GetExceptionSevenWeightItem(ModulusWeightItem weightItem)
        {
            var modulusWeightItem = weightItem;
            modulusWeightItem.Weight = weightItem.Weight.Select((weight, index) => index < 8 ? 0 : weight).ToArray();
            return modulusWeightItem;
        }

        /// <summary>
        /// Processes the calculation to determine if the provided account is valid or not
        /// </summary>
        /// <returns>
        /// The modulus result
        /// </returns>
        public ModulusCheckResult Process()
        {
            var remainder = GetModulusSum(ModulusWeightItem.Exception != 7 ? ModulusWeightItem : GetExceptionSevenWeightItem(ModulusWeightItem));

            return ModulusWeightItem.Exception != 4 
                ? (remainder == 0 ? ModulusCheckResult.Pass : ModulusCheckResult.Fail) 
                : (remainder == GetExceptionFourSum ? ModulusCheckResult.Pass : ModulusCheckResult.Fail);
        }

        /// <summary>
        /// Gets the modulus sum.
        /// </summary>
        /// <returns></returns>
        public abstract int GetModulusSum(ModulusWeightItem weightItem);
    }
}