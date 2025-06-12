using Microsoft.EntityFrameworkCore;
using ContactNotePad.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Konfiguracja bazy danych
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Sesja (możesz ją usunąć, jeśli całkowicie przechodzisz na autoryzację przez ciasteczka)
builder.Services.AddSession();

// Rejestracja serwisów
builder.Services.AddScoped<IUserService, UserService>();

// ✅ Dodaj uwierzytelnianie i autoryzację
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // strona logowania
        // options.LogoutPath = "/Login/Logout"; // opcjonalnie
        // options.AccessDeniedPath = "/Login/AccessDenied"; // opcjonalnie
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Obsługa wyjątków i HSTS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Middleware sesji (opcjonalnie, jeśli potrzebujesz)
app.UseSession();

// ✅ Middleware uwierzytelniania i autoryzacji (w tej kolejności!)
app.UseAuthentication();
app.UseAuthorization();

// Routing
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
