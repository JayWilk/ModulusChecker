using System;
using ModulusCheckerCore.Business.Entities;
using ModulusCheckerCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulusCheckerCore.Business.ModulusChecks
{
    public class DoubleAlternateModulusCheck : ModulusCheck
    {
        public override int Modulus => 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleAlternateModulusCheck"/> class.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <param name="weightItem">The weight item.</param>
        /// <exception cref="System.InvalidOperationException">Incorrect modulus calcuation type</exception>
        public DoubleAlternateModulusCheck(BankAccount bankAccount, ModulusWeightItem weightItem) 
            : base(weightItem, bankAccount)
        {
            if(weightItem.ModulusCalculationType != ModulusCalculationType.DblAl)
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
                var multiplicationResult = (int.Parse(BankAccount.ToString()[i].ToString()) * weightItem.Weight[i]);
                sum += GetIntArray(multiplicationResult).Sum();
            }

            return sum % Modulus;
        }

        /// <summary>
        /// Converts an integer to an array of individual digits, to the power of 10
        /// </summary>
        /// <param name="num">The number.</param>
        private static IEnumerable<int> GetIntArray(int num)
        {
            var listOfInts = new List<int>();

            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }

            listOfInts.Reverse();
            return listOfInts.ToArray();
        }
    }
}