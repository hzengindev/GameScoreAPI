namespace ZNGN.TTT.Api.Controllers
{
    #region Using Directive

    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using ZNGN.TTT.Api.Constants;
    using ZNGN.TTT.Models.Authentication;
    using ZNGN.TTT.Models.Common;

    #endregion Using Directive

    public class BaseApiController : ApiController
    {
        protected SessionEntity CurrentSession
        {
            get
            {
                if (Request.Properties.ContainsKey(CommonConstants.SessionName))
                    return (Request.Properties[CommonConstants.SessionName]) as SessionEntity;

                return null;
            }
        }

        public ResponseEntity SetModelState()
        {
            ResponseEntity responseEntity = new ResponseEntity();

            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();

                foreach (var modelState in ModelState.Values)
                {
                    errors.AddRange(modelState.Errors.Where(z => !string.IsNullOrEmpty(z.ErrorMessage)).Select(z => z.ErrorMessage).ToArray());
                }

                responseEntity.Alerts = errors;
            }

            return responseEntity;
        }

    }
}