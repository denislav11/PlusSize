namespace PlusSize.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<PlusSizeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PlusSize.Data.PlusSizeContext";
        }

        protected override void Seed(PlusSizeContext context)
        {
           

            //context.Products.AddOrUpdate(ent => ent.Title,
            //new Product[]
            //{
            //            new Product {
            //        ImageUrl = "http://maxi-moda.com/image/cache/data/73746-maksi-roklya-peperuda-973-950x1428.jpg",
            //        Model = "73746",
            //        Price = 95,
            //        Quantity = 12,
            //        Title = "Second Maxi Dress",
            //            }
            //            ,
            //             new Product {
            //        ImageUrl = "http://maxi-moda.com/image/cache/data/73821-oficialna-maksi-roklya-daniela-1053-950x1428.jpg",
            //        Model = "73821",
            //        Price = 59,
            //        Quantity = 10,
            //        Title = "First Maxi Dress"
            //    }});
            //context.Categories.AddOrUpdate(ent => ent.Title,
            //    new Category[]
            //    {
            //        new Category
            //        {
            //            Title="Jeans"
            //        },
            //        new Category
            //        {
            //            Title="Shorts"
            //        } , new Category
            //        {
            //            Title="Skirts"
            //        },
            //        new Category
            //        {
            //            Title="Swimwear"
            //        },  new Category
            //        {
            //            Title="Tops"
            //        },
            //        new Category
            //        {
            //            Title="Trousers"
            //        },
            //        new Category
            //        {
            //            Title="Coats"
            //        }
            //});

        }
    }
}
