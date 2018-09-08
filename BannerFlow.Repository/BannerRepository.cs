using BannerFlow.Repository.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BannerFlow.Repository
{
    public class BannerRepository<T> : IBannerRepository<T> where T : class
    {
        private MongoDatabase _database;
        private MongoCollection<T> _collection;

        public BannerRepository()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["MongoDBConectionString"]);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            var tableName = ConfigurationManager.AppSettings["MongoDBTableName"];
            _database = server.GetDatabase(databaseName);

            _collection = _database.GetCollection<T>("banner");
        }
        /// <summary>
        /// Generic Get method to get record on the basis of id
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T Get(int i)
        {
            return _collection.FindOneById(i);

        }

        /// <summary>
        /// Get all records 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            MongoCursor<T> cursor = _collection.FindAll();
            return cursor.AsQueryable<T>();

        }

        /// <summary>
        /// Generic add method to insert enities to collection 
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _collection.Insert(entity);
        }

        /// <summary>
        /// Generic delete method to delete record on the basis of id
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var query = Query<T>.EQ(GetEquality<T>("Id"), id);
            _collection.Remove(query);
        }

        public Expression<Func<TSource, int>> GetEquality<TSource>(params string[] properties)
        {
            ParameterExpression pe = Expression.Parameter(typeof(TSource), "source");

            Expression lastMember = pe;

            for (int i = 0; i < properties.Length; i++)
            {
                MemberExpression member = Expression.Property(lastMember, properties[i]);
                lastMember = member;
            }
            Expression<Func<TSource, int>> lambda = Expression.Lambda<Func<TSource, int>>(lastMember, pe);
            return lambda;
        }

        /// <summary>
        ///  Generic update method to delete record on the basis of id
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            var query = Query<T>.EQ(GetEquality<T>("Id"), GetPropValue(entity));
            _collection.Update(query, Update<T>.Replace(entity));
        }

        public static int GetPropValue(object src)
        {
            return Convert.ToInt32(src.GetType().GetProperty("Id").GetValue(src, null));
        }
    }
}
