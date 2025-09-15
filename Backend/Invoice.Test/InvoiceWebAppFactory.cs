using Invoice.Model;
using Invoice.Repository;
using Invoice.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Test
{
    public class InvoiceWebAppFactory : WebApplicationFactory<Program>
    {

        private readonly Mock<IInvoiceRepository<Company>> _mockCompanyRepository;
        private readonly Mock<IInvoiceRepository<Bank>> _bankRepository;

        public Mock<IInvoiceRepository<Company>> CompanyRepository { get { return _mockCompanyRepository; } }

        public Mock<IInvoiceRepository<Bank>> BankRepository { get { return _bankRepository; } }

        public InvoiceWebAppFactory()
        {
            this._mockCompanyRepository = new Mock<IInvoiceRepository<Company>>();
            this._bankRepository = new Mock<IInvoiceRepository<Bank>>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(service =>
            {
                service.RemoveAll<IInvoiceRepository<Company>>();
                service.AddScoped<IInvoiceRepository<Company>>(_ => this._mockCompanyRepository.Object);

                service.RemoveAll<IInvoiceRepository<Bank>>();
                service.AddScoped<IInvoiceRepository<Bank>>(_ => this._bankRepository.Object);


                service.AddScoped<IService<Company>, CompanyService>();
            });
        }
    }
}
