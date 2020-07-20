using System;
using System.Collections.Generic;

namespace API.Models.db
{
    public partial class Information
    {
        public Information()
        {
            House = new HashSet<House>();
            User = new HashSet<User>();
        }

        public string IdNumber { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public string BirthDate { get; set; }
        public string AddressLine { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<House> House { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
