using MascotasASP.Data;
using Microsoft.EntityFrameworkCore;
using MascotasASP.Services;
using MascotasASP.IServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Mandamos a llamar al nombre de la cadena de conexión(DefaultConnection) que se encuentra en el archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    // en esta linea de codigo cambiamos el motor de base de datos a usar (UseSQLServer,UseSQLlite,UseMySql)
    options.UseSqlServer(connectionString)
);


// servicios 
builder.Services.AddScoped<IDueño, DueñoServices>();    
builder.Services.AddScoped<IMetroscuadrados, MetrosServices>();
builder.Services.AddScoped<IHorarios, HorariosServices>();
builder.Services.AddScoped<IMascotas, MascotasServices>();  
builder.Services.AddScoped<IAsignacion, AsignacionServices>();  
builder.Services.AddScoped<IReporte, ReporteServices>();    

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
