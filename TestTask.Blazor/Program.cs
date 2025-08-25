using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using TestTask.Application.Abstractions;
using TestTask.Application.Services;
using TestTask.Blazor.Components;
using TestTask.Infrastructure;
using TestTask.Infrastructure.Abstractions;
using TestTask.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

string? connectionString = builder.Configuration.GetConnectionString(nameof(TestTaskDbContext));

builder.Services.AddDbContext<TestTaskDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddMudServices();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<ILogService, LogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();