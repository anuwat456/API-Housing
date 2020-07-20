using System;
using System.Collections.Generic;

namespace API.Models.db
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string IdNumber { get; set; }
        public string Password { get; set; }

        public virtual Information IdNumberNavigation { get; set; }
    }
}
