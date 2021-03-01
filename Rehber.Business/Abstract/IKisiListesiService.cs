using Rehber.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rehber.Business.Abstract
{
   public interface IKisiListesiService
    {
        KisiListesi GetById(int id);
        void Insert(KisiListesi entity);
        void Update(KisiListesi entity);
        void Delete(KisiListesi entity);
        void DeleteFromKisiListesi(int id);
        List<KisiListesi> GetAll();
    }
}
