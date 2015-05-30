namespace ZNGN.TTT.Models.User
{
    #region Using Directive
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZNGN.TTT.Models.Common;
    #endregion

    public class UserEntity : ResponseEntity
    {
        public enum Status : int
        {
            Error = 0,
            Success = 1,
            Fail = 2,
            UserNotFound = 3,
        }

        public long ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long ApplicationID { get; set; }
    }
}
