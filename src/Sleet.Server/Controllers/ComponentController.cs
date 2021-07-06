using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sleet.Server.Data;
using Sleet.Shared.Models;

namespace Sleet.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComponentController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public ComponentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IAsyncEnumerable<Component> GetAsync()
        { 
            return _dbContext.Components.AsAsyncEnumerable();
        }

        [HttpPost]
        public async Task PostAsync(Component component)
        {
            if (_dbContext.Components.Any(_=>_.Id==component.Id))
            {
                throw new Exception();
            }
            await _dbContext.Components.AddAsync(component);
            await _dbContext.SaveChangesAsync();
        }
    }
}
