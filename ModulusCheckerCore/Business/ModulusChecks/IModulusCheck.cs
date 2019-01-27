using ModulusCheckerCore.Business.Entities;

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
        /// <returns></returns>
        int GetModulusSum();
    }
}
