using Microsoft.EntityFrameworkCore;
using MVC2.Installers;
using MVC2.Models;
using MVC2.Models_CF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.InstallerServicesInAssembly(configuration);

    services.AddDbContextPool<QlsinhVienContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'QLSinhVien' not found.")));

    services.AddDbContextPool<QLNhanVienContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("QLNV") ?? throw new InvalidOperationException("Connect string 'QLNhanVien' not found")));
}