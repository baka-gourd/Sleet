using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sleet.Models;

namespace Sleet.Controllers
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
