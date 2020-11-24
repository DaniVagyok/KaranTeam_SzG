using KaranTeam.Services;
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
    [Route("api/caff")]
    [ApiController]
    [Authorize]
    public class CaffFileController : ControllerBase
    {
        public ICaffFileService CaffFileService { get; }
        public CaffFileController(ICaffFileService service)
        {
            CaffFileService = service;
        }
    }
}
