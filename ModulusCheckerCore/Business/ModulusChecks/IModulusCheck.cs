using ModulusCheckerCore.Business.Entities;
using ModulusCheckerCore.Models;

namespace ModulusCheckerCore.Business.ModulusChecks
{
    public interface IModulusCheck
    {
        /// <summary>
        /// Processes the calculation to determine if the provided account is valid or not
        /// </summary>
        /// <returns>
        /// The modulus result
        /// </returns>
        ModulusCheckResult Process();

        /// <summary>
        /// Gets the modulus sum.
        /// </summary>
        /// <param name="weightItem">The weight item.</param>
        /// <returns></returns>
        int GetModulusSum(ModulusWeightItem weightItem);
    }
}
