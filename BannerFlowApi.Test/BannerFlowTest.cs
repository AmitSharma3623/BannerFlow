using System;
using BanneFlow.Service;
using BannerFlow.Repository;
using BannerFlow.Repository.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BannerFlowApi.Test
{
    [TestClass]
    public class BannerFlowTest
    {
        [TestMethod]
        public void GetBanner()
        {
            var repository = new Mock<IBannerRepository<BannerModel>>(MockBehavior.Strict);
            repository.Setup(r => r.Get(1))
              .Returns(new BannerModel { Id = 1, Html = "<h1>Testing Html</h1>", Created = DateTime.Now });
            var result = new Banner<BannerModel>(repository.Object).Get(1);

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("<h1>Testing Html</h1>", result.Html);

            repository.VerifyAll();
        }

        [TestMethod]
        public void GetBanner_NullResult()
        {
            var repository = new Mock<IBannerRepository<BannerModel>>(MockBehavior.Strict);
            repository.Setup(r => r.Get(It.IsAny<int>())).Returns((BannerModel)null);

            var result = new Banner<BannerModel>(repository.Object).Get(It.IsAny<int>());

            Assert.IsNull(result);
            repository.VerifyAll();

        }
        [TestMethod]
        public void InsertBanner()
        {
            BannerModel bannerM = new BannerModel { Id = 5, Html = "<h1>Testing insert banner</h1>", Created = DateTime.Now };
            var repository = new Mock<IBannerRepository<BannerModel>>(MockBehavior.Strict);
            repository.Setup(r => r.Add(bannerM)).Verifiable();

            var temp = new Banner<BannerModel>(repository.Object);
            temp.Insert(bannerM);
            repository.VerifyAll();
        }
        [TestMethod]
        public void InsertBanner_Null()
        {
            BannerModel bannerM = new BannerModel();
            var repository = new Mock<IBannerRepository<BannerModel>>(MockBehavior.Strict);
            repository.Setup(r => r.Add(bannerM)).Verifiable();

            var temp = new Banner<BannerModel>(repository.Object);
            temp.Insert(bannerM);
            repository.VerifyAll();
        }

        [TestMethod]
        public void UpdateBanner()
        {
            BannerModel bannerM = new BannerModel { Id = 1, Html = "<h1>Testing update banner 1</h1>", Created = DateTime.Now };
            var repository = new Mock<IBannerRepository<BannerModel>>(MockBehavior.Strict);
            repository.Setup(r => r.Update(bannerM)).Verifiable();

            var temp = new Banner<BannerModel>(repository.Object);
            temp.Update(bannerM);
            repository.VerifyAll();
        }

        [TestMethod]
        public void UpdateBanner_Null()
        {
            BannerModel bannerM = new BannerModel();
            var repository = new Mock<IBannerRepository<BannerModel>>(MockBehavior.Strict);
            repository.Setup(r => r.Update(It.IsAny<BannerModel>())).Verifiable();

            var temp = new Banner<BannerModel>(repository.Object);
            temp.Update(It.IsAny<BannerModel>());
            repository.VerifyAll();
        }

        [TestMethod]
        public void DeleteBanner()
        {
            var repository = new Mock<IBannerRepository<BannerModel>>(MockBehavior.Strict);
            repository.Setup(r => r.Delete(1)).Verifiable();

            var temp = new Banner<BannerModel>(repository.Object);
            temp.Delete(1);
            repository.VerifyAll();
        }

        [TestMethod]
        public void DeleteBanner_Null()
        {
            var repository = new Mock<IBannerRepository<BannerModel>>(MockBehavior.Strict);
            repository.Setup(r => r.Delete(It.IsAny<int>())).Verifiable();

            var temp = new Banner<BannerModel>(repository.Object);
            temp.Delete(It.IsAny<int>());
            repository.VerifyAll();
        }
    }
}
