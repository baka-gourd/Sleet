using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sleet.Server.Data;
using Sleet.Shared.Models;

namespace Sleet.Server.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class SuggestionController : ControllerBase {
        private ILogger<SuggestionController> _logger;
        private ApplicationDbContext _dbContext;

        public SuggestionController(ILogger<SuggestionController> logger, ApplicationDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public SuggestionController(ILogger<Controllers.SuggestionController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Suggestion> Get() {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<Suggestion> GetAsync(Guid id) {
            return await _dbContext.Suggestions.SingleAsync(_ => _.Id == id);
        }
    }
}