using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Entity;
using Website.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class CategoryController : Controller
    {
        private IKategoriRepository _kategoriRepository;
        public CategoryController(IKategoriRepository kategoriRepo)
        {
            _kategoriRepository = kategoriRepo;
        }
        public IActionResult List()
        {
            var model = _kategoriRepository.GetAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Kategori entity)
        {
            if (ModelState.IsValid)
            {
                _kategoriRepository.Add(entity);
                _kategoriRepository.Save();
                TempData["message"] = $"{ entity.Adi} Kayıt Edildi.";
                return RedirectToAction("List", "Category");
            }
            return View(entity);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _kategoriRepository.Find(m => m.Id == id).FirstOrDefault();
            return View(model);

        }
        [HttpPost]
        public IActionResult Update(Kategori entity)
        {

            if (ModelState.IsValid)
            {
                var kategori = _kategoriRepository.Get(entity.Id);
                if (kategori != null)
                {
                    kategori.Adi = entity.Adi;
                    kategori.Dil = entity.Dil;
                }
                _kategoriRepository.Update(kategori);
                TempData["message"] = $"{entity.Adi} güncellendi.";
                return RedirectToAction("List", "Category");
            }
            return View(entity);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var model = _kategoriRepository.Find(m => m.Id==id).FirstOrDefault();
            if (model==null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var model = _kategoriRepository.Find(m => m.Id == id).FirstOrDefault();
            _kategoriRepository.Delete(model.Id);
            return RedirectToAction("List", "Category"); ;
        }
    }
}