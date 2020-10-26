using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Entity;
using Website.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class SliderController : Controller
    {
        private ISliderRepository _sliderRepository;
        public SliderController(ISliderRepository sliderRepo)
        {
            _sliderRepository = sliderRepo;
        }
        public IActionResult List()
        {
            return View(_sliderRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider entity)
        {
            if (ModelState.IsValid)
            {
                _sliderRepository.Add(entity);
                _sliderRepository.Save();
                TempData["message"] = "Slider eklendi.";
                return RedirectToAction("List", "Slider");
            }
            return View(entity);
        }
    }
}