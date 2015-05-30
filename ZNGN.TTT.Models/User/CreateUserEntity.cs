namespace ZNGN.TTT.Models.User
{
    #region Using Directive
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZNGN.TTT.Models.Common;
    #endregion

    public class CreateUserEntity : ResponseEntity
    {
        public enum Status : int
        {
            Error = 0,
            Success = 1,
            Fail = 2,
            EmailExist = 3,
            UsernameExist = 4,
            EntityCanNotNull = 5,
            ApplicationNotFound = 6
        }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long ApplicationID { get; set; }
    }
}
