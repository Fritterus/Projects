using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharing.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public decimal Money { get; set; }
    }
}
