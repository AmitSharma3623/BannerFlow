using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BannerFlowWeb.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace BannerFlowWeb.Controllers
{
    public class BannerController : Controller
    {
        // GET: Banner
        public async Task<ActionResult> Index()
        {
            List<BannerModel> banner = new List<BannerModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri("http://localhost:55462");
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/bannerflow");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api 
                    var bannerResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    banner = JsonConvert.DeserializeObject<List<BannerModel>>(bannerResponse);
                }
                //returning the employee list to view
                return View(banner);
            }
        }

        // GET: Banner/Details/5
        public async Task<ActionResult> Details(int id)
        {
           BannerModel banner = new BannerModel();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri("http://localhost:55462");
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/bannerflow/" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api 
                    var bannerResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    banner = JsonConvert.DeserializeObject<BannerModel>(bannerResponse);
                }
                //returning the employee list to view
                return View(banner);
            }
        }

        public async Task<ActionResult> HtmlDetails(int id)
        {
            string banner = string.Empty;
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri("http://localhost:55462");
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/bannerflow/GetHtml?id=" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api 
                    var bannerResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    banner = JsonConvert.DeserializeObject<string>(bannerResponse);
                }
                //returning the employee list to view
                return View(banner);
            }
        }
        //// GET: Banner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Html,Created,Modified")] BannerModel bannerModel)
        {
            Random _r = new Random();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55462");
                bannerModel.Id = _r.Next() ;
                bannerModel.Created = DateTime.Now;
                var myContent = JsonConvert.SerializeObject(bannerModel);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage result = await client.PostAsync("api/bannerflow/", byteContent);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(bannerModel);              
        }

        // GET: Banner/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            BannerModel banner = new BannerModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri("http://localhost:55462");
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/bannerflow/" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api 
                    var bannerResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    banner = JsonConvert.DeserializeObject<BannerModel>(bannerResponse);
                }
                //returning the employee list to view
                return View(banner);
            }
           
        }

        // POST: Banner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Html,Created,Modified")] BannerModel bannerModel)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55462");
                    bannerModel.Modified = DateTime.Now;
                    var myContent = JsonConvert.SerializeObject(bannerModel);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage result = await client.PutAsync("api/bannerflow/", byteContent);

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(bannerModel);
        }

        // GET: Banner/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55462");
                HttpResponseMessage result = await client.DeleteAsync("api/bannerflow/"+ id);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return null;
          
        }
       
    }
}
