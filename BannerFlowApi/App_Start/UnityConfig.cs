using BanneFlow.Service;
using BannerFlow.Repository;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace BannerFlowApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType(typeof(IBanner<>), typeof(Banner<>));
            container.RegisterType(typeof(IBannerRepository<>), typeof(BannerRepository<>));

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}