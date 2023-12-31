using Microsoft.EntityFrameworkCore;
using TenantPropertyMngt.Data;
using Microsoft.AspNetCore.Identity;
using TenantPropertyMngt.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<TenantPropertyMngtDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'TenantManagementDbContext' not found.")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TenantPropertyMngtDbContext>();

// Add Razor Pages and configure conventions
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/Agent/Lease/TerminationConfirmation", "/Agent/Lease/TerminationConfirmation/{id?}");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});
app.MapRazorPages();

app.Run();
