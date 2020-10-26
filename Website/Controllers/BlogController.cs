using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Website.Entity;
using Website.Models;
using Website.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Website.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _blogRepository;
        private IKategoriRepository _kategoriRepository;
        public BlogController(IBlogRepository blogRepo, IKategoriRepository kategoriRepo)
        {
            _blogRepository = blogRepo;
            _kategoriRepository = kategoriRepo;
        }

        public IActionResult List()
        {
            return View(_blogRepository.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.BlogKategoriler = new SelectList(_kategoriRepository.GetAll(), "Id", "Adi");
            return View(new Blog());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Blog entity, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    var image = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img\\OneCikanGorsel", img.FileName);
                    using (var stream = new FileStream(image, FileMode.Create))
                    {
                        await img.CopyToAsync(stream);
                        entity.OneCikanGorsel = img.FileName;
                    }
                }
                entity.OlusturulmaTarihi = DateTime.Now;
                entity.Yazar = "Baştürk Cam";
                _blogRepository.Add(entity);
                _blogRepository.Save();
                TempData["message"] = $"{ entity.Baslik} Kayıt Edildi.";
                return RedirectToAction("List", "Blog");
            }
            return View(entity);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = new BlogUpdateViewModel
            {
                Blog = _blogRepository.Get(id),
                BlogKategori = _kategoriRepository.GetAll()

            };
            ViewBag.BlogKategoriler = new SelectList(_kategoriRepository.GetAll(), "Id", "Adi");
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(BlogUpdateViewModel entity, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                var blog = _blogRepository.Get(entity.Blog.Id);
                if (blog != null)
                {
                    blog.Baslik = entity.Blog.Baslik;
                    blog.Icerik = entity.Blog.Icerik;
                    blog.KategoriId = entity.Blog.KategoriId;
                    if (img != null)
                    {
                        var image = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img\\OneCikanGorsel", img.FileName);


                        using (var stream = new FileStream(image, FileMode.Create))
                        {
                            img.CopyToAsync(stream);

                            blog.OneCikanGorsel = img.FileName;
                        }
                    }

                    _blogRepository.Update(blog);
                    TempData["message"] = $"{ entity.Blog.Baslik} Kayıt Edildi.";
                    return RedirectToAction("List", "Blog");
                }
            }


            ViewBag.BlogKategoriler = new SelectList(_kategoriRepository.GetAll(), "Id", "Adi");
            return View(entity);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = _blogRepository.Find(b => b.Id == id).FirstOrDefault();
            if (blog==null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var blog = _blogRepository.Find(b => b.Id == id).FirstOrDefault();
            _blogRepository.Delete(blog.Id);
            _blogRepository.Save();
            return RedirectToAction("List","Blog");
        }

    }
}