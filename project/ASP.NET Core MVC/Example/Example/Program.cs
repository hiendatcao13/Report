using Microsoft.EntityFrameworkCore;
using Example.Data;
using Example.BUS;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextPool<MovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext") ?? throw new InvalidOperationException("Connection string 'MovieContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add transient, scoped, singletone
builder.Services.AddScoped<IMovieService, MovieService>();
var app = builder.Build();

using var scope = app.Services.CreateScope();
{
    var service = scope.ServiceProvider;
    SeedData.Intialize(service);
}
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
    pattern: "{controller=Movies}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
