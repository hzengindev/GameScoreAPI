namespace ZNGN.TTT.Api.Controllers
{
    #region Using Directive
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using ZNGN.TTT.Api.Business;
    using ZNGN.TTT.Api.Filter;
    using ZNGN.TTT.Models.Common;
    using ZNGN.TTT.Models.Score;
    #endregion

    public class ScoreController : BaseApiController
    {
        [HttpPost]
        [Authentication]
        public ResponseEntity Post([FromBody] CreateScoreEntity request)
        {
            ResponseEntity responseEntity = ModelState.IsValid ? new ScoreBusiness().CreateScore(request, this.CurrentSession) : base.SetModelState();

            return responseEntity;

        }
    }
}
