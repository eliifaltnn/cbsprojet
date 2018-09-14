using OpenLayers2.Models;
using OpenLayers2.Models.KapiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenLayers2.Controllers
{
    public class DoorController : Controller
    {
        OpenLayerEntities ctx = new OpenLayerEntities();

        [HttpPost]
        public JsonResult KapiBilgisiGonder(KapiModel kapi)
        {
            Door yeniKapi = new Door();

            yeniKapi.DoorNo = kapi.DoorNo;
            yeniKapi.Coordinates = kapi.Coordinates;
            yeniKapi.StreetId = kapi.StreetId;

            ctx.Door.Add(yeniKapi);
            ctx.SaveChanges();

            return Json("Kapı başarıyla POST edilmiştir.", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TumKapilariGetir()
        {
            try
            {
                var mList = ctx.Door.ToList();
                return Json(new { result = true, data = mList }, JsonRequestBehavior.AllowGet );
            }
            catch (Exception)
            {
                return Json(new { result = false });
            }

        }
    }
}