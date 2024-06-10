using Kolos.Components;
using Kolos.Context;
using Kolos.Controller;
using Kolos.Repository;
using Kolos.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True"));
builder.Services.AddScoped<ClientController>();
builder.Services.AddScoped<IClientService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<IClientRepo>();
builder.Services.AddScoped<ClientRepo>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.Run();
