namespace ZNGN.TTT.Models.Score
{
    #region Using Directive

    using System;
    using System.ComponentModel.DataAnnotations;
    using ZNGN.TTT.Models.Common;

    #endregion Using Directive

    public class CreateScoreEntity : ResponseEntity
    {
        public enum Status : int
        {
            Error = 0,
            Success = 1,
            Fail = 2,
            EntityCanNotNull = 3,
            ApplicationNotFound = 4
        }

        [Required]
        public long ApplicationID { get; set; }

        [Required]
        public long UserID { get; set; }

        [Required]
        public decimal Score { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}