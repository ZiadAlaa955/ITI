using Microsoft.EntityFrameworkCore;
using Database_Final_Project.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container
builder.Services.AddRazorPages();

// 2. Database Connection
builder.Services.AddDbContext<DbProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection")));

// 3. Session and Helpers
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// 4. Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// IMPORTANT: Session must be between Routing and Authorization
app.UseSession();
app.UseAuthorization();

// 5. Map the URL to your Pages folder
app.MapRazorPages();

app.Run();