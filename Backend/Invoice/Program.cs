using Invoice;
using Invoice.DTO;
using Invoice.Handler.Delete;
using Invoice.MiddleWare;
using Invoice.Model;
using Invoice.Repository;
using Invoice.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

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
builder.Services.AddScoped<IInvoiceRepository<FinancialYear>, InvoiceRepository<FinancialYear>>();
builder.Services.AddScoped<IInvoiceRepository<VehicleRateConfiguration>, InvoiceRepository<VehicleRateConfiguration>>();
builder.Services.AddScoped<IInvoiceRepository<VoucherMaster>, InvoiceRepository<VoucherMaster>>();
builder.Services.AddScoped<IInvoiceRepository<PaymentReceived>, InvoiceRepository<PaymentReceived>>();
builder.Services.AddScoped<IInvoiceRepository<VoucherDetail>, InvoiceRepository<VoucherDetail>>();
builder.Services.AddScoped<IInvoiceRepository<ItemInterval>, InvoiceRepository<ItemInterval>>();
builder.Services.AddScoped<IInvoiceRepository<InvoicePayment>, InvoiceRepository<InvoicePayment>>();

builder.Services.AddScoped<DeleteBank, DeleteBank>();
builder.Services.AddScoped<DeleteCustomer, DeleteCustomer>();
builder.Services.AddScoped<DeleteInvoice, DeleteInvoice>();
builder.Services.AddScoped<DeletePayment, DeletePayment>();
builder.Services.AddScoped<DeleteVehicle, DeleteVehicle>();
builder.Services.AddScoped<DeleteVoucher, DeleteVoucher>();
builder.Services.AddScoped<DeleteVoucherDetail, DeleteVoucherDetail>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IService<Bank>, BankService>();
builder.Services.AddScoped<IBankDetailService, BankDetailService>();
builder.Services.AddScoped<ICustomerService,  CustomerService>();
builder.Services.AddScoped<IService<Driver>, DriverService>();
builder.Services.AddScoped<IService<Vehicle>, VehicleService>();
builder.Services.AddScoped<IVehicleDetailService, VehicleDetailService>();
builder.Services.AddScoped<IItemMasterService, ItemMasterService>();
builder.Services.AddScoped<IFinancialYearService, FinancialYearService>();
builder.Services.AddScoped<IVehicleRateService, VehicleRateService>();
builder.Services.AddScoped<IVoucherService, VoucherService>();
builder.Services.AddScoped<IVoucherDetailService, VoucherDetailService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IInvoicePaymentService, InvoicePaymentService>();

//builder.Services.AddScoped<AssertService<Bank>, AssertService<Bank>>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Automatically apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<InvoiceDBContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseMiddleware<CompanyContextMiddleware>();

app.Run();

public partial class Program { }
