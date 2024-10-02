var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    name: "home-about-html",
    pattern: "/about.html",
    defaults: new { controller = "Home", action = "About" });


app.MapControllerRoute(
    name: "home-about",
    pattern: "/about",
    defaults: new { controller = "Home", action = "About" });


app.MapControllerRoute(
    name: "jedi-custom",
    pattern: "/j_{id}.html",
    defaults: new { controller = "Jedi", action = "Details" },
    constraints: new { id = @"\d+"});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
