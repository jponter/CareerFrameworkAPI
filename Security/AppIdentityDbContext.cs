﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerFrameworkAPI.Security
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        // public constructor
        public AppIdentityDbContext
            (DbContextOptions<AppIdentityDbContext> options)
            : base(options) 
        {
        // left empty
        }
    }
}
