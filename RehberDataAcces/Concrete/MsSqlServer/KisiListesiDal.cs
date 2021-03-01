using Microsoft.EntityFrameworkCore;
using Rehber.Entity;
using RehberDataAcces.Abstract;
using RehberDataAcces.Concrete.MsSqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RehberDataAcces.Concrete
{
    public class KisiListesiDal : EfRehberGenericRepository<KisiListesi, SqlServerContext>, IKisiListesiDal
    {
        public void DeleteFromKisiListesi(int id)
        {
            using (var db = new SqlServerContext())
            {
                var cmd = @"delete from ProductCategory Where id = @p0 ";
                db.Database.ExecuteSqlRaw(cmd, id);
            }
        }
    }
}
