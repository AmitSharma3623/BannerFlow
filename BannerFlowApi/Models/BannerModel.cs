using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BannerFlowApi.Models
{
    public class BannerModel
    {
        public ObjectId Id { get; set; }
        [AllowHtml]
        public string Html { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}