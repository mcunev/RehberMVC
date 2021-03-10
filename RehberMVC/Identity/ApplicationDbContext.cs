using Microsoft.EntityFrameworkCore;
using Rehber.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RehberMVC.Identity
{
    class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<KisiListesi> adListesi { get; set; }

        public DbSet<Rehber.Entity.KisiListesi> AdListesi { get; set; }
    }
}

