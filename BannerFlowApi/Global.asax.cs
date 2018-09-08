using System.Web.Http;


namespace BannerFlowApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
        }


        //private void RegisterDependencyResolver()
        //{
        //    var kernel = new StandardKernel();

        //    // you may need to configure your container here?
        //    RegisterServices(kernel);

        //    DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        //}

    }
}
