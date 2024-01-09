using Microsoft.EntityFrameworkCore;
using PermohonanSurat.Interfaces;
using PermohonanSurat.Models;
using PermohonanSurat.Services;
using PermohonanSurat.Views.Services.Interface;

using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PermohonanSuratContext>(service =>
    service.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));

builder.Services.AddScoped<IPerusahaanService, PerusahaanService>();

builder.Services.AddScoped<IReportNilaiService, ReportNilaiService>();

builder.Services.AddScoped<ISidangTugasAkhirService, SidangTugasAkhirService>();

builder.Services.AddScoped<IPerusahaanService, PerusahaanService>();

builder.Services.AddScoped<IMahasiswaService, MahasiswaService>();

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
//app.MapControllerRoute(name: "mahasiswa",
//              pattern: "{controller = MahasiswaControllers}/{action = Index}");
//app.MapControllerRoute(name: "reportnilai",
//                pattern: "{controller = ReportNilaiControllers}/{action = Index}");
//app.MapControllerRoute(name: "perusahaan",
//              pattern: "{controller = PerusahaanControllers}/{action = Index}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "mahasiswa",
        pattern: "Mahasiswa/{action}/{id?}",
        defaults: new { controller = "MahasiswaController", action = "Index" }
    );

    // Rute lainnya bisa ditambahkan di sini...

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
