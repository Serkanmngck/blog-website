using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager=new WriterManager(new EfWriterRepository()); 
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult test()
        {
            return View();
        }
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var values = writerManager.TGetById(1);  // ID 1 ile Writer'ı getir
            return View(values);
        }

        // Profil düzenleme (POST) metodu
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            // Kullanıcı validasyonu yapılıyor
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(writer);

            if (result.IsValid)
            {
                // Güncellenmek istenen writer'ın ID'sini kontrol et
                if (writer.WriterID > 0)
                {
                    // ID'si olan bir Writer'ı güncellemeye çalışıyoruz
                    writerManager.TUpdate(writer);
                    return RedirectToAction("Index", "Dashboard");  // Başarıyla güncellendikten sonra Dashboard'a yönlendir
                }
                else
                {
                    ModelState.AddModelError("Id", "Geçersiz ID");  // ID geçersizse hata mesajı ekle
                }
            }
            else
            {
                // Validasyon hataları varsa her birini ModelState'e ekle
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(writer);  // Hata varsa formu tekrar göster
        }
    }

}
