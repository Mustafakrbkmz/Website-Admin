using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Website.Entity;
using Website.Models;
using Website.Repository.Abstract;
using Website.Repository.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Website.Controllers
{

    public class ProductController : Controller
    {
        private IUrunRepository _urunRepository;
        private IUrunGrupRepository _urunGrupRepository;
        public ProductController(IUrunRepository productRepo, IUrunGrupRepository urunGrupRepo)
        {
            _urunRepository = productRepo;
            _urunGrupRepository = urunGrupRepo;
        }



        public IActionResult List()
        {
            ViewBag.UrunGruplar = new SelectList(_urunGrupRepository.GetAll(), "Id", "Adi");
            return View(_urunRepository.GetAll());
        }


        public IActionResult Create()
        {
            ViewBag.UrunGruplar = new SelectList(_urunGrupRepository.GetAll(), "Id", "Adi");
            return View(new Urun());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Urun entity, IFormFile file, IFormFile file2)
        {
            if (ModelState.IsValid)
            {
                if (file != null) // file1 ve file2 olarak farklı fi blokları yaz
                {
                    var pdf = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\TeknikCizim", file.FileName);
                    var img = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img\\UrunGorsel", file2.FileName);


                    using (var stream = new FileStream(pdf, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        entity.Brosur = file.FileName;
                    }

                }

                if (file2 != null)
                {
                    var extention = Path.GetExtension(file2.FileName);
                    var imgName = string.Format($"{entity.Adi}_{DateTime.Now.Ticks}{extention}");
                    var img = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img\\UrunGorsel", imgName);


                    using (var stream = new FileStream(img, FileMode.Create))
                    {
                        await file2.CopyToAsync(stream);

                        entity.OneCikanGorsel = imgName;
                    }

                }

                _urunRepository.Add(entity);
                _urunRepository.Save();
                TempData["message"] = $"{ entity.Adi} Kayıt Edildi.";
                return RedirectToAction("List", "Product");
            }
            //ViewBag.UrunGruplar = new SelectList(_urunGrupRepository.GetAll(), "Id", "Adi");
            return View(entity);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = new ProductUpdateViewModel
            {
                Urun = _urunRepository.Get(id),
                UrunGrups = _urunGrupRepository.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateViewModel entity, IFormFile file, IFormFile file2)
        {
            if (ModelState.IsValid)
            {
                var urun = _urunRepository.Get(entity.Urun.Id);
                if (urun != null)
                {
                    urun.Adi = entity.Urun.Adi;
                    urun.SiraNo = entity.Urun.SiraNo;
                    urun.Kodu = entity.Urun.Kodu;
                    urun.DolumHacimi = entity.Urun.DolumHacimi;
                    urun.SilmeHacimi = entity.Urun.SilmeHacimi;
                    urun.Boyu = entity.Urun.Boyu;
                    urun.Capi = entity.Urun.Capi;
                    urun.Agirligi = entity.Urun.Agirligi;
                    urun.KafaTipi = entity.Urun.KafaTipi;
                    urun.PaletSiraSayisi = entity.Urun.PaletSiraSayisi;
                    urun.TavaUrunAdedi = entity.Urun.TavaUrunAdedi;
                    urun.PaletIcAdedi = entity.Urun.PaletIcAdedi;
                    urun.PaletYuksekligi = entity.Urun.PaletYuksekligi;
                    urun.PaletAgirligi = entity.Urun.PaletAgirligi;
                    urun.Aciklama = entity.Urun.Aciklama;
                    urun.Dil = entity.Urun.Dil;
                    urun.UrunGrupId = entity.Urun.UrunGrupId;
                    //öne çıkan görsel
                    //broşür


                    // iki dosyadan sadece birini ekleyince patlıyor.
                    // Dosyaları boş gönderirsek veritabanındaki dosyalara gelmiyor borsur ve öneçıkan görsel null kayıt oluyor
                    if (file != null)
                    {
                        var pdf = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\TeknikCizim", file.FileName);


                        using (var stream = new FileStream(pdf, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                            //entity.Urun.Brosur = file.FileName;
                            urun.Brosur = file.FileName;
                        }

                    }

                    if (file2 != null)
                    {
                        var extention = Path.GetExtension(file2.FileName);
                        var imgName = string.Format($"{urun.Adi}_{DateTime.Now.Ticks}{extention}");
                        var img = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img\\UrunGorsel", imgName);


                        using (var stream = new FileStream(img, FileMode.Create))
                        {
                            await file2.CopyToAsync(stream);

                            urun.OneCikanGorsel = imgName;
                        }

                    }

                    _urunRepository.Update(urun);
                    TempData["message"] = $"{ entity.Urun.Adi} Kayıt Edildi.";
                    return RedirectToAction("List", "Product");
                }
            }
            ViewBag.UrunGruplar = new SelectList(_urunGrupRepository.GetAll(), "Id", "Adi");
            return View(entity);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urun = _urunRepository.Find(b => b.Id == id).FirstOrDefault();
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var urun = _urunRepository.Find(b => b.Id == id).FirstOrDefault();
            _urunRepository.Delete(urun.Id);
            _urunRepository.Save();
            return RedirectToAction("List", "Product");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _urunRepository.Find(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult GroupList()
        {
            return View(_urunGrupRepository.GetAll());
        }

        public IActionResult GroupCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GroupCreate(UrunGrup entity)
        {
            if (ModelState.IsValid)
            {
                _urunGrupRepository.Add(entity);
                TempData["message"] = $"{entity.Adi} Başarıyla Eklendi";
                _urunGrupRepository.Save();
                return RedirectToAction("GroupList", "Product");
            }
            return View(entity);
        }
        public IActionResult GroupDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = _urunGrupRepository.Find(g => g.Id == id).FirstOrDefault();
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }
        [HttpPost, ActionName("GroupDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult GroupDeleteConfirmed(int id)
        {
            var group = _urunGrupRepository.Find(g => g.Id == id).FirstOrDefault();
            _urunGrupRepository.Delete(group.Id);
            _urunGrupRepository.Save();
            return RedirectToAction("GroupList", "Product");
        }
        public IActionResult GroupUpdate(int id)
        {
            var group = _urunGrupRepository.Find(g => g.Id == id).FirstOrDefault();

            return View(group);
        }
        [HttpPost]
        public IActionResult GroupUpdate(UrunGrup entity)
        {
            if (ModelState.IsValid)
            {
                var group = _urunGrupRepository.Get(entity.Id);
                if (group != null)
                {
                    group.Adi = entity.Adi;
                    group.Aciklama = entity.Aciklama;
                    group.Dil = entity.Dil;
                }
                _urunGrupRepository.Update(group);
            }

            return RedirectToAction("GroupList", "Product");
        }


    }
}