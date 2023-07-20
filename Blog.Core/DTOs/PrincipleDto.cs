using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class PrincipleDto
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
        public string CookieName { get; set; }
     
    }
}
