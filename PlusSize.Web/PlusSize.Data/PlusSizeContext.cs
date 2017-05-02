namespace PlusSize.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System.Data.Entity;

    public class PlusSizeContext : IdentityDbContext<ApplicationUser>
    {
        public PlusSizeContext()
             : base("data source=(LocalDb)\\MSSQLLocalDB;initial catalog=PlusSizeDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", throwIfV1Schema: false)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public static PlusSizeContext Create()
        {
            return new PlusSizeContext();
        }
    }
}