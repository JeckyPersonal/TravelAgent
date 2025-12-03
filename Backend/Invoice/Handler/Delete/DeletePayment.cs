using AutoMapper;
using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Service;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Threading.Tasks;

namespace Invoice.Handler.Delete
{
    public class DeletePayment
    {
        private readonly IPaymentService _paymentService;
        private readonly IInvoiceService _invoiceService;
        private readonly IVoucherService _voucherService;
        private readonly IVoucherDetailService _voucherDetailService;
        
        private readonly IInvoicePaymentService _invoicePaymentService;
        private readonly InvoiceDBContext _dbContext;
        private readonly IMapper _mapper;

        public async Task<PaymentDto> Delete(int paymentId)
        {
            using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    List<InvoicePayment> invoicePayments = await this._invoicePaymentService.DeleteByPaymentId(paymentId);

                    PaymentReceived paymentReceived = await this._paymentService.Delete(paymentId);

                    this.updateInvoiceStatus(invoicePayments);

                    this.updateVoucherStatus(invoicePayments);

                    await transaction.CommitAsync();

                    return this._mapper.Map<PaymentDto>(paymentReceived);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }

        




        //public async Task<VehicleDto> DeleteVehicle(int vehicleId)
        //{
        //    VoucherMaster voucherByVehicle = await this._voucherService.GetVoucherByVehicleId(vehicleId);
        //    if (voucherByVehicle != null)
        //        throw new DeleteConflictException("This vehicle cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the vehicle.");

        //    using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {

        //            await this.deleteVehicleDetail(vehicleId);

        //            await this.deleteVehicleRateConfiguration(vehicleId);

        //            Vehicle deletedVehicle = await this._vehicleService.Delete(vehicleId);

        //            transaction.CommitAsync();

        //            return this._mapper.Map<VehicleDto>(deletedVehicle);
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();
        //            throw ex;
        //        }
        //    }

        //}

        //public async Task<VehicleDetailDto> DeleteVehicleDetail(int vehicleDetailId)
        //{
        //    VoucherMaster voucherByVehicleNo = await this._voucherService.GetByVehilceNo(vehicleDetailId);
        //    if (voucherByVehicleNo != null)
        //        throw new DeleteConflictException("This registration cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the registration.");

        //    using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            VehicleDetail vehicleDetail = await this._vehicleDetailService.Delete(vehicleDetailId);

        //            await transaction.CommitAsync();

        //            return _mapper.Map<VehicleDetailDto>(vehicleDetail);
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();
        //            throw ex;
        //        }
        //    }
        //}

        //public async Task<DriverDto> DeleteDriver(int driverId)
        //{
        //    VoucherMaster voucherByDriver = await this._voucherService.GetByDriverId(driverId);
        //    if (voucherByDriver != null)
        //        throw new DeleteConflictException("This driver cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the driver.");

        //    Driver deletedDriver = await this._driverService.Delete(driverId);

        //    return this._mapper.Map<DriverDto>(deletedDriver);

        //}





        //public async Task<FinancialYearDto> DeleteFinancialYear(int financialYearId)
        //{
        //    FinancialYear financialYear = await this._financialYearService.GetFinancialYearWithSingleRelatedEntity(financialYearId);

        //    if(financialYear.Invoices.Any() || financialYear.Payments.Any() || financialYear.Vouchers.Any())
        //        throw new DeleteConflictException("This financial year cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the financial year.");

        //    FinancialYear deletedYear =  await this._financialYearService.Delete(financialYearId);

        //    return this._mapper.Map<FinancialYearDto>(deletedYear);
        //}

        //public async Task<CompanyDto> DeleteCompany(int companyId)
        //{
        //    Company company = await this._companyService.GetWithSingleRelatedEntity(companyId);

        //    if(company.Banks.Any() || company.Customers.Any() || company.Drivers.Any() || company.FinancialYears.Any() || company.Vehicles.Any() || company.Items.Any())
        //        throw new DeleteConflictException("This company cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the company.");

        //    Company deletedCompany = await this._companyService.Delete(companyId);

        //    return this._mapper.Map<CompanyDto>(deletedCompany);
        //}

        private async Task updateVoucherStatus(List<InvoicePayment> invoicePayments)
        {
            List<int> invoiceIds = invoicePayments.Select(x => x.InvoiceId).Distinct().ToList();

            List<VoucherMaster> vouchers = new List<VoucherMaster>();

            foreach (int invoiceId in invoiceIds)
            {
                List<VoucherMaster> vouchersByInvoiceId = await this._voucherService.GetAllByInvoice(invoiceId);

                vouchers.AddRange(vouchersByInvoiceId);
            }

            await updateVoucherStatus(vouchers, VoucherStatus.Invoice_Printed);
        }

        private async Task<bool> updateVoucherStatus(List<VoucherMaster> vouchers, VoucherStatus status)
        {
            foreach (VoucherMaster voucherMaster in vouchers)
            {
                voucherMaster.voucherStatus = status;
                voucherMaster.InvoiceId = null;
                await this._voucherService.Update(voucherMaster);
            }

            List<int> voucehrIds = vouchers.Select(x => x.Id).ToList();

            List<VoucherDetail> voucherDetails = await this._voucherDetailService.GetAllByVoucherIds(voucehrIds);

            foreach (VoucherDetail voucherDetail in voucherDetails)
            {
                voucherDetail.InvoiceDetailId = null;

                await this._voucherDetailService.Update(voucherDetail);
            }

            return true;
        }

        private async Task<bool> updateInvoiceStatus(List<InvoicePayment> invoicePayments)
        {
            foreach (InvoicePayment invPay in invoicePayments)
            {
                await this._invoiceService.UpdateStatus(invPay.InvoiceId, VoucherStatus.Invoice_Printed);
            }

            return true;
        }
    }
}
