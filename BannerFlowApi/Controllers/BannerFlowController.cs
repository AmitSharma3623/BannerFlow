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

        // GET api/student/id
        public HttpResponseMessage Get(int id)
        {

            var student = _banner.Get(id);
            if (student != null)
                return Request.CreateResponse(HttpStatusCode.OK, student);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found for provided id.");
        }

        public HttpResponseMessage GetAll()
        {
            var banners = _banner.GetAll();
            if (banners.Any())
                return Request.CreateResponse(HttpStatusCode.OK, banners);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No students found.");
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
