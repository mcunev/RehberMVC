using Microsoft.AspNetCore.Mvc;
using Rehber.Business.Abstract;
using Rehber.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rehber.Business.Concrete;
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
            return View();
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
        public IActionResult Edit(string ad, string Aciklama)
        {

            return View();
        }
    }
}
