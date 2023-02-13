using BLL.Abstract;
using BLL.Concrete;
using BLL.Utilities.Extentions;
using DAL.Abstract;
using DAL.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();


builder.Services.AddBusinessConfiguration(builder.Configuration);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
//app.CustomExceptionHandler();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
   endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
   endpoints.MapDefaultControllerRoute();
});


app.Run();
