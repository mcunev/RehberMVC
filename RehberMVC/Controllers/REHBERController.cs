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
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Delete()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Update(int id)
        {
            object p = kisi.GetById(id);
            return View();
        }
       
    }
}
