using Microsoft.EntityFrameworkCore;
using PhoneStore5.DataBase;
using PhoneStore5.Repository;
using PhoneStore5.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add Register Repository
builder.Services.AddScoped<IProduct, ProductRepo>();
//builder.Services.AddScoped(typeof(IProduct),typeof(ProductRepo));
builder.Services.AddSingleton<GetNewConnection>();
builder.Services.AddSingleton<GetQueryDapper>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
