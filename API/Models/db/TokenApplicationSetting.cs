﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.db
{
    public class TokenApplicationSetting
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
