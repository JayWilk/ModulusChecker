using ModulusCheckerCore.Controllers;
using System.Web.Http;
using System.Web.Http.Results;

namespace ModulusChecker.Controllers
{
    public class ModulusCheckController : ApiController
    {
        [HttpGet]
        [ActionName("validateaccount")]
        public IHttpActionResult ValidateAccount(string sortCode, string accountNumber)
        {
            if((sortCode + accountNumber).Length != 14)
            {
                return BadRequest();
            }

            var modulusCheckResult = new ModulusCheckerController().IsAccountValid(sortCode, accountNumber)
                as OkNegotiatedContentResult<bool>;
            
            if(modulusCheckResult != null)
            {
                return Json(modulusCheckResult.Content);
            }

            // By default, accounts are always valid
            return Json(true);
        }
    }
}