using Invoice;
using Invoice.DTO;
using Invoice.MiddleWare;
using Invoice.Model;
using Invoice.Repository;
using Invoice.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DI
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAppContext, Invoice.AppContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddEntityFrameworkSqlServer();
builder.Services.AddDbContext<InvoiceDBContext>((sp, option) =>
{
    var companyContext = sp.GetRequiredService<IAppContext>();
    option.UseSqlServer(builder.Configuration.GetConnectionString("InvoiceConnection"));
    option.UseInternalServiceProvider(sp);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ExceptionHandlerMiddleWare>();
builder.Services.AddScoped<CompanyContextMiddleware>();

//Repository
builder.Services.AddScoped<IInvoiceRepository<Company>, InvoiceRepository<Company>>();
builder.Services.AddScoped<IInvoiceRepository<Bank>, InvoiceRepository<Bank>>();
builder.Services.AddScoped<IInvoiceRepository<BankDetail>, InvoiceRepository<BankDetail>>();
builder.Services.AddScoped<IInvoiceRepository<Customer>, InvoiceRepository<Customer>>();
builder.Services.AddScoped<IInvoiceRepository<Driver>, InvoiceRepository<Driver>>();
builder.Services.AddScoped<IInvoiceRepository<Vehicle>, InvoiceRepository<Vehicle>>();
builder.Services.AddScoped<IInvoiceRepository<VehicleDetail>, InvoiceRepository<VehicleDetail>>();
builder.Services.AddScoped<IInvoiceRepository<Invoice.Model.Invoice>, InvoiceRepository<Invoice.Model.Invoice>>();
builder.Services.AddScoped<IInvoiceRepository<InvoiceDetail>, InvoiceRepository<InvoiceDetail>>();
builder.Services.AddScoped<IInvoiceRepository<ItemMaster>, InvoiceRepository<ItemMaster>>();

builder.Services.AddScoped<IService<Company>, CompanyService>();
builder.Services.AddScoped<IService<Bank>, BankService>();
builder.Services.AddScoped<IBankDetailService, BankDetailService>();
builder.Services.AddScoped<IService<Customer>,  CustomerService>();
builder.Services.AddScoped<IService<Driver>, DriverService>();
builder.Services.AddScoped<IService<Vehicle>, VehicleService>();
builder.Services.AddScoped<IService<VehicleDetail>, VehicleDetailService>();
builder.Services.AddScoped<IService<ItemMaster>, ItemMasterService>();

//builder.Services.AddScoped<AssertService<Bank>, AssertService<Bank>>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseMiddleware<CompanyContextMiddleware>();

app.Run();

public partial class Program { }
