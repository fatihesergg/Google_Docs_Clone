using Ganss.Xss;
using Google_Docs_Clone.Models;
using Google_Docs_Clone.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IDocumentRepository, DocumentRepository>();
builder.Services.AddSingleton<IHtmlSanitizer, HtmlSanitizer>();

var app = builder.Build();

// Restricted Tags
var _restrictedTags = new List<string>() { "input", "textarea", "script", "iframe", "meta", "form", "location", "innerHTML", "innerText", "setAttribute", "xml" };

var sanitizer = app.Services.GetService<IHtmlSanitizer>();
_restrictedTags.ForEach(tag => sanitizer.AllowedTags.Remove(tag));


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
    pattern: "{controller=Document}/{action=Index}/{id?}");

app.Run();
