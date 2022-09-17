using BundlerDeneme3.Data_Acces;
using Microsoft.EntityFrameworkCore;
using WebMarkupMin.AspNet.Common.UrlMatchers;
using WebMarkupMin.AspNetCore6;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<CategoryDb>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddWebMarkupMin()
   .AddHtmlMinification()
   .AddXmlMinification()
   .AddHttpCompression();



builder.Services.AddWebMarkupMin(options =>
{
    options.AllowMinificationInDevelopmentEnvironment = true;
    options.AllowCompressionInDevelopmentEnvironment = true;
}).AddHtmlMinification(options =>
{
    options.MinificationSettings.RemoveHtmlComments = false;
    options.ExcludedPages = new List<IUrlMatcher>
    {
        new WildcardUrlMatcher("/exclude/e*-pages"),
        new ExactUrlMatcher("/exclude-this-particular-page")
    };
});
builder.Services.AddScoped<CategoryDb>();

var app = builder.Build();
//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseWebMarkupMin();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


//minfy

app.Run();