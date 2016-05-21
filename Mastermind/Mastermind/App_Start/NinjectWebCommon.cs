[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Mastermind.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Mastermind.App_Start.NinjectWebCommon), "Stop")]

namespace Mastermind.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Domain.Interfaces.Repositories;
    using Infra.Data.Repositories;
    using Domain.Interfaces.Services;
    using Mehdime.Entity;
    using Application.Interfaces;
    using Application;
    using Domain.Services;
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
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IGameService>().To<GameService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IGuessService>().To<GuessService>();


            kernel.Bind<IDbContextScopeFactory>().To<DbContextScopeFactory>();
            kernel.Bind<IAmbientDbContextLocator>().To<AmbientDbContextLocator>();

            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IGameAppService>().To<GameAppService>();
            kernel.Bind<IGuessAppService>().To<GuessAppService>();
            
            //kernel.Bind<IMapper>().ToConstant<IMapper>(AutoMapperConfig.RegisterMappings()).InSingletonScope();
        }        
    }
}
