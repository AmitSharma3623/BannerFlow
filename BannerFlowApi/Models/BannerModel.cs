using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerFlowApi.Models
{
    public class BannerModel
    {
        public ObjectId Id { get; set; }
        public string Html { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}