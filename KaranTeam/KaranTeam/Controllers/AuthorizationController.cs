using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthorizationController : ControllerBase
    {
        public IAuthorizationService AuthorizationService { get; }
        public AuthorizationController(IAuthorizationService service)
        {
            AuthorizationService = service;
        }
    }
}
