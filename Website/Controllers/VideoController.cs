using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Entity;
using Website.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class VideoController : Controller
    {
        private IVideoRepository _videoRepository;
        public VideoController(IVideoRepository videoRepo)
        {
            _videoRepository = videoRepo;
        }
        public IActionResult List()
        {
            return View(_videoRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Video entity)
        {
            if (ModelState.IsValid)
            {
                _videoRepository.Add(entity);
                _videoRepository.Save();
                TempData["message"] = $"{entity.Adi} eklenmiştir.";
                return RedirectToAction("List", "Video");
            }
            return View(entity);
        }
    }
}