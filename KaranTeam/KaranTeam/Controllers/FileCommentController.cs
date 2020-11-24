﻿using KaranTeam.Services;
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
    [Route("api/comment")]
    [ApiController]
    [Authorize]
    public class FileCommentController : ControllerBase
    {
        public IFileCommentService FileCommentService { get; }
        public FileCommentController(IFileCommentService service)
        {
            FileCommentService = service;
        }
    }
}