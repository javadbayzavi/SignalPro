﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Signaler.Models
{
    public class discoveryContext : DbContext
    {
        public discoveryContext(DbContextOptions options) : base(options)
        {
        }

        public discoveryContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=patternproject;Persist Security Info=True;User ID=discovery;Password=1234567890;Encrypt=False;ApplicationIntent=ReadWrite;",
                    opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(30).TotalSeconds)
                    );
            }
        }


    }


}
