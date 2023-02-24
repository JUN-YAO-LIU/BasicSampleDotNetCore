using BasicSample.DbAccess;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configurations = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(configurations.GetConnectionString("DbString")));

// 多語系
// builder.Services.AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");
builder.Services.AddPortableObjectLocalization();

builder.Services
    .Configure<RequestLocalizationOptions>(options =>
    {
        string[] supportedCultures = { "en-US", "zh-TW" };
        var supportedCulture = supportedCultures.Select(x => new CultureInfo(x)).ToList();

        options.DefaultRequestCulture = new RequestCulture("en-US" ?? "en-US");
        options.SupportedCultures = supportedCulture;
        options.SupportedUICultures = supportedCulture;
    }

        );

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddViewLocalization();

builder.Services.AddMvc();

#pragma warning disable CS0618
builder.Services.AddFluentValidation(options =>
  {
      options.ImplicitlyValidateChildProperties = true;
      options.ImplicitlyValidateRootCollectionElements = true;
      options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
  });
#pragma warning restore CS0618 // 類型或成員已經過時

// 1.Cors
string[] corsParameter = { "http://test.com", "https://test.com" };
builder.Services.AddCors(opt =>
    opt.AddPolicy("TestCorsPolicy", policy =>
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins(corsParameter)));

var app = builder.Build();

// 2.Cors
app.UseCors("TestCorsPolicy");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    // 強制使用Hsts
    app.UseHsts();
}

// 自動轉向Https網頁
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// MapRazorPages
// MapBlazorHub
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();