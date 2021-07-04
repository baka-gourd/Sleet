using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sleet.Shared.Models;

namespace Sleet.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComponentController : ControllerBase
    {
        [HttpGet]
        public async IAsyncEnumerable<Component> GetAsync()
        {
            yield return await Task.FromResult(new Component() {Id = new Guid(), Name = "Temp"});
        }

        [HttpPost]
        public async Task PostAsync(Component component)
        {
            throw new NotImplementedException();
        }
    }
}
