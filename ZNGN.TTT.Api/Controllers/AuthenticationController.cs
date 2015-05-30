namespace ZNGN.TTT.Api.Controllers
{
    #region Using Directive
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using ZNGN.TTT.Api.Factory;
    using ZNGN.TTT.Models.Authentication;
	#endregion

    public class AuthenticationController : ApiController
    {
        [HttpPost]
        public LoginResultModel Login([FromBody]LoginModel request)
        {
            AuthenticationBusiness authenticationFactory = new AuthenticationBusiness();
            LoginResultModel response = authenticationFactory.Login(request);

            return response;
        }

        
    }
}
