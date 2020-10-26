using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Entity;
using Website.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class ArticleController : Controller
    {
        private IYaziRepository _yaziRepository;
        public ArticleController(IYaziRepository yaziRepo)
        {
            _yaziRepository = yaziRepo;
        }

        public IActionResult List()
        {
            return View(_yaziRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Yazi entity)
        {
            if (ModelState.IsValid)
            {
                entity.Yazar = "Baştürk Cam";
                _yaziRepository.Add(entity);
                _yaziRepository.Save();

                TempData["message"] = $"{ entity.Baslik} Kayıt Edildi.";
                return RedirectToAction("List", "Article");
            }

            return View(entity);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _yaziRepository.Find(m => m.Id == id).FirstOrDefault();
            return View(model);

        }
        [HttpPost]
        public IActionResult Update(Yazi entity)
        {

            if (ModelState.IsValid)
            {
                var yazi = _yaziRepository.Get(entity.Id);
                if (yazi != null)
                {
                    yazi.Baslik = entity.Baslik;
                    yazi.Icerik = entity.Icerik;
                    yazi.Dil = entity.Dil;
                }
                _yaziRepository.Update(yazi);
                TempData["message"] = $"{entity.Baslik} güncellendi.";
                return RedirectToAction("List", "Article");
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
            var model = _yaziRepository.Find(m => m.Id == id).FirstOrDefault();
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
            var model = _yaziRepository.Find(m => m.Id == id).FirstOrDefault();
            _yaziRepository.Delete(model.Id);
            return RedirectToAction("List", "Article");
        }
    }
}