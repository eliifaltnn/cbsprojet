using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenLayers2.Models.KapiModel
{
    public class KapiModel
    {
        public int Id { get; set; }
        public string DoorNo { get; set; }
        public int StreetId { get; set; }
        public string Coordinates { get; set; }
    }
}