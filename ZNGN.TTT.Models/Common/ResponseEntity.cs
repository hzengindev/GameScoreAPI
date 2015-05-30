namespace ZNGN.TTT.Models.Common
{
    #region Using Directive
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion

    public class ResponseEntity
    {
        public List<string> Alerts { get; set; }

        public int StatusCode { get; set; }

        public object Item { get; set; }
    }
}
