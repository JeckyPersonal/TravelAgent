using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Rental
{
    internal class VoucherLoader : EntityLoader<VoucherMasterDto>
    {
        private readonly VoucherRestClient _voucherRestClient;

        public VoucherLoader(VoucherRestClient voucherRestClient)
        {
            _voucherRestClient = voucherRestClient;
        }

        public List<VoucherMasterDto> GetEntities()
        {
            return this._voucherRestClient.GetAll();
        }
    }

    internal class VoucherLoaderByCustomer : EntityLoader<VoucherMasterDto>
    {
        private readonly VoucherRestClient _voucherRestClient;
        private readonly int _customerId;

        public VoucherLoaderByCustomer(VoucherRestClient voucherRestClient, int customerId)
        {
            _voucherRestClient = voucherRestClient;
            _customerId = customerId;
        }

        public List<VoucherMasterDto> GetEntities()
        {
            return this._voucherRestClient.GetAll(this._customerId);
        }
    }

    internal class ProcessedInvoiceDetailLoader : EntityLoader<InvoiceDetailDto>
    {
        private readonly VoucherRestClient _voucherRestClient;
        private readonly VoucherProcessDto _voucherProcessDto;

        public ProcessedInvoiceDetailLoader(VoucherProcessDto processDto, VoucherRestClient voucherRestClient)
        {
            _voucherProcessDto = processDto;
            _voucherRestClient = voucherRestClient;
        }

        public List<InvoiceDetailDto> GetEntities()
        {
            return this._voucherRestClient.ProcessVoucher(_voucherProcessDto);
        }
    }

    internal class InvoiceDetailLoader: EntityLoader<InvoiceDetailDto>
    {
        private readonly InvoiceModule.InvoiceDetailRestClient _invoiceDetailRestClient;
        private readonly int _invoiceId;

        public InvoiceDetailLoader(InvoiceModule.InvoiceDetailRestClient invoiceDetailRestClient, int invoiceId)
        {
            _invoiceDetailRestClient = invoiceDetailRestClient;
            _invoiceId = invoiceId;
        }

        public List<InvoiceDetailDto> GetEntities()
        {
            return this._invoiceDetailRestClient.GetAll(this._invoiceId);
        }
    }

    internal class SavedInvoiceDetailLoader : EntityLoader<InvoiceDetailDto>
    {
        public List<InvoiceDetailDto> GetEntities()
        {
            throw new NotImplementedException();
        }
    }

    internal class InvoiceLoader : EntityLoader<InvoiceDto>
    {
        private readonly InvoiceModule.InvoiceRestClient _invoiceRestClient;

        public InvoiceLoader(InvoiceModule.InvoiceRestClient invoiceRestClient)
        {
            _invoiceRestClient = invoiceRestClient;
        }

        public List<InvoiceDto> GetEntities()
        {
            return this._invoiceRestClient.GetAll();
        }
    }
}
