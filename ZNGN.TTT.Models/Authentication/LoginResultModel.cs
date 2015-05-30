namespace ZNGN.TTT.Models.Authentication
{
    #region Using Directive
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion

    public class LoginResultModel
    {
        public enum AuthenticationStatus : int
        {
            Success = 1,
            ApiKeyNotFound = 2,
            UsernameOrPasswordWrong = 4,
            ApiKeyIsPassive = 8,
            NotAuthorize = 16
        }

        public string Token { get; set; }

        public AuthenticationStatus Status { get; set; }
    }
}
