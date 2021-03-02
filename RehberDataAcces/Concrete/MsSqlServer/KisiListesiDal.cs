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
       
    }
}
