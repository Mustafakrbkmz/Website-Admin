using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Entity;
using Website.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class SSSController : Controller
    {
        private ISSSRepository _sssRepository;
        public SSSController(ISSSRepository sssRepo)
        {
            _sssRepository = sssRepo;
        }
        public IActionResult List()
        {
            return View(_sssRepository.GetAll());
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SSS entity)
        {
            if (ModelState.IsValid)
            {
                _sssRepository.Add(entity);
                _sssRepository.Save();
                TempData["message"] = $"{entity.Soru} sorusu eklenmiştir";
                return RedirectToAction("List", "SSS");
            }
            return View(entity);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _sssRepository.Find(m => m.Id == id).FirstOrDefault();
            if (model!=null)
            {
                return View(model);
            }
            return NotFound();
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var model = _sssRepository.Find(m => m.Id == id).FirstOrDefault();
            _sssRepository.Delete(model.Id);
            return RedirectToAction("List", "SSS");
        }
    }
}