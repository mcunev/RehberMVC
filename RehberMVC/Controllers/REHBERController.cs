using Microsoft.AspNetCore.Mvc;
using Rehber.Business.Abstract;
using Rehber.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rehber.Business.Concrete;
using RehberDataAcces.Concrete;
namespace RehberMVC.Controllers
{
    public class REHBERController : Controller
    {

        private IKisiListesiService kisi;
        public REHBERController(IKisiListesiService kisiler)
        {
            kisi = kisiler;
        }
        public IActionResult Index()
        {
            var result = kisi.GetAll();
            return View(result);
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            var p = kisi.GetById(id);
            kisi.Insert(p);

            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var p = kisi.GetById(id);
            kisi.Delete(p);
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id)
        {
           var p = kisi.GetById(id);
           kisi.Update(p);
            return View();
        }
       public IActionResult Details(int id) 
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var adListesi = kisi.GetById(id);
                if (adListesi == null)
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,Name,LastName,Description,PhoneNumber,Email")] KisiListesi yeniKisi)
        {
            if (ModelState.IsValid)
            {
                kisi.Insert(yeniKisi); 
                
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


    }
}
