using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace API.Models.db
{
    public class User : IdentityUser
    {
        public int IdUser { get; set; }
        public string IdNumber { get; set; }
        public string Password { get; set; }

        public virtual Information IdNumberNavigation { get; set; }
    }
}
