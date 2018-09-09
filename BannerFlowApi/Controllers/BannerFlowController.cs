using BanneFlow.Service;
using BannerFlow.Repository.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BannerFlowApi.Controllers
{
    public class BannerFlowController : ApiController
    {
        private readonly IBanner<BannerModel> _banner;
       
        public BannerFlowController(IBanner<BannerModel> BannerService)
        {
            _banner = BannerService;
        }

        // GET api/banner/id
        public HttpResponseMessage Get(int id)
        {

            var banner = _banner.Get(id);
            if (banner != null)
                return Request.CreateResponse(HttpStatusCode.OK, banner);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Banner not found for id.");
        }

        //eample: api/bannerflow/GetHtml?id=1
        [Route("api/bannerflow/GetHtml")]
        public HttpResponseMessage GetHtml([FromUri] int id)
        {

            var banner = _banner.GetHtml(id);
            if (banner != null)
                return Request.CreateResponse(HttpStatusCode.OK, banner);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Banner not found for id.");
        }
        public HttpResponseMessage GetAll()
        {
            var banners = _banner.GetAll();
            if (banners.Any())
                return Request.CreateResponse(HttpStatusCode.OK, banners);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No banners found.");
        }

        public void Post([FromBody]BannerModel banner)
        {
            _banner.Insert(banner);

        }
        public void Delete(int id)
        {
            _banner.Delete(id);
        }
        public void Put([FromBody]BannerModel banner)
        {
            _banner.Update(banner);
        }
    }
}
