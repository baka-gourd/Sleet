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
        public List<Component> Get()
        {
            throw new NotImplementedException();
        }
    }
}
