using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace NIC_Assessment.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
