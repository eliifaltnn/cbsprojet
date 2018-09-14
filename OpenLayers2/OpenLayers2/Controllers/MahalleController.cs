using OpenLayers2.Models;
using OpenLayers2.Models.MahalleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenLayers2.Controllers
{
    public class MahalleController : Controller
    {
        
        OpenLayerEntities ctx = new OpenLayerEntities();

        [HttpPost]
        public JsonResult MahalleBilgisiGonder(MahalleModel mahalle)
        {
            Strett yeniMahalle = new Strett();

            yeniMahalle.StreetName = mahalle.StreetName;
            yeniMahalle.Coordinates = mahalle.Coordinates;
            
            ctx.Strett.Add(yeniMahalle);
            ctx.SaveChanges();

            return Json("Mahalle başarıyla POST edilmiştir.", JsonRequestBehavior.AllowGet);
        }

       
        [HttpGet]
        public JsonResult TumMahalleleriGetir()
        {
            try
            {
                var mList = ctx.Strett.ToList();
                return Json(new { result = true, data = mList }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { result = false });
            }
            
        }

        [HttpPost]
        public JsonResult MahalleBilgisiGuncelle(MahalleModel mahalle)
        {
            
            Strett yeniMahalle = new Strett();
            yeniMahalle = ctx.Strett.FirstOrDefault(a => a.Id == mahalle.Id);
            yeniMahalle.Coordinates = mahalle.Coordinates;
            ctx.SaveChanges();

            return Json("Kayıtlar Güncellendi", JsonRequestBehavior.AllowGet);
        }
    }
}