using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;
using Tamkeen.Infrastructure.Database;
using Tamkeen.Infrastructure.Repository;
using Tamkeen.Infrastructure.Roles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITraineeRepository, TraineeRepo>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepo>();
builder.Services.AddScoped<ITrainingProgramRepository, TrainingProgramRepo>();
builder.Services.AddScoped<IProgramPostRepository, ProgramPostRepo>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepo>();
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepo>();

builder.Services.AddControllersWithViews();


builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(options => {
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
   
    options.LoginPath = "/Account/Login";

 
    options.AccessDeniedPath = "/Account/AccessDenied";


    options.LogoutPath = "/Account/Logout";
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
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();


using (var scope = app.Services.CreateScope())
{
    
    await DbInitializer.SeedRolesAndUsers(scope.ServiceProvider);
}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
