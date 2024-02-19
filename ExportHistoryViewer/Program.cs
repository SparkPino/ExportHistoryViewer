using Microsoft.EntityFrameworkCore;
using ReportDataBase.DB;
using Service.ServiceReport;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews()
	.AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ExportHistoryDbContext>(opt=>
	opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),b=> b.MigrationsAssembly("ReportDataBase")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IServiceReport , ServiceReport>();
 
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
else
{
	using var scope = app.Services.CreateScope();
	var dbContext = scope.ServiceProvider.GetRequiredService<ExportHistoryDbContext>();
	dbContext.Database.Migrate();
	var mapperConf = scope.ServiceProvider.GetRequiredService<AutoMapper.IConfigurationProvider>();
	mapperConf.AssertConfigurationIsValid();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
