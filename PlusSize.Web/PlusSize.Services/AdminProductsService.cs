using AutoMapper;
using PlusSize.Models.BindingModels.Admin;
using PlusSize.Models.EntityModels;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Models.ViewModels.Category;
using PlusSize.Models.ViewModels.Products;
using PlusSize.Services.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlusSize.Services
{
    public class AdminProductsService : Service, IAdminProductsService
    {
        public IEnumerable<ProductsAdminVm> GetAllProducts()
        {
            IEnumerable<Product> models = this.Context.Products;
            IEnumerable<ProductsAdminVm> vms = Mapper.Instance.Map
                <IEnumerable<Product>, IEnumerable<ProductsAdminVm>>(models);
            return vms;
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
        public IEnumerable<AllCategoriesVm> GetAllCategoriesTitles()
        {
            IEnumerable<Category> models = this.Context.Categories;
            IEnumerable<AllCategoriesVm> vms = Mapper.Instance.Map
                <IEnumerable<Category>, IEnumerable<AllCategoriesVm>>(models);
            return vms;
        }

    }
}
