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
app.UseStaticFiles(); // It will configure the wwwroot file and all the static file add.

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(               // routing 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

