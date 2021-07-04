using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sleet.Server.Data;
using Sleet.Shared.Models;

namespace Sleet.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase {
        private ApplicationDbContext _dbContext;
        private ILogger<ProjectController> _logger;

        public ProjectController(ApplicationDbContext dbContext, ILogger<ProjectController> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public List<Project> GetAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<Project> GetAsync(Guid id) {
            return await _dbContext.Projects.SingleAsync(_ => _.Id == id);
        }
    }
}
