using CustomerManagement.Client;
using CustomerManagement.Client.Pages;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// 1. Blazor Components & Interactive Server (BẮT BUỘC ĐẶT ĐẦU TIÊN)
// ========================================
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ========================================
// 2. MudBlazor Services (Đăng ký SAU Blazor Components)
// ========================================
builder.Services.AddMudServices();

// ========================================
// 3. Authentication & Authorization
// ========================================
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

// ========================================
// 4. Token & HttpMessageHandler
// ========================================

// ========================================
// 5. HttpClient Configuration
// ========================================
// HttpClient có gắn JwtAuthorizationHandler tự động thêm Bearer token
builder.Services
    .AddHttpClient("Api", client =>
    {
        client.BaseAddress = new Uri("https://localhost:7186/");
    });

// HttpClient mặc định cho các service inject HttpClient trực tiếp
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7186/")
});

// ========================================
// Build Application
// ========================================
var app = builder.Build();

// ========================================
// HTTP Request Pipeline
// ========================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// ========================================
// Map Blazor Endpoints
// ========================================
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();