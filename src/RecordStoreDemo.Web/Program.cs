using Microsoft.OpenApi.Models;
using MudBlazor.Services;
using RecordStoreDemo;
using RecordStoreDemo.Web.Components;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("RecordStoreDemo")
    ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddAzureInfrastructure();
builder.Services.AddControllers();
builder.Services.AddExternal();
builder.Services.AddMudServices();
builder.Services.AddPersistence(connectionString);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Record Store Demo API", Version = "v1" });
    c.EnableAnnotations();
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
