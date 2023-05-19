using Microsoft.EntityFrameworkCore;
using Context = DinoProject.Context;
using DinoProject.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context.AppContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("AppContext"));
});
builder.Services.AddScoped<IDinoRepository, DinoRepository>();
builder.Services.AddScoped<IWhenRepository, WhenRepository>();

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
    name: "dino_list",
    pattern: "DinoSeznam",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "dino_add",
    pattern: "DinoFormAdd",
    defaults: new { controller = "Home", action = "Form" });

app.MapControllerRoute(
    name: "dino_edit",
    pattern: "DinoFormEdit",
    defaults: new { controller = "Home", action = "Edit" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
