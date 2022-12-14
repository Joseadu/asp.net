using Microsoft.EntityFrameworkCore;
using platzi_school.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<SchoolContext>(p => p.UseInMemoryDatabase("SchoolDB"));
builder.Services.AddSqlServer<SchoolContext>(builder.Configuration.GetConnectionString("cnSchool"));

var app = builder.Build();

using(var scope=app.Services.CreateScope()){
    var serv=scope.ServiceProvider;
    try
    {
        var contex=serv.GetRequiredService<SchoolContext>();
        contex.Database.EnsureCreated();
    }
    catch (System.Exception)
    {
        throw;
    }
}

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
    pattern: "{controller=School}/{action=Index}/{id?}");

app.Run();
