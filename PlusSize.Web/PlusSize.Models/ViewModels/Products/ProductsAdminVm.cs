﻿namespace PlusSize.Models.ViewModels.Products
{
    public class ProductsAdminVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Model { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string CategoryTitle { get; set; }
    }
}
