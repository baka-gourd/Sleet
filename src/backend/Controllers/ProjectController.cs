using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sleet.Models;

namespace Sleet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        [HttpGet]
        public List<Project> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
