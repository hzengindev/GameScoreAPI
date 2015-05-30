namespace ZNGN.TTT.Api.Business
{
    #region Using Directive

    using System;
    using System.Linq;
    using ZNGN.TTT.Api.Data;
    using ZNGN.TTT.Models.Common;
    using ZNGN.TTT.Models.User;

    #endregion Using Directive

    public class UserBusiness
    {
        private TTTApiEntities _context;

        public UserBusiness()
        {
            if (_context == null)
            {
                _context = new TTTApiEntities();
            }
        }

        public ResponseEntity GetUser(int id)
        {
            ResponseEntity entity = new ResponseEntity();

            User user = _context.User.SingleOrDefault(z => z.ID == id);

            if (user != null)
            {
                UserEntity userEntity = new UserEntity
                {
                    ID = user.ID,
                    ApplicationID = user.ApplicationID,
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname,
                    Username = user.Username
                };

                entity.Item = userEntity;
                entity.StatusCode = (int)UserEntity.Status.Success;
            }
            else
            {
                entity.StatusCode = (int)UserEntity.Status.UserNotFound;
            }

            return entity;
        }

        public ResponseEntity CreateUser(CreateUserEntity request)
        {
            ResponseEntity entity = new ResponseEntity();

            bool existEmail = _context.User.Any(z => z.Email.Equals(request.Email));
            bool existUsername = _context.User.Any(z => z.Username.Equals(request.Username));
            bool existApplicationID = _context.Application.Any(z => z.ID == request.ApplicationID);

            if (request == null)
            {
                entity.StatusCode = (int)CreateUserEntity.Status.EntityCanNotNull;
            }

            if (existEmail)
            {
                entity.StatusCode = (int)CreateUserEntity.Status.EmailExist;
            }

            if (existUsername)
            {
                entity.StatusCode = (int)CreateUserEntity.Status.UsernameExist;
            }

            if (existApplicationID)
            {
                entity.StatusCode = (int)CreateUserEntity.Status.ApplicationNotFound;
            }

            if (!existUsername && !existEmail && request != null)
            {
                User user = new User
                {
                    ApplicationID = request.ApplicationID,
                    Email = request.Email,
                    Name = request.Name,
                    Password = request.Password,
                    Surname = request.Surname,
                    Username = request.Username
                };

                try
                {
                    _context.User.Add(user);
                    _context.SaveChanges();

                    entity.StatusCode = (int)UserEntity.Status.Success;
                }
                catch (Exception)
                {
                    entity.StatusCode = (int)UserEntity.Status.Fail;
                }
            }

            return entity;
        }
    }
}