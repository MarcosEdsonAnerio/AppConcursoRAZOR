using AppConcurso.Data;
using AppConcurso.Contexto;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<CargoService>();
builder.Services.AddScoped<CandidatoService>();
builder.Services.AddScoped<InscricaoService>();
builder.Services.AddScoped<NotaService>();

string mySqlConexao = builder.Configuration.GetConnectionString("BaseConexaoMySql");
builder.Services.AddDbContextPool<ConcursoContext>(options =>
options.UseMySql(mySqlConexao, ServerVersion.AutoDetect(mySqlConexao)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
