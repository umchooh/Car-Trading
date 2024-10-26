<<<<<<< Updated upstream
=======
using Microsoft.EntityFrameworkCore;
using CarTrading;
>>>>>>> Stashed changes
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add session services ( Added by Jay)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true; // Make the session cookie HTTP only
    options.Cookie.IsEssential = true; // Make the session cookie essential
});

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
app.UseSession();

app.UseAuthorization();

<<<<<<< Updated upstream
=======
/*app.MapControllerRoute(
    name: "signup",
    pattern: "SignUp/{action=Index}/{id?}");*/

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ProductList}/{action=Index}/{id?}");*/

>>>>>>> Stashed changes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
