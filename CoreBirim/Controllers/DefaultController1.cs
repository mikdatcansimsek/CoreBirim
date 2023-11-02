using CoreBirim.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreBirim.Controllers
{
    public class DefaultController1 : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler =c.Birims.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var dep = c.Birims.Find(id);
            c.Birims.Remove(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimGetir(int id)
        {
            var birim = c.Birims.Find(id);
            return View("BirimGetir", birim);
        }
        public IActionResult BirimGuncelle(Birim d)
        {
            var dep = c.Birims.Find(d.BirimId);
            dep.BirimAd = d.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimDetay(int id)
        {
            var degerler=c.Personels.Where(x=>x.BirimID==id).ToList();
            return View(degerler);
        }
    }
}
