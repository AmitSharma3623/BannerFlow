
using BannerFlow.Repository.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanneFlow.Service
{
    public interface IBanner<T> where T: class
    {
        void Insert(T student);
        T Get(int i);
        IQueryable<T> GetAll();
        void Delete(int id);
        void Update(T student);

    }
}