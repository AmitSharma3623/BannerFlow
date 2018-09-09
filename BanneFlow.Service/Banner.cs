using BannerFlow.Repository;
using BannerFlow.Repository.Models;
using BannerFlow.Repository.UnitOfWork;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BanneFlow.Service
{
    public class Banner<T> : IBanner<T> where T : class
    {
        private readonly IBannerRepository<T> _bannerRepository;

        public Banner(IBannerRepository<T> BannerRepository)
        {
            _bannerRepository = BannerRepository;
        }

        public T Get(int i)
        {
            return _bannerRepository.Get(i);
        }

        public string GetHtml(int id)
        {
            return _bannerRepository.GetHtml(id);

        }

        public IQueryable<T> GetAll()
        {
            return _bannerRepository.GetAll();
        }

        public void Delete(int id)
        {
            _bannerRepository.Delete(id);
           
        }

        public void Insert(T banner)
        {
            _bannerRepository.Add(banner);
        }

        public void Update(T banner)
        {
            _bannerRepository.Update(banner);
        }
        //private readonly BannerUnitOfWork _sUnitOfwork;

        //public Banner()
        //{
        //    _sUnitOfwork = new BannerUnitOfWork();
        //}

        //public BannerModel Get(int i)
        //{
        //    return _sUnitOfwork.Banner.Get(i);
        //}

        //public IQueryable<BannerModel> GetAll()
        //{
        //    return _sUnitOfwork.Banner.GetAll();
        //}

        //public void Delete(int id)
        //{
        //    _sUnitOfwork.Banner.Delete(s => s.Id, id);
        //}

        //public void Insert(BannerModel banner)
        //{
        //    _sUnitOfwork.Banner.Add(banner);
        //}

        //public void Update(BannerModel banner)
        //{
        //    _sUnitOfwork.Banner.Update(s => s.Id, banner.Id, banner);
        //}
    }
}