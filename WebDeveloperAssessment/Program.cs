using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebDeveloperAssessment.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebDeveloperAssessmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebDeveloperAssessmentContext") ?? throw new InvalidOperationException("Connection string 'WebDeveloperAssessmentContext' not found.")));

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
