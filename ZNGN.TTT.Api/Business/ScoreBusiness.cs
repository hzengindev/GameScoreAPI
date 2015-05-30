namespace ZNGN.TTT.Api.Business
{
    #region Using Directive
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ZNGN.TTT.Api.Data;
    using ZNGN.TTT.Models.Authentication;
    using ZNGN.TTT.Models.Common;
    using ZNGN.TTT.Models.Score;
    #endregion

    public class ScoreBusiness
    {
        private TTTApiEntities _context;

        public ScoreBusiness()
        {
            if (_context == null)
            {
                _context = new TTTApiEntities();
            }
        }


        public ResponseEntity CreateScore(CreateScoreEntity request, SessionEntity currentSession)
        {
            ResponseEntity entity = new ResponseEntity();
            bool existApplicationID = _context.Application.Any(z => z.ID == request.ApplicationID);

            if (!existApplicationID)
            {
                entity.StatusCode = (int)CreateScoreEntity.Status.ApplicationNotFound;
            }


            if (request == null)
            {
                entity.StatusCode = (int)CreateScoreEntity.Status.EntityCanNotNull;
            }

            if (existApplicationID && request != null)
            {
                Score score = new Score
                {
                    ApplicationID = request.ApplicationID,
                    CreatedDate = request.CreatedDate,
                    ScoreValue = request.Score,
                    UserID = currentSession.ID
                };

                try
                {
                    _context.Score.Add(score);
                    _context.SaveChanges();

                    entity.StatusCode = (int)CreateScoreEntity.Status.Success;
                }
                catch (Exception)
                {
                    entity.StatusCode = (int)CreateScoreEntity.Status.Fail;
                }
            }

            return entity;
        }
    }
}