using Invoice;
using Invoice.DTO;
using Invoice.Model;
using Invoice.Repository;
using Invoice.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddDbContext<InvoiceDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("InvoiceConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.AddScoped<IAppContext, Invoice.AppContext>();

//Repository
builder.Services.AddScoped<IInvoiceRepository<Company>, InvoiceRepository<Company>>();
builder.Services.AddScoped<IInvoiceRepository<Bank>, InvoiceRepository<Bank>>();
builder.Services.AddScoped<IInvoiceRepository<BankDetail>, InvoiceRepository<BankDetail>>();

builder.Services.AddScoped<IService<Company>, CompanyService>();
builder.Services.AddScoped<IService<Bank>, BankService>();
builder.Services.AddScoped<IBankDetailService, BankDetailService>();

//builder.Services.AddScoped<AssertService<Bank>, AssertService<Bank>>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CompanyContextMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
