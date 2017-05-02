using AutoMapper;
using PlusSize.Models.EntityModels;
using PlusSize.Models.ViewModels.Products;
using System.Collections.Generic;
using System.Linq;
using PlusSize.Models.BindingModels.Admin;
using PlusSize.Models.ViewModels.Category;
using PlusSize.Models.ViewModels.Admin;
using System;

namespace PlusSize.Services
{
    public class AdminService : Service
    {
        public IEnumerable<ProductsAdminVm> GetAllProducts()
        {
            IEnumerable<Product> models = this.Context.Products;
            IEnumerable<ProductsAdminVm> vms = Mapper.Instance.Map
                <IEnumerable<Product>, IEnumerable<ProductsAdminVm>>(models);
            return vms;
        }

        public OrderVm GetOrderById(int id)
        {
            Order model = this.Context.Orders.Find(id);
            OrderVm vm = Mapper.Instance.Map<Order, OrderVm>(model);
            return vm;
        }

        public IEnumerable<AdminCategoryVm> GetAllCategoriesForAdmin()
        {
            IEnumerable<Category> models = this.Context.Categories;
            IEnumerable<AdminCategoryVm> vms = Mapper.Instance.Map
                <IEnumerable<Category>, IEnumerable<AdminCategoryVm>>(models);
            return vms;
        }
        public IEnumerable<AllCategoriesVm> GetAllCategoriesTitles()
        {
            IEnumerable<Category> models = this.Context.Categories;
            IEnumerable<AllCategoriesVm> vms = Mapper.Instance.Map
                <IEnumerable<Category>, IEnumerable<AllCategoriesVm>>(models);
            return vms;
        }

        public void DeleteOrder(int id)
        {
            Order order = this.Context.Orders.Find(id);
            this.Context.Orders.Remove(order);
            this.Context.SaveChanges();
        }

        public void AddBlog(AddBlogBm bm, string strCurrentUserId)
        {
            ApplicationUser user = this.Context.Users.Find(strCurrentUserId);
            BlogCategory category = this.Context.BlogCategories.FirstOrDefault(b => b.Title == bm.Category);
            Blog model = new Blog
            {
                UploadDate = DateTime.Now,
                Content = bm.Content,
                Title = bm.Title,
                Author = user,
                Category = category
            };
            this.Context.Blogs.Add(model);
            this.Context.SaveChanges();
        }

        public IEnumerable<AdminOrderVm> GetAllOrders()
        {
            IEnumerable<Order> models = this.Context.Orders.Take(10);
            IEnumerable<AdminOrderVm> vms = Mapper.Instance.Map
                <IEnumerable<Order>, IEnumerable<AdminOrderVm>>(models);
            return vms;
        }

        public void AddCategory(AddCategoryBm bm)
        {
            Category category = new Category
            {
                Title = bm.Title
            };
            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }

        public void EditCategory(EditCategoryBm bm, int id)
        {
            Category model = this.Context.Categories.Find(id);
            model.Title = bm.Title;
            this.Context.SaveChanges();
        }

        public DeleteCategoryVm GetDeletedCategoryById(int id)
        {
            Category model = this.Context.Categories.Find(id);
            DeleteCategoryVm vm = Mapper.Instance.Map<Category, DeleteCategoryVm>(model);
            return vm;
        }

        public EditBlogVm GetBlogById(int id)
        {
            Blog model = this.Context.Blogs.Find(id);
            EditBlogVm vm = Mapper.Instance.Map<Blog, EditBlogVm>(model);
            return vm;
        }

        public void DeleteCategory(int id)
        {
            Category model = this.Context.Categories.Find(id);
            foreach (var product in model.Products.ToList())
            {
                product.Category = null;
            }
            this.Context.Categories.Remove(model);
            this.Context.SaveChanges();
        }

        public DeleteBlogVm GetDeletedBlogById(int id)
        {
            Blog model = this.Context.Blogs.Find(id);
            DeleteBlogVm vm = Mapper.Instance.Map<Blog, DeleteBlogVm>(model);
            return vm;
        }

        public void DeleteBlog(int id)
        {
            Blog model = this.Context.Blogs.Find(id);
            this.Context.Blogs.Remove(model);
            this.Context.SaveChanges();
        }

        public void EditBlog(EditBlogBm bm, int id)
        {
            Blog model = this.Context.Blogs.Find(id);
            model.Title = bm.Title;
            model.Content = bm.Content;
            this.Context.SaveChanges();
        }

        public void AddProduct(AddProductBm bm)
        {
            Product model = new Product
            {
                Description = bm.Description,
                Category = this.Context.Categories.FirstOrDefault(c => c.Title == bm.Category),
                ImageUrl = bm.ImageUrl,
                Model = bm.Model,
                Price = bm.Price,
                Quantity = bm.Quantity,
                Title = bm.Title
            };
            try
            {
                this.Context.Products.Add(model);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public EditProductVm GetProductById(int id)
        {
            Product model = this.Context.Products.Find(id);
            EditProductVm vm = Mapper.Instance.Map<Product, EditProductVm>(model);
            return vm;
        }
        public EditCategoryVm GetCategoryById(int id)
        {
            Category model = this.Context.Categories.Find(id);
            EditCategoryVm vm = Mapper.Instance.Map<Category, EditCategoryVm>(model);
            return vm;
        }

        public void EditProduct(EditProductBm bm, int id)
        {
            Product model = this.Context.Products.Find(id);
            model.Category = this.Context.Categories.FirstOrDefault(c => c.Title == bm.Category);
            model.Description = bm.Description;
            model.ImageUrl = bm.ImageUrl;
            model.Model = bm.Model;
            model.Price = bm.Price;
            model.Quantity = bm.Quantity;
            model.Title = bm.Title;
            this.Context.SaveChanges();
        }

        public DeleteProductVm GetDeletedProductById(int id)
        {
            Product model = this.Context.Products.Find(id);
            DeleteProductVm vm = Mapper.Instance.Map<Product, DeleteProductVm>(model);
            return vm;
        }

        public void DeleteProduct(int id)
        {
            Product model = this.Context.Products.Find(id);
            this.Context.Products.Remove(model);
            this.Context.SaveChanges();
        }

        public IEnumerable<AdminAllBlogsVm> GetAllBlogs()
        {
            IEnumerable<Blog> models = this.Context.Blogs;
            IEnumerable<AdminAllBlogsVm> vms = Mapper.Instance.Map
                <IEnumerable<Blog>, IEnumerable<AdminAllBlogsVm>>(models);
            return vms;
        }

        
    }
}
