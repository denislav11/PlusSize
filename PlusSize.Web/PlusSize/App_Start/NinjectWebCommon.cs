[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PlusSize.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PlusSize.App_Start.NinjectWebCommon), "Stop")]

namespace PlusSize.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Services.Interfaces;
    using Services;
    using Services.Interfaces.Admin;

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
            kernel.Bind<IBlogsService>().To<BlogsService>();
            kernel.Bind<ICartService>().To<CartService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICheckoutService>().To<CheckoutService>();
            kernel.Bind<IHomeService>().To<HomeService>();
            kernel.Bind<IProductsService>().To<ProductsService>();
            kernel.Bind<IUserService>().To<UserService>();


            kernel.Bind<IAdminService>().To<AdminService>();
            kernel.Bind<IAdminOrdersService>().To<AdminOrdersService>();
            kernel.Bind<IAdminProductsService>().To<AdminProductsService>();
            kernel.Bind<IAdminBlogsService>().To<AdminBlogsService>();
            kernel.Bind<IAdminCategoriesService>().To<AdminCategoriesService>();
        }
    }
}
