using MarketPlace.MVC.Data;
using MarketPlace.MVC.Models;
using MarketPlaceExam.Business.Services;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Repos;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//Transients
RegisterServices(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

////using (var scope = app.Services.CreateScope())
////{
////    var services = scope.ServiceProvider;

////    SeedData.Initialize(services);
////}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

// Registrer your services using Dependency Injection here!
void RegisterServices(WebApplicationBuilder builder)
{
    // Repositories
    builder.Services.AddTransient<ICartItemRepo, CartItemRepo>();
    builder.Services.AddTransient<ICartRepo, CartRepo>();
    builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();
    builder.Services.AddTransient<IOrderRepo, OrderRepo>();
    builder.Services.AddTransient<IPaymentRepo, PaymentRepo>();
    builder.Services.AddTransient<IPictureRepo, PictureRepo>();
    builder.Services.AddTransient<IProductRepo, ProductRepo>();
    builder.Services.AddTransient<IShipmentRepo, ShipmentRepo>();
    builder.Services.AddTransient<IShipperRepo, ShipperRepo>();
    builder.Services.AddTransient<IStockRepo, StockRepo>();
    builder.Services.AddTransient<ISupplierRepo, SupplierRepo>();
    builder.Services.AddTransient<IUserRepo, UserRepo>();

    // Services 
    builder.Services.AddTransient<ICartItemService, CartItemService>();
    builder.Services.AddTransient<ICartService, CartService>();
    builder.Services.AddTransient<ICategoryService, CategoryService>();
    builder.Services.AddTransient<IOrderService, OrderService>();
    builder.Services.AddTransient<IPaymentService, PaymentService>();
    builder.Services.AddTransient<IPictureService, PictureService>();
    builder.Services.AddTransient<IProductService, ProductService>();
    builder.Services.AddTransient<IShipmentService, ShipmentService>();
    builder.Services.AddTransient<IStockService, StockService>();
    builder.Services.AddTransient<ISupplierService, SupplierService>();
    builder.Services.AddTransient<IUserService, UserService>();
}
