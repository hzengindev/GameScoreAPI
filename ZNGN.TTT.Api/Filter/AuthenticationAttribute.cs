namespace ZNGN.TTT.Api.Filter
{
    #region Using Directive
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http.Filters;
    using ZNGN.TTT.Api.Constants;
    using ZNGN.TTT.Api.Factory;
    using ZNGN.TTT.Models.Authentication;
    #endregion

    public class AuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {

            HttpRequestMessage request = context.Request;

            string token = string.Empty;
            bool existTokenKey = request.Headers.Any(z => z.Key.Equals("Token"));

            if (existTokenKey)
            {
                token = request.Headers.FirstOrDefault(z => z.Key.Equals("Token")).Value.First();
            }

            if (string.IsNullOrEmpty(token))
            {
                context.ErrorResult = new AuthenticationFailureResult("Token Required", request);
                return;
            }

            AuthenticationBusiness authenticationFactory = new AuthenticationBusiness();
            SessionEntity session = authenticationFactory.ApplicationSessionCheck(token);

            if (session == null || session.ApplicationID == 0)
            {
                context.ErrorResult = new AuthenticationFailureResult("Token Not Found Or Expired", request);
                return;
            }

            context.Request.Properties.Add(CommonConstants.SessionName, session);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public bool AllowMultiple
        {
            get { return false; }
        }
    }
}