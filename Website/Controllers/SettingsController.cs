using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Entity;
using Website.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class SettingsController : Controller
    {
        private IAyarRepository _ayarRepository;
        public SettingsController(IAyarRepository ayarRepo)
        {
            _ayarRepository = ayarRepo;
        }
        public IActionResult List()
        {
            return View(_ayarRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ayar entity)
        {
            if (ModelState.IsValid)
            {
                _ayarRepository.Add(entity);
                _ayarRepository.Save();
                TempData["message"] = "Kayıt Eklendi";
                return RedirectToAction("List","Settings");
            }
            return View(entity);
        }

    }
}