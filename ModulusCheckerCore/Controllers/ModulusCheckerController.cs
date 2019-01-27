using ModulusCheckerCore.Models;
using System.Web.Http;
using System;
using ModulusCheckerCore.Business;
using ModulusCheckerCore.Business.ModulusChecks;

namespace ModulusCheckerCore.Controllers
{
    public class ModulusCheckerController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IHttpActionResult IsAccountValid(string sortCode, string accountNumber)
        {
            var bankAccount = new BankAccount(sortCode.ToString(), accountNumber.ToString());

            try
            {
                var weightTable = new ModulusWeightTable(Properties.Resources.valacdos);

                foreach(var item in weightTable.GetModulusWeight(bankAccount))
                {
                    // Step 1 - Check for modulus 10
                    if (item.ModulusCalculationType == Business.Entities.ModulusCalculationType.Mod10)
                    {
                        if (new StandardModulusTenCheck(bankAccount, item).Process() == Business.Entities.ModulusCheckResult.Fail)
                        {
                            return Ok(false);
                        }
                    }

                    // Step 2 - Modulus 11
                    else if (item.ModulusCalculationType == Business.Entities.ModulusCalculationType.Mod11)
                    {
                        if (new StandardModulusElevenCheck(bankAccount, item).Process() == Business.Entities.ModulusCheckResult.Fail)
                        {
                            return Ok(false);
                        }
                    }

                    // Step 3 - Double Alternate
                    else if (item.ModulusCalculationType == Business.Entities.ModulusCalculationType.DblAl)
                    {
                        if (new DoubleAlternateModulusCheck(bankAccount, item).Process() == Business.Entities.ModulusCheckResult.Fail)
                        {
                            return Ok(false);
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                log.Error($"Error validating account with parameters: {sortCode},{accountNumber}", ex);
                return InternalServerError(ex);
            }

            return Ok(true);
        }
    }
}
