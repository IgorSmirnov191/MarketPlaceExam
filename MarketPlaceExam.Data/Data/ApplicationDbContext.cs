using MarketPlaceExam.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<User> Users { get; set; }

        // TODO: Add Seeding here
        protected override void OnModelCreating(ModelBuilder builder)
        {

            SeedUsers(builder);
            SeedCarts(builder);
            SeedCategories(builder);
            SeedPictures(builder);
            SeedSuppliers(builder);
            SeedProducts(builder);
            SeedStocks(builder);

        }

        private static void SeedCarts(ModelBuilder builder)
        {
            builder.Entity<Cart>().HasData(
                          new Cart
                          {
                              Id = 1,
                              UserId = 1,
                              Description = "Guest's Cart",
                              AuthToken = ""
                          });
        }

        private static void SeedStocks(ModelBuilder builder)
        {
            builder.Entity<Stock>().HasData(
                          new Stock
                          {
                              Id = 1,
                              ProductId = 1,
                              Quantity = 100
                          });
        }

        private static void SeedUsers(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                            new User
                            {
                                Id = 1,
                                Name = "guest"
                            },
                            new User
                            {
                                Id = 2,
                                Name = "admin"
                            });
        }

        private static void SeedPictures(ModelBuilder builder)
        {
            builder.Entity<Picture>().HasData(
                           new Picture
                           {
                               Id = 1,
                               Uri = "https:///aa-drink.com/uploads/drinks/2021-07-02-02-37-4024760210.png"
                           });
        }

        private static void SeedProducts(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                             new Product
                             {
                                 Id = 1,
                                 Name = "AA Drink Iso Lemon",
                                 Description = "AA Drink Hydration Pet 12 x 0.5 liter",
                                 Price = 12.52m,
                                 StockKeepUnitId = "AAIsoLemon12x500",
                                 QuantityPerUnit = 12,
                                 CategoryId = 1,
                                 SupplierId = 1,
                                 PictureId = 1,

                             });
        }

        private static void SeedSuppliers(ModelBuilder builder)
        {
            builder.Entity<Supplier>().HasData(
                         new Supplier
                         {
                             Id = 1,
                             Name = "UNITED SOFT DRINKS B.V.",
                             Description = "",
                             Address = "Reactorweg 69",
                             City = "Utrecht",
                             ZipCode = "3542 AD",
                             Phone = "030 - 2410590",
                             URL = "https:///aa-drink.com"
                         }

    );
        }

        private static void SeedCategories(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                            new Category
                            {
                                Id = 1,
                                Name = "Sports foods",
                                Description = "Specialised products used to provide a convenient source of nutrients when it is impractical to consume everyday foods"
                            },
                            new Category
                            {
                                Id = 2,
                                Name = "Medical supplements",
                                Description = "Supplements used to prevent or treat clinical issues including diagnosed nutrient deficiencies. Should be used within a larger plan under the expert guidance of a Medical Practitioner/Accredited Sports Dietitian."
                            },
                             new Category
                             {
                                 Id = 3,
                                 Name = "Performance supplements",
                                 Description = "Supplements/ingredients that can support or enhance sports performance. Best used with an individualised and event-specific protocol, with the expert guidance of an Accredited Sports Dietitian."
                             },
                            new Category
                            {
                                Id = 4,
                                Name = "Food Polyphenols",
                                Description = "Food compounds which may have bioactivity including antioxidant and anti-inflammatory properties. May be consumed in food forms (whole or concentrate) or as isolated extracts."
                            },
                            new Category
                            {
                                Id = 5,
                                Name = "Antioxidants",
                                Description = "Compounds often found in foods which protect against oxidative damage from free-radical chemicals."
                            },
                            new Category
                            {
                                Id = 6,
                                Name = "Tastants",
                                Description = "Food derived compounds that interact with receptors in the mouth/ gut to activate the central nervous system."
                            },
                            new Category
                            {
                                Id = 7,
                                Name = "Other",
                                Description = "Compounds which attract interest for potential benefits to body function, integrity and/or metabolism."
                            });
        }
    }
}