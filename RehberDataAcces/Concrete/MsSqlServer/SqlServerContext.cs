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
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KisiListesi>()
                .HasKey(k => new { k.id});
        }
        #endregion

        public DbSet<KisiListesi> kisi_listesi;
       
    }
}
