using CoreBirim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreBirim.Controllers
{
    public class PersonelimController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler= c.Personels.Include(x=>x.Birim).ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=x.BirimAd,
                                                 Value=x.BirimId.ToString(),
                                             }).ToList();
            ViewBag.dgr= degerler;
            return View();
        }
        public IActionResult YeniPersonel(Personel p)
        {
            var per = c.Birims.Where(x => x.BirimId == p.Birim.BirimId).FirstOrDefault();
            p.Birim = per;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
