using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sleet.Data;
using Sleet.Models;

namespace Sleet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController : ControllerBase
    {
        private ILogger<TranslationController> _logger;
        private ApplicationDbContext _dbContext;

        public TranslationController(ILogger<TranslationController> logger, ApplicationDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public TranslationController(ILogger<TranslationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Translation> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<Translation> GetAsync(Guid id) {
            return await _dbContext.Translations.SingleAsync(_ => _.Id == id);
        }
    }
}
