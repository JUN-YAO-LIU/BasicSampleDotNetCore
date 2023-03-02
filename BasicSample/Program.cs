using BasicSample.DbAccess;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configurations = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(configurations.GetConnectionString("DbString")));

// �h�y�t
builder.Services.AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");

// �p�G�S������|�쥻�w�]�r��
string[] languages = { "en", "zh", "jp" };
builder.Services
    .Configure<RequestLocalizationOptions>(options => options
        .AddSupportedCultures(languages)
        .AddSupportedUICultures(languages));

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    // �h�y�t���U�A��
    .AddViewLocalization();

builder.Services.AddMvc();

#pragma warning disable CS0618
builder.Services.AddFluentValidation(options =>
  {
      options.ImplicitlyValidateChildProperties = true;
      options.ImplicitlyValidateRootCollectionElements = true;
      options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
  });
#pragma warning restore CS0618 // �����Φ����w�g�L��

// 1.Cors
string[] corsParameter = { "http://test.com", "https://test.com" };
builder.Services.AddCors(opt =>
    opt.AddPolicy("TestCorsPolicy", policy =>
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins(corsParameter)));

var app = builder.Build();

// �h�y�tMiddleware
app.UseRequestLocalization();

// 2.Cors
app.UseCors("TestCorsPolicy");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    // �j��ϥ�Hsts
    app.UseHsts();
}

// �۰���VHttps����
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