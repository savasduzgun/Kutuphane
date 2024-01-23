using Microsoft.AspNetCore.Mvc;
using Kutuphane.Models;

namespace Kutuphane.Controllers
{
    public class BookController : Controller
    {
        static List<Kitap> kitaplar = new List<Kitap>();
        public IActionResult Kitaplar()
        {
            if (kitaplar.Count == 0)
            {
                for (int i = 1; i <= 15; i++)
                {
                    Kitap kitap = new Kitap
                    {
                        Id = i,
                        Name = "Kitap Adı",
                        Author = "Yazar",
                        Publisher = "Yayın Evi",
                        Tur = i % 2 == 0 ? Turler.Roman : Turler.Hikaye,
                        Stock = i % 2 == 0 ? false : true,
                    };
                    kitaplar.Add(kitap);
                }
            }
            return View(kitaplar);
        }

        //GET : /Book/KitapDetay/id
        public IActionResult KitapDetay(int id)
        {
            //select top 1 * from dbo.Kitap as where k.kitaplar Id=1
            Kitap kitap = kitaplar.FirstOrDefault(x => x.Id == id);

            return View(kitap);
        }

        //GET: /Book/Create
        public IActionResult Create()
        {
            return View();
        }

        //GET
        //POST : Kayıt ekleme işlemleri için data post eder
        //PUT : Güncelleme işlemleri için data post eder
        //DELETE : Silme işlemleri için kullanılır
        //DELETE : Silme işlemleri için kullanılır
        //PATH : Post ve Put un birleşimi
        [HttpPost]
        public IActionResult Create(Kitap model)
        {
            kitaplar.Add(model);
            //return View("Kitaplar", kitaplar);
            //return RedirectToAction("Kitaplar");
            return RedirectToAction(nameof(Kitaplar));
        }
        //GET : /Book/Edit/id
        public IActionResult Edit(int id)
        {
            Kitap kitap = kitaplar.FirstOrDefault(k => k.Id == id);
            return View(kitap);
        }

        [HttpPost]
        public IActionResult Edit(Kitap model)
        {
            int index = kitaplar.IndexOf(kitaplar.Find(k => k.Id == model.Id));
            kitaplar[index] = model;
            return RedirectToAction(nameof(Kitaplar));
        }
        //GET : /Book/Delete/id
        public IActionResult Delete(int id)
        {
            Kitap kitap = kitaplar.FirstOrDefault(k => k.Id == id);
            return View(kitap);
        }
        //POST : /Book/Delete/id
        [HttpPost]
        public IActionResult Delete(int id, Kitap model)
        {
            Kitap kitap = kitaplar.FirstOrDefault(k => k.Id == id);
            kitaplar.Remove(kitap);
            return RedirectToAction(nameof(Kitaplar));
        }
    }
}
