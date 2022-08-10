
using MarketPlaceExam.Business.Configuration;
using MarketPlaceExam.Business.Services;
using MarketPlaceExam.Business.Services.Interfaces;

using MarketPlaceExam.Data.Repos;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<MarketPlaceExam.Data.Entities.User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();
builder.Services.AddControllersWithViews();

//Transients
RegisterServices(builder);

WebApplication app = builder.Build();


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

// DI Register
void RegisterServices(WebApplicationBuilder builder)
{
    RegisterRepositories(builder.Services);
    RegisterBusinessServices(builder.Services);
    RegisterAutoMapper(builder.Services);
}

void RegisterAutoMapper(IServiceCollection services)
{
    services.AddAutoMapper(typeof(BusinessMapperProfile));
}

void RegisterBusinessServices(IServiceCollection services)
{
    services.AddTransient<ICartItemService, CartItemService>();
    services.AddTransient<ICartService, CartService>();
    services.AddTransient<ICategoryService, CategoryService>();
    services.AddTransient<IOrderService, OrderService>();
    services.AddTransient<IPaymentService, PaymentService>();
    services.AddTransient<IPictureService, PictureService>();
    services.AddTransient<IProductService, ProductService>();
    services.AddTransient<IShipmentService, ShipmentService>();
    services.AddTransient<IStockService, StockService>();
    services.AddTransient<ISupplierService, SupplierService>();
    services.AddTransient<IUserService, UserService>();
}

void RegisterRepositories(IServiceCollection services)
{
    services.AddTransient<ICartItemRepo, CartItemRepo>();
    services.AddTransient<ICartRepo, CartRepo>();
    services.AddTransient<ICategoryRepo, CategoryRepo>();
    services.AddTransient<IOrderRepo, OrderRepo>();
    services.AddTransient<IPaymentRepo, PaymentRepo>();
    services.AddTransient<IPictureRepo, PictureRepo>();
    services.AddTransient<IProductRepo, ProductRepo>();
    services.AddTransient<IShipmentRepo, ShipmentRepo>();
    services.AddTransient<IShipperRepo, ShipperRepo>();
    services.AddTransient<IStockRepo, StockRepo>();
    services.AddTransient<ISupplierRepo, SupplierRepo>();
    services.AddTransient<IUserRepo, UserRepo>();
}