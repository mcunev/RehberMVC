using Microsoft.EntityFrameworkCore;
using Rehber.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RehberDataAcces.Concrete.MsSqlServer
{
    public class SqlServerContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=RehberMVC;Integrated Security=True");
        }
        public DbSet<KisiListesi> kisi_listesi;
    }
}
