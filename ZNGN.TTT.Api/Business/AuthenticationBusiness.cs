namespace ZNGN.TTT.Api.Factory
{
    #region Using Directive
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZNGN.TTT.Models.Authentication;
    using System.Data.Entity;
    using Newtonsoft.Json;
    using ZNGN.TTT.Api.Data;
    using ZNGN.TTT.Api.Constants;
    #endregion

    public class AuthenticationBusiness
    {
        TTTApiEntities _context;

        public AuthenticationBusiness()
        {
            if (_context == null)
            {
                _context = new TTTApiEntities();
            }
        }

        public LoginResultModel Login(LoginModel request)
        {
            LoginResultModel response = new LoginResultModel();

            User user = _context.User.Where(z => z.Username.Equals(request.Username) && z.Password.Equals(request.Password)).FirstOrDefault();

            if (user != null)
            {
                Application application = _context.Application.FirstOrDefault(z => z.ApiKey.Equals(request.ApiKey));

                if (application != null)
                {
                    if (application.Status == 1)
                    {
                        Session existSession = _context.Session.FirstOrDefault(z => z.UserID == user.ID && z.ExpireDate > DateTime.Now);

                        if (existSession != null)
                        {
                            response.Status = LoginResultModel.AuthenticationStatus.Success;
                            response.Token = existSession.Token;
                        }
                        else
                        {
                            //TODO : ExpireDate saate çevrilebilir
                            Session session = new Session
                            {
                                ApplicationID = application.ID,
                                UserID = user.ID,
                                Token = Guid.NewGuid().ToString("N"),
                                ExpireDate = DateTime.Now.AddMinutes(CommonConstants.SessionDurationMinutes)
                            };

                            try
                            {
                                _context.Session.Add(session);
                                _context.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }

                            response.Status = LoginResultModel.AuthenticationStatus.Success;
                            response.Token = session.Token;

                            
                        }
                    }
                    else
                    {
                        response.Status = LoginResultModel.AuthenticationStatus.ApiKeyIsPassive;
                    }
                }
                else
                {
                    response.Status = LoginResultModel.AuthenticationStatus.ApiKeyNotFound;
                }
            }
            else
            {
                response.Status = LoginResultModel.AuthenticationStatus.UsernameOrPasswordWrong;
            }

            return response;
        }

        public SessionEntity ApplicationSessionCheck(string token)
        {
            SessionEntity sessionModel = new SessionEntity();

            Session sessionCheck = _context.Session.FirstOrDefault(z => z.Token.Equals(token));

            if (sessionCheck != null && sessionCheck.ExpireDate > DateTime.Now)
            {
                sessionModel.ApplicationID = sessionCheck.ApplicationID;
                sessionModel.Email = sessionCheck.User.Email;
                sessionModel.ID = sessionCheck.User.ID;
                sessionModel.Name = sessionCheck.User.Name;
                sessionModel.Surname = sessionCheck.User.Surname;
                sessionModel.Token = sessionCheck.Token;
                sessionModel.Username = sessionCheck.User.Username;
            }
            else if (sessionCheck != null)
            {
                sessionCheck.ExpireDate = DateTime.Now.AddMinutes(10);

                _context.SaveChanges();

                sessionModel.ApplicationID = sessionCheck.ApplicationID;
                sessionModel.Email = sessionCheck.User.Email;
                sessionModel.ID = sessionCheck.User.ID;
                sessionModel.Name = sessionCheck.User.Name;
                sessionModel.Surname = sessionCheck.User.Surname;
                sessionModel.Token = sessionCheck.Token;
                sessionModel.Username = sessionCheck.User.Username;
            }

            return sessionModel;
        }
    }
}
