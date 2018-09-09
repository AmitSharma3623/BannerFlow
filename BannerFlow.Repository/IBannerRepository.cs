
using BannerFlow.Repository.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BannerFlow.Repository
{
    public interface IBannerRepository<T> where T : class
    {
        T Get(int i);
        string GetHtml(int i);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);

    }
}