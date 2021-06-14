using System.Collections.Generic;
using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Sleet.Models;

namespace Sleet.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class SuggestionController : ControllerBase {
        private readonly ILogger<Controllers.SuggestionController> _logger;

        public SuggestionController(ILogger<Controllers.SuggestionController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Suggestion> Get() {
            throw new NotImplementedException();
        }
    }
}