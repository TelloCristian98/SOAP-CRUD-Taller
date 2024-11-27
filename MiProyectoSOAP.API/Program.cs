using Microsoft.EntityFrameworkCore;
using SoapCore;
using MiProyectoVDL.Data;
using MiProyectoSOAP.VDL.Services;
using MiProyectoSOAP.Contrato;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios para SOAP
builder.Services.AddSoapCore();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Configurar DbContext para PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Crear la aplicación
var app = builder.Build();

// Middleware de SOAP
app.UseRouting();

app.UseSoapEndpoint<ICategoryService>("/soap/Category.asmx", new SoapCore.SoapEncoderOptions());
app.UseSoapEndpoint<IProductService>("/soap/Product.asmx", new SoapCore.SoapEncoderOptions());

app.UseEndpoints(endpoints =>
{
    // Otros mapeos de endpoints
});

// Ejecutar la aplicación
app.Run();