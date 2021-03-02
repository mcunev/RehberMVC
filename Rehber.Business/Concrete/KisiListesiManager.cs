using Rehber.Business.Abstract;
using Rehber.Entity;
using RehberDataAcces.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using RehberDataAcces.Abstract;

namespace Rehber.Business.Concrete
{
    public class KisiListesiManager : IKisiListesiService
    {
        private readonly IKisiListesiDal db;

        public KisiListesiManager(IKisiListesiDal kisilistesi)
        {
            db = kisilistesi;
        }

        public void Delete(KisiListesi entity)
        {
            db.Delete(entity);
        }

        public void DeleteFromKisiListesi(int id)
        {
            db.DeleteByID(id);
        }

        public List<KisiListesi> GetAll()
        {
            return db.GetAll();
        }

        public KisiListesi GetById(int id)
        {
            return db.GetById(id);
        }

        public void Insert(KisiListesi entity)
        {
            db.Insert(entity);
        }

        public void Update(KisiListesi entity)
        {
            db.Update(entity);
        }
    }
}
