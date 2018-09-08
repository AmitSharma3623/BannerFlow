using BannerFlow.Repository.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannerFlow.Repository.UnitOfWork
{
    public class BannerUnitOfWork
    {
        private MongoDatabase _database;

        protected BannerRepository<BannerModel> _banner;

        public BannerUnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }
        //public BannerRepository<BannerModel> Banner
        //{
        //    //get
        //    //{
        //    //    if (_banner == null)
        //    //        _banner = new BannerRepository<BannerModel>(_database, "banner");

        //    //    return _banner;
        //    //}
        //}
    }
}
