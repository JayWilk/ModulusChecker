using ModulusCheckerCore.Business.Entities;

namespace ModulusCheckerCore.Business.ModulusChecks
{
    public interface IModulusCheckCalculator
    {
        /// <summary>
        /// Performs the modulus calculation
        /// </summary>
        ModulusCheckResult Process();
    }
}
