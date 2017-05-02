using AutoMapper;
using PlusSize.Models.EntityModels;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Models.ViewModels.Blogs;
using PlusSize.Models.ViewModels.Category;
using PlusSize.Models.ViewModels.Home;
using PlusSize.Models.ViewModels.Products;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PlusSize
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigMapper();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Product, ProductInHomeVm>();
                expression.CreateMap<Product, ProductCategoryVm>()
                .ForMember(vm => vm.ShortDescription, opt => opt.MapFrom(model => model.Description.Substring(0, model.Description.Length - 10)));
                expression.CreateMap<Category, AllCategoriesVm>();
                expression.CreateMap<Product, ProductVm>();
                expression.CreateMap<Product, ProductsAdminVm>()
                .ForMember(vm => vm.CategoryTitle, expr => expr.MapFrom(model => model.Category.Title));
                expression.CreateMap<Product, EditProductVm>();
                expression.CreateMap<Product, DeleteProductVm>();
                expression.CreateMap<Category, AdminCategoryVm>();
                expression.CreateMap<Category, EditCategoryVm>();
                expression.CreateMap<Category, DeleteCategoryVm>();
                expression.CreateMap<Blog, AllBlogsVm>()
                .ForMember(vm => vm.AuthorName, expr => expr.MapFrom(model => model.Author.Name))
                .ForMember(vm => vm.ShortContent, expr => expr.MapFrom(model => model.Content.Substring(0, 25) + "..."));
                expression.CreateMap<Blog, AdminAllBlogsVm>()
                .ForMember(vm => vm.AuthorName, expr => expr.MapFrom(model => model.Author.Name));
                expression.CreateMap<Blog, EditBlogVm>();
                expression.CreateMap<Blog, DeleteBlogVm>();
                expression.CreateMap<Blog, DetailsBlogVm>()
                .ForMember(vm => vm.AuthorName, expr => expr.MapFrom(model => model.Author.Name));
                expression.CreateMap<BlogCategory, BlogsCategoriesAdminVm>();
                expression.CreateMap<Order, AdminOrderVm>();
                expression.CreateMap<Order, OrderVm>();
            });
        }
    }
}
