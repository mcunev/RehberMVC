﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberMVC.Identity
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
