using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sleet.Data;
using Sleet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sleet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private ILogger<LanguageController> _logger;

        public LanguageController(ApplicationDbContext dbContext, ILogger<LanguageController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public IAsyncEnumerable<Language> GetAsync()
        {
            return _dbContext.Languages.AsAsyncEnumerable();
        }

        [HttpGet("{id}")]
        public async Task<Language> GetAsync(Guid id)
        {
            return await _dbContext.Languages.SingleAsync(_ => _.Id == id);
        }
    }
}
