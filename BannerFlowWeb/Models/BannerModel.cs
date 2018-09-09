using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BannerFlowWeb.Models
{
    public class BannerModel
    {
        public int Id { get; set; }
        [Required]
        [AllowHtml]
        public string Html { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}