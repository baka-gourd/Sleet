using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Sleet.Models
{
    public class User : IdentityUser<Guid>
    {
        public override Guid Id { get; set; }
        public override string UserName { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
