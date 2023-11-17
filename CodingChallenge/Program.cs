using CodingChallenge.Models;
using CodingChallenge.Repositories;
using CodingChallenge.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Model Scoped
builder.Services.AddScoped<Person>();

//Repositories Scoped
builder.Services.AddScoped<IRepository<Person>, PersonRepository>();

//Services Scoped
builder.Services.AddScoped<IChallengeService, ChallengeService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Challenge}/{action=Index}/{id?}");

app.Run();
