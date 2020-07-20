using System;
using System.Collections.Generic;

namespace API.Models.db
{
    public partial class House
    {
        public string IdHouse { get; set; }
        public string IdNumber { get; set; }
        public string LaneHouse { get; set; }
        public string ColorHouse { get; set; }
        public string AreaHouse { get; set; }

        public virtual Information IdNumberNavigation { get; set; }
    }
}
