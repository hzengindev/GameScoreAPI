using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZNGN.TTT.Api.Business;
using ZNGN.TTT.Api.Filter;
using ZNGN.TTT.Models.Common;
using ZNGN.TTT.Models.User;

namespace ZNGN.TTT.Api.Controllers
{
    public class UserController : BaseApiController
    {
        [HttpGet]
        [Authentication]
        public ResponseEntity Get(int id)
        {
            ResponseEntity responseEntity = ModelState.IsValid ? new UserBusiness().GetUser(id) : base.SetModelState();

            return responseEntity;
        }

        [HttpPost]
        public ResponseEntity Post([FromBody] CreateUserEntity request)
        {
            ResponseEntity responseEntity = ModelState.IsValid ? new UserBusiness().CreateUser(request) : base.SetModelState();

            return responseEntity;
        }
        
    }
}
