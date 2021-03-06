[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Cinema.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Cinema.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Cinema.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using Data.Contracts;
    using Data;
    using Data.Repositories;
    using Presenters.Contracts;
    using Data.Models.Contracts;
    using Data.Models;
    using Presenters.FilmScreeningPresenters;

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
            kernel.Bind(typeof(ICinemaDbContext)).To(typeof(CinemaDbContext)).InRequestScope();
            kernel.Bind(typeof(CinemaDbContext)).ToSelf().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();
            kernel.Bind(typeof(IAddMovieView)).To(typeof(AddMovieView));
            kernel.Bind(typeof(IMovieListView)).To(typeof(MoviesListView));
            kernel.Bind(typeof(IMovie)).To(typeof(Movie));
            kernel.Bind(typeof(IFilmScreening)).To(typeof(FilmScreening));
            kernel.Bind(typeof(ISeat)).To(typeof(Seat));
            kernel.Bind(typeof(Seat)).ToSelf();

            kernel.Bind(s => s.From("Cinema.Data.Services")
                             .SelectAllClasses()
                             .BindDefaultInterface());

            kernel.Bind(s => s.From("Cinema.Presenters")
                            .SelectAllClasses()
                            .BindDefaultInterface());
        }        
    }
}
