using Microsoft.AspNet.Identity;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LocadoraS2IT.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LocadoraS2IT.Web.App_Start.NinjectWebCommon), "Stop")]

namespace LocadoraS2IT.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using LocadoraS2IT.Business.Business;
    using LocadoraS2IT.Business.IBusiness;
    using LocadoraS2IT.Data.Repositories;
    using LocadoraS2IT.Data.IRepositories;
    using LocadoraS2IT.Web.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAmigoBusiness>().To<AmigoBusiness>();
            kernel.Bind<IGeneroBusiness>().To<GeneroBusiness>();
            kernel.Bind<IJogoBusiness>().To<JogoBusiness>();
            kernel.Bind<IEmprestimoBusiness>().To<EmprestimoBusiness>();
            

            kernel.Bind<IEmprestimoRepository>().To<EmprestimoRepository>();
            kernel.Bind<IJogoRepository>().To<JogoRepository>();
            kernel.Bind<IGeneroRepository>().To<GeneroRepository>();
            kernel.Bind<IAmigoRepository>().To<AmigoRepository>();

            kernel.Bind<ApplicationDbContext>().ToSelf();
            kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().WithConstructorArgument("context", kernel.Get<ApplicationDbContext>());
            kernel.Bind<UserManager<ApplicationUser>>().ToSelf();

            //kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
            //kernel.Bind<UserManager<ApplicationUser>>().ToSelf();

            //kernel.Bind<HttpContextBase>().ToMethod(ctx => new HttpContextWrapper(HttpContext.Current)).InTransientScope();

            //kernel.Bind<ApplicationSignInManager>().ToMethod((context) =>
            //{
            //    var cbase = new HttpContextWrapper(HttpContext.Current);
            //    return cbase.GetOwinContext().Get<ApplicationSignInManager>();
            //});

            //kernel.Bind<ApplicationUserManager>().ToSelf();
        }        
    }
}
