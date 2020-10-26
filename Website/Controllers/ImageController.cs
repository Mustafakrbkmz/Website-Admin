using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Website.Entity;
using Website.Repository.Abstract;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class ImageController : Controller
    {
        private IResimRepository _resimRepository;
        public ImageController(IResimRepository resimRepo)
        {
            _resimRepository = resimRepo;
        }
        public IActionResult List()
        {
            return View(_resimRepository.GetAll());
        }
        public IActionResult Create()
        {
            return View(new Resim());
        }
        [HttpPost]

        public async Task<IActionResult> Create(Resim entity, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var imgName = string.Format($"{entity.Adi}_{DateTime.Now.Ticks}{extention}");
                var img = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img\\Galeri", imgName);


                using (var stream = new FileStream(img, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                    entity.ResimYolu = imgName;
                }

                }
                _resimRepository.Add(entity);
                _resimRepository.Save();
                TempData["message"] = $"{ entity.Adi} Kayıt Edildi.";
                return RedirectToAction("List", "Image");
            }
            return View(entity);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var image = _resimRepository.Find(i => i.Id == id).FirstOrDefault();
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var model = _resimRepository.Find(m => m.Id == id).FirstOrDefault();
            _resimRepository.Delete(model.Id);
            return RedirectToAction("List", "Image");
        }
    }
}